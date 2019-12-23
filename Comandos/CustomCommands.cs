using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Comandos
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Nuevo = new RoutedUICommand
            (
                "Nuevo",
                "Nuevo",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.N,ModifierKeys.Control)
                }
            );
        public static readonly RoutedUICommand Salir = new RoutedUICommand
            (
                "Salir",
                "Salir",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.S,ModifierKeys.Control)
                }
            );
        public static readonly RoutedUICommand Vaciar = new RoutedUICommand
            (
                "Vaciar",
                "Vaciar",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.V,ModifierKeys.Alt)
                }
            );

      
    }
}
