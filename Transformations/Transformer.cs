using System.Globalization;

namespace Budget.Doc415.Transformations;

static public class Transformer
{
    static public DateTime ConvertToDateTime(string date)
    {
        try
        {
            var isValid = DateTime.TryParseExact(date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out DateTime transActionDate);
            return transActionDate;
        }
        catch
        {
            Console.Error.WriteLine("Not a valid datetime");
            return DateTime.MinValue;
        }
    }
}
