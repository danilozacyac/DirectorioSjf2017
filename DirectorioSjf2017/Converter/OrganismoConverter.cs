using System;
using System.Linq;
using System.Windows.Data;
using DirectorioSjf2017.Singletons;

namespace DirectorioSjf2017.Converter
{
    public class OrganismoConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int idOrg = 0;
            Int32.TryParse(value.ToString(), out idOrg);

            if (idOrg == 0)
            {
                return String.Empty;
            }
            return OrganismoDirSingleton.Organismos.FirstOrDefault(x => x.IdOrganismo == idOrg).OrganismoDesc;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}