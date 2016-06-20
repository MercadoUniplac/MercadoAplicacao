using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Uniplac.Mercado.Apresentacao.Webforms.Models;
using Uniplac.Mercado.Dominio;
using Uniplac.Mercado.Infra.Dados.Contexto;

namespace Uniplac.Mercado.Apresentacao.Webforms.Controllers
{
    [Authorize]
    public class VendasController : Controller
    {
        private MercadoContext db = new MercadoContext();

        // GET: Vendas
        public ActionResult Index()
        {
            return View(db.Venda.Include(v => v.Itens).ToList());
        }

        // GET: Vendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Venda.Include(v => v.Itens).Where(v => v.Id == id).FirstOrDefault();
            for (int i = 0; i < venda.Itens.Count; i++)
            {
                var idItem = venda.Itens[i].Id;
                venda.Itens[i] = db.ItensVenda.Include(itv => itv.Produto).Where(itv => itv.Id == idItem).FirstOrDefault();
            }
            if (venda == null)
            {
                return HttpNotFound();
            }
            var model = new VendaModel(venda);
            return View(model);
        }

        // GET: Vendas/Create
        public ActionResult Create()
        {
            var venda = new Venda();
            venda.Data = DateTime.Now;
            return View(venda);
        }

        // POST: Vendas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendaModel vendaModel)
        {
            if (ModelState.IsValid)
            {
                var venda = vendaModel.Venda;
                for (int i = 0; i < vendaModel.NumItemVenda; i++)
                {
                    var produto = db.Produtos.Find(int.Parse(vendaModel.Produtos[i].Value));
                    venda.Itens.Add(new ItemVenda(produto, int.Parse(vendaModel.Qtds[i].Value)));
                }
                db.Venda.Add(venda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendaModel);
        }

        public ActionResult CreateWithItemVenda(ModifyItemVendaModel itemVendaModel)
        {
            var venda = itemVendaModel.Venda;
            if (venda == null)
                return RedirectToAction("Index");
            venda.Itens[venda.Itens.Count - 1].Qtd = itemVendaModel.Qtd;
            venda.Itens[venda.Itens.Count - 1].Produto = db.Produtos.Find(int.Parse(itemVendaModel.IdProdutoSelecionado));
            return View(new VendaModel(venda));

        }

        // GET: Vendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Venda.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        public ActionResult ModifyItemVenda(Venda venda)
        {
            if (venda == null)
                return RedirectToAction("Index");
            venda.Itens.Add(new ItemVenda());
            var model = new ModifyItemVendaModel(venda, db.Produtos.ToList());
            return View(model);
        }

        public ActionResult ModifyItemVendaModel(VendaModel vendaModel)
        {
            if (vendaModel.Venda == null)
                return RedirectToAction("Index");
            for (int i = 0; i < vendaModel.NumItemVenda; i++)
            {
                var produto = db.Produtos.Find(int.Parse(vendaModel.Produtos[i].Value));
                vendaModel.Venda.Itens.Add(new ItemVenda(produto, int.Parse(vendaModel.Qtds[i].Value)));
            }
            vendaModel.Venda.Itens.Add(new ItemVenda());
            var model = new ModifyItemVendaModel(vendaModel.Venda, db.Produtos.ToList());
            return View(model);
        }


        // POST: Vendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Venda.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venda venda = db.Venda.Find(id);
            db.Venda.Remove(venda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
