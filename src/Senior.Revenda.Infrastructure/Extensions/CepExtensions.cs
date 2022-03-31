namespace Senior.Revenda.Infrastructure.Extensions
{
    public static class CepExtensions
    {
        public static int RemoverFormatacaoCep(this string obj)
        {
            if (!string.IsNullOrEmpty(obj))
                obj = obj.Replace("-", "");

            int.TryParse(obj, out int result);
            return result;
        }

        public static string FormatarCep(this int obj)
        {
            return obj.ToString();
        }
    }
}
