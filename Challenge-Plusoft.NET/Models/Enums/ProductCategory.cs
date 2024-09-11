namespace PlusoftRecommender.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Propriedade de navega��o para os produtos relacionados
        public ICollection<Product> Products { get; set; }
    }
}
