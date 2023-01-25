using FluentValidation;
using StokYonetim.Entites;

namespace StokYonetim.BL.Validations
{
    public class StokValidation : AbstractValidator<Stok>
    {
        public StokValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.StokAdi).Length(0, 50).NotEmpty().NotNull();
            RuleFor(x => x.Fiyat).ExclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.Adet).ExclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.Birim).NotEmpty();

        }

    }
}
