﻿using System;
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
    public class VendasController : Controller
    {
        private MercadoContext db = new MercadoContext();

        private static Venda vendaCache;

        // GET: Vendas
        public ActionResult Index()
        {
            return View(db.Venda.ToList());
        }

        // GET: Vendas/Details/5
        public ActionResult Details(int? id)
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
        public ActionResult Create([Bind(Include = "Id,Data")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                venda.Itens = vendaCache.Itens;
                db.Venda.Add(venda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(venda);
        }

        public ActionResult CreateWithItemVenda(ModifyItemVendaModel itemVendaModel)
        {
            if (vendaCache == null)
                return RedirectToAction("Index");
            vendaCache.Itens[vendaCache.Itens.Count - 1].Qtd = itemVendaModel.Qtd;
            vendaCache.Itens[vendaCache.Itens.Count - 1].Produto = db.Produtos.Find(itemVendaModel.IdProdutoSelecionado);
            return View(vendaCache);

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
            if (vendaCache != null)
                venda.Itens = vendaCache.Itens;
            venda.Itens.Add(new ItemVenda());
            var model = new ModifyItemVendaModel();
            vendaCache = venda;
            var produtos = db.Produtos.ToList();
            model.Produtos = new List<SelectListItem>();
            foreach (var produto in produtos)
            {
                var item = new SelectListItem()
                {
                    Text = produto.Nome,
                    Value = produto.Id.ToString(),
                    Selected = model.Produtos.Count == 0
                };
                model.Produtos.Add(item);
            }

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
