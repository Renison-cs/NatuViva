namespace NatuViva.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Itens { get; set; } = new();
        public decimal Total => Itens.Sum(i => i.Preco * i.Quantidade);

    }
}
