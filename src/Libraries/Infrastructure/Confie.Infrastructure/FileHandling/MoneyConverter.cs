using FileHelpers;

namespace Confie.Infrastructure.FileHandling
{
    public class MoneyConverter : ConverterBase
    {
        public override object StringToField(string from)
        {
            decimal.TryParse(from, out var result);

            return result / 100;
        }
    }
}