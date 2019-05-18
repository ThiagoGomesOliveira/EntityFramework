namespace Alura.Loja.Testes.ConsoleApp
{
    public class Produto
    {
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Categoria { get; internal set; }
        public double Preco { get; internal set; }



        public override string ToString()
        {
            return $"Nome: {this.Nome} Categoria {this.Categoria} Preço {this.Preco}";
        }
    }
}