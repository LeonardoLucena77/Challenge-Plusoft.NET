namespace PlusoftRecommender.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Propriedade de navegação para os produtos relacionados
        public ICollection<Product> Products { get; set; }
    }
}
