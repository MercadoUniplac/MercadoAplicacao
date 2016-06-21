using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Uniplac.Mercado.Aplicacao.Contrato;
using Uniplac.Mercado.Aplicacao.Serviço;
using Uniplac.Mercado.Apresentacao.Webforms.Models;
using Uniplac.Mercado.Dominio;
using Uniplac.Mercado.Dominio.Contratos;
using Uniplac.Mercado.Infra.Dados.Contexto;
using Uniplac.Mercado.Infra.Dados.Repositorios;

namespace Uniplac.Mercado.Apresentacao.Webforms.Controllers
{
    [Authorize]
    public class VendasController : Controller
    {
        private IVendaAplicacao servico = new VendaAplicacao(new VendaRepository());
        private IItemVendaAplicacao servicoItemVenda = new ItemVendaAplicacao(new ItemVendaRepository());
        private IProdutoAplicacao servicoProduto = new ProdutoAplicacao(new ProdutoRepository());

        // GET: Vendas
        public ActionResult Index()
        {
            return View(servico.BuscarTodos());
        }

        // GET: Vendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = servico.Busca(id.Value);  
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
                    var produto = new Produto()
                    {
                        Id = int.Parse(vendaModel.Produtos[i])
                    }; 
                    venda.Itens.Add(new ItemVenda(produto, int.Parse(vendaModel.Qtds[i].Value)));
                }
                servico.CriarVenda(venda);
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
            venda.Itens[venda.Itens.Count - 1].Produto = servicoProduto.Busca(int.Parse(itemVendaModel.IdProdutoSelecionado));
            return View(new VendaModel(venda));

        }

        // GET: Vendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = servico.Busca(id.Value);
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
            var model = new ModifyItemVendaModel(venda, servicoProduto.BuscarTodos());
            return View(model);
        }

        public ActionResult ModifyItemVendaModel(VendaModel vendaModel)
        {
            if (vendaModel.Venda == null)
                return RedirectToAction("Index");
            for (int i = 0; i < vendaModel.NumItemVenda; i++)
            {
                var produto = servicoProduto.Busca(int.Parse(vendaModel.Produtos[i]));
                vendaModel.Venda.Itens.Add(new ItemVenda(produto, int.Parse(vendaModel.Qtds[i].Value)));
            }
            vendaModel.Venda.Itens.Add(new ItemVenda());
            var model = new ModifyItemVendaModel(vendaModel.Venda, servicoProduto.BuscarTodos());
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
                servico.Atualizar(venda);
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
            Venda venda = servico.Busca(id.Value);
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
            Venda venda = servico.Busca(id);
            servico.Deletar(venda);
            return RedirectToAction("Index");
        }
    }
}
