using System;
using Uniplac.Mercado.Aplicacao.Contrato;
using Uniplac.Mercado.Dominio;
using Uniplac.Mercado.Dominio.Contratos;

namespace Uniplac.Mercado.Aplicacao.Serviço
{
    public class VendaAplicacao : IVendaAplicacao
    {
       
            private IVendaRepository _repositorio;

            public VendaAplicacao(IVendaRepository repositorio)
            {
                this._repositorio = repositorio;
            }

            public Venda Atualizar(Venda venda)
            {
                Venda vendaAtualizada = _repositorio.Atualizar(venda);

                return vendaAtualizada;
            }

            public Venda Busca(int id)
            {
                Venda venda = _repositorio.Buscar(id);
                return venda;
            }

            public Venda CriarVenda(Venda venda)
            {
                return _repositorio.Adicionar(venda);
            }

            public Venda Deletar(Venda venda)
            {
                _repositorio.Deletar(venda);
                return venda;
            }
        }
    }

