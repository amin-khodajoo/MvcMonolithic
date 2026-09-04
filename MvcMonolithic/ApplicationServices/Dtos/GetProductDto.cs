namespace MvcMonolithic.ApplicationServices.Dtos
{
    public class GetProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
