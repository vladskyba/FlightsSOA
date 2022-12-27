using System.Linq;

namespace ReservationService.ModelsConfigurations
{
    public static class ModelConfiguratorExstension
    {
        public static string ToSnakeCase(this string str)
        {
            return string.Concat(str.Select((char x, int i) => (i <= 0 || !char.IsUpper(x)) ? x.ToString() : ("_" + x))).ToLower();
        }
    }
}
