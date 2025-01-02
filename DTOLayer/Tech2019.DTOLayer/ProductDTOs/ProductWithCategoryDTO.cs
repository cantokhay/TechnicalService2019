namespace Tech2019.DTOLayer.ProductDTOs
{
    public class ProductWithCategoryDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public decimal ProductPurchasePrice { get; set; }
        public decimal ProductSalePrice { get; set; }
        public short Stock { get; set; }
        public byte CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProductStatus { get; set; }
    }
}
