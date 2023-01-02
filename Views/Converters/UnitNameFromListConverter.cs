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
    class UnitNameFromListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var unit = value as List<Unit>;

            if(unit == null)
                return value;

            var newUnits = unit.ToList();

            foreach(var unit2 in unit)
            {
                newUnits.Add(unit2);
            }

            return newUnits;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
