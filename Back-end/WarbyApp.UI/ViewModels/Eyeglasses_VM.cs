namespace WarbyApp.UI.ViewModels
{
    public class Eyeglasses_VM
    {
        public List<Eyeglasses_VMItem> EyeglassesItems { get; set; }
    }
    public class Eyeglasses_VMItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public string ImageUrl { get; set; }
        public string ColorName { get; set; }
    }
}
