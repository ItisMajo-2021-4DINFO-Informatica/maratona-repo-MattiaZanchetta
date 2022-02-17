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
                    string linea = reader.ReadLine();
                    string[] categorie = linea.Split("%");

                    var objRisultato = new ClassRisultato();
                    objRisultato.NomeAtleta = categorie[0];
                    objRisultato.Company = categorie[1];
                    objRisultato.Tempo = categorie[2];
                    objRisultato.CittaMaratona = categorie[3];

                    objRisultati.AggiungiLinea(objRisultato);
                }
                dataGridContenuto.Items.Refresh();
            }
        }

        private void btnVisualizzaTempo_Click(object sender, RoutedEventArgs e)
        {
            string finaleTemp;
            foreach(var risultati in objRisultati.ListaRisultati)
            {
                if(txtNomeAtleta.Text.ToLower() == risultati.NomeAtleta.ToLower() && txtCittaAtleta.Text.ToLower() == risultati.CittaMaratona.ToLower())
                {
                    finaleTemp = objRisultati.TrasformaTempo(risultati);

                    lblTempoAtleta.Content = $"Il tempo dell'atleta è: {finaleTemp} min.";
                    break;
                }
                else
                {
                    lblTempoAtleta.Content = $"non è stato possibile calcolare il tempo";
                }
            }
        }

        private void btnVisualizzaAtleti_Click(object sender, RoutedEventArgs e)
        {
            string inpText = txtNomeCitta.Text.ToLower();
            string listaAtleti = objRisultati.CercaAtleti(inpText);

            lblListaAtleti.Content = $"Gli atleti sono: {listaAtleti}";


        }

        private void btnSovrascrivi_Click(object sender, RoutedEventArgs e)
        {
            string nomeAtleta = txtNome.Text;
            string nomeSocietà = txtNomeCompany.Text;
            string tempoGara = txtNomeTempo.Text;
            string nomeCittà = txtLuogo.Text;

            objRisultati.InserisciElementi(nomeAtleta, nomeSocietà, tempoGara, nomeCittà);

            dataGridContenuto.Items.Refresh();
        }
    }
}
