using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace TableGame.Views.Converters
{
    internal class EnumToColorConverter : IValueConverter
    {
        public object Convert(object stateEnumVal, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string color = "";
            double borderThickness = 0;

            switch ((TileStates)stateEnumVal)
            {
                case TileStates.Default:
                    color = "#474747";
                    break;

                case TileStates.CanMove:
                    color = "#009900";
                    borderThickness = 3;
                    break;
                case TileStates.CanAttack:
                    color = "#FF3737";
                    borderThickness = 3;
                    break;
            }

            if (targetType.GetTypeInfo().Name == typeof(Thickness).Name)
                return borderThickness;

            return color;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {


            return 2;
        }
    }
}
