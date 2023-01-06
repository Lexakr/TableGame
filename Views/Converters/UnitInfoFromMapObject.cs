using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TableGame.Units;

namespace TableGame.Views.Converters
{
    class UnitInfoFromMapObject : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var unit = value as Unit;

#if DEBUG
            if(unit != null)
                return unit.Data();
#else
            if (unit != null)
                return unit.Data(); // TODO: сменить имя метода на новый
#endif

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
