using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new LojaContext())
            {

                var produtos = contexto.Produtos;
                foreach (var produto in produtos)
                {
                    Console.WriteLine(produto);
                }
                Console.WriteLine("=====================");

                foreach (var item in contexto.ChangeTracker.Entries())
                {
                    Console.WriteLine(item.State);
                }

                var p3 = contexto.Produtos.Last();
                p3.Nome = "Fiat uno";
                p3.Preco = 11.567;
                              
               

                Console.WriteLine("=====================");
              
                foreach (var produto in contexto.Produtos.ToList())
                {
                    Console.WriteLine(produto);
                }
                Console.WriteLine("=====================");

                foreach (var item in contexto.ChangeTracker.Entries())
                {
                    Console.WriteLine(item.State);
                }

            }


        }

        private static void AtualizarProdutos()
        {
            GravarUsandoEntity();
            RecuperarProdutos();
            using (var repo = new ProdutoDaoEntity())
            {
                var produto = repo.Produtos().FirstOrDefault();
                produto.Nome = "Harry Potter e a Ordem da Fênix - editado";
                repo.Atualizar(produto);
            }
            RecuperarProdutos();
        }

        private static void ExcluirProdutos()
        {
            using (var repo = new ProdutoDaoEntity())
            {
                IList<Produto> produtos = repo.Produtos();
                foreach (var produto in produtos)
                {
                    repo.Remover(produto);
                    
                }
            }
        }

        private static void RecuperarProdutos()
        {
            using (var repo = new ProdutoDaoEntity())
            {
                IList<Produto> produtos = repo.Produtos();
                Console.WriteLine("foram encontrados {0} produto(s) ",produtos.Count);
                foreach (var produto in produtos)
                {
                    Console.WriteLine(produto);
                }
                Console.Read();
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Fiat 147";
            p.Categoria = "automovel";
            p.Preco = 2.0000;

            using (var repo = new ProdutoDaoEntity())
            {
                repo.Adicionar(p);
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
