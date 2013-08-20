using System.Globalization;

namespace platform
{
    public class Culture : ICulture
    {
        public string _cultureName()
        {
            return CultureInfo.CurrentCulture.Name;
        }
    }
}
