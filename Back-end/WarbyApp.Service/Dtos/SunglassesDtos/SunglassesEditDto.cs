using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Service.Dtos.EyeglassesDtos;

namespace WarbyApp.Service.Dtos.SunglassesDtos
{
    public class SunglassesEditDto
    {
        public string Name { get; set; }
        public string Material { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public IFormFile ImageName { get; set; }
        public SunglassesColorEdit Colors { get; set; }
    }
    public class SunglassesColorEdit
    {
        public int ColorId { get; set; }
        public int NewColor { get; set; }
    }
    public class SunglassesEditDtoValidator : AbstractValidator<SunglassesEditDto>
    {
        public SunglassesEditDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().MaximumLength(35);
            RuleFor(x => x.Material)
                .NotEmpty().MaximumLength(30);
            RuleFor(x => x.SalePrice)
                .GreaterThan(0);
            RuleFor(x => x.CostPrice)
                .LessThanOrEqualTo(x => x.SalePrice);
            RuleFor(x => x.DiscountPercent)
                .InclusiveBetween(0, 100);

            RuleFor(x => x.ImageName).NotNull();

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.ImageName != null)
                {
                    if (x.ImageName.Length > 2 * 1024 * 1024)
                        context.AddFailure("ImageFile", "Image file must be less or equal that 2MB");

                    if (x.ImageName.ContentType != "image/png" && x.ImageName.ContentType != "image/jpeg")
                        context.AddFailure("ImageFile", "Image file must be png,jpg or jpeg");
                }
            });
            RuleFor(x => x.Colors.ColorId).GreaterThan(0);
            RuleFor(x => x.Colors.NewColor).GreaterThan(0);
        }
    }
}
