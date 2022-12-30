using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TableGame.Views.Converters
{
    internal class EnumToColorConverter : IValueConverter
    {
        public object Convert(object stateEnumVal, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string color = "";

            switch((TileStates)stateEnumVal)
            {
                case TileStates.Default:
                    color = "#474747";
                    break;

                case TileStates.CanMove:
                    color = "#009900";
                    break;
                case TileStates.CanAttack:
                    color = "#FF3737";
                    break;
            }


            return color;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {


            return 2;
        }
    }
}
