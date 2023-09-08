using System.ComponentModel.DataAnnotations;

namespace WarbyApp.UI.ViewModels
{
    public class EyeglassesCreate_VM
    {
        public int ColorId { get; set; }
        [Required]
        [MaxLength(35)]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        public string Material { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Cost Price must be greater than 0.00")]
        [RegularExpression(@"^\d+(\.\d{2})?$", ErrorMessage = "Cost Price must have two decimal places")]
        [NotGreaterThanCostPriceAttribute2(ErrorMessage = "Cost Price cannot be greater than Sale Price")]
        public decimal CostPrice { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Sale Price must be greater than 0.00")]
        [RegularExpression(@"^\d+(\.\d{2})?$", ErrorMessage = "Sale Price must have two decimal places")]
        public decimal SalePrice { get; set; }
        [Range(0, 100, ErrorMessage = "Discount Percent must be between 0 and 100")]
        public decimal DiscountPercent { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
    }
    public class NotGreaterThanCostPriceAttribute2 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var eyeglasses = (EyeglassesCreate_VM)validationContext.ObjectInstance;

            if (eyeglasses.SalePrice < eyeglasses.CostPrice)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
