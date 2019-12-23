using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Comandos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<TextBlock> lista;
        TextBlock copia;
        DispatcherTimer hora;
        public MainWindow()
        {
           
            lista = new ObservableCollection<TextBlock>();
            InitializeComponent();
            ListaListBox.DataContext = lista;
            hora = new DispatcherTimer();
            hora.Tick += Timer;
            hora.Start();
            
            
        }

        private void NuevoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TextBlock t = new TextBlock();
            string hora = DateTime.Now.ToString("HH:mm:ss");
            t.Text = "Item añadido a las " +hora;
            lista.Add(t);

        }

        private void NuevoCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lista.Count<10)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void SalirCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void VaciarCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            lista.Clear();
        }

        private void VaciarCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lista.Count > 0) e.CanExecute = true;
            else e.CanExecute = false;
        }

        private void CopyCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lista.Count > 0 && ListaListBox.SelectedItem!=null)
            {
                e.CanExecute = true;
            }
            else
                e.CanExecute = false;
        }

        private void CopyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            copia = (TextBlock)ListaListBox.SelectedItem;
        }
        private void Timer(object sender, EventArgs e)
        {
            HoraTextBlock.Text = DateTime.Now.ToLongTimeString();
        }

        private void PasteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lista.Count < 10 && copia!=null)
            {
                e.CanExecute = true;
            }
            else
                e.CanExecute = false;
        }

        private void PasteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            TextBlock aux = new TextBlock();
            aux.Text = copia.Text;
            lista.Add(aux);
            copia = null;
        }
    }
}
