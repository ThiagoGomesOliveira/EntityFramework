using Alura.Loja.Testes.ConsoleApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class ProdutoDaoEntity : IProdutoDao, IDisposable
    {
        private readonly LojaContext context;

        public ProdutoDaoEntity()
        {
            this.context = new LojaContext();
        }

        public void Adicionar(Produto p)
        {
           this.context.Add(p);
            this.context.SaveChanges();
        }

        public void Atualizar(Produto p)
        {
            this.context.Update(p);
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public IList<Produto> Produtos()
        {
            return this.context.Produtos.ToList();
        }

        public void Remover(Produto p)
        {
            this.context.Remove(p);
            this.context.SaveChanges();
        }
    }
}
