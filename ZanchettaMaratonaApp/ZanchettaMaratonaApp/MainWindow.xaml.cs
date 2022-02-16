using System;
using System.Collections.Generic;
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
using System.IO;

namespace ZanchettaMaratonaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassRisultati objRisultati;
        public MainWindow()
        {
            InitializeComponent();
            objRisultati = new ClassRisultati();
            dataGridContenuto.ItemsSource = objRisultati.ListaRisultati;
        }

        private void btnVisualizza_Click(object sender, RoutedEventArgs e)
        {
            using(FileStream flow = new FileStream("risultati.txt", FileMode.Open, FileAccess.Read))
            {
                StreamReader reader = new StreamReader(flow);

                while(!reader.EndOfStream)
                {

                }
            }
        }
    }
}
