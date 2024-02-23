using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutobuskaStanica
{
    /// <summary>
    /// Interaction logic for Karta.xaml
    /// </summary>
    public partial class Karta : Window
    {
        Konekcija con = new Konekcija();
        SqlConnection connection = new SqlConnection();
        private bool update;
        private DataRowView row;

        public Karta()
        {
            InitializeComponent();
            txtStatus.Focus();
            connection = con.KreirajKonekciju();
            fillComboBox();
            
        }

        public Karta(bool update, DataRowView row)
        {
            InitializeComponent();
            txtStatus.Focus();
            connection = con.KreirajKonekciju();
            fillComboBox();
            this.update = update;
            this.row = row;

        }
        private void fillComboBox()
        {
            try
            {
                connection.Open();
                string PopuniKupca = @"select KupacID, ime from Kupac ";
                string PopuniTip = @"select TipID, naziv from TipKarte";
                string PopuniRezervaciju = @"select RezervacijaID, ime from Rezervacija";
                string PopuniBlagajnika = @"select BlagajnikID, ime from Blagajnik ";
                string PopuniZonu = @"select ZonaID, broj from Zona";
                SqlDataAdapter daKupac = new SqlDataAdapter(PopuniKupca, connection);
                SqlDataAdapter daTip = new SqlDataAdapter(PopuniTip, connection);
                SqlDataAdapter daRezervacija = new SqlDataAdapter(PopuniRezervaciju, connection);
                SqlDataAdapter daBlagajnik = new SqlDataAdapter(PopuniBlagajnika, connection);
                SqlDataAdapter daZona = new SqlDataAdapter(PopuniZonu, connection);
                DataTable dtKupac = new DataTable();
                DataTable dtTip = new DataTable();
                DataTable dtRezervacija = new DataTable();
                DataTable dtBlagajnik = new DataTable();
                DataTable dtZona = new DataTable();
                cbKupac.ItemsSource = dtKupac.DefaultView;
                cbTipKarte.ItemsSource = dtTip.DefaultView;
                cbRezervacija.ItemsSource = dtRezervacija.DefaultView;
                cbBlagajnik.ItemsSource = dtBlagajnik.DefaultView;
                cbZona.ItemsSource = dtZona.DefaultView;
                daKupac.Dispose();
                dtKupac.Dispose();
                daTip.Dispose();
                dtTip.Dispose();
                daRezervacija.Dispose();
                dtRezervacija.Dispose();
                daBlagajnik.Dispose();
                dtBlagajnik.Dispose();
                daZona.Dispose();
                dtZona.Dispose();


            }
            catch
            {
                MessageBox.Show("Greška pri ucitavanju", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally { if (connection != null) connection.Close(); }
        }




        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();
                DateTime date = (DateTime)Datum.SelectedDate;
                string datum = date.ToString("dd-MM-yyyy");
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = connection
                };
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = txtStatus.Text;
                cmd.Parameters.Add("@Cena", SqlDbType.Int).Value = txtCena.Text;
                cmd.Parameters.Add("@Sediste", SqlDbType.Int).Value = txtBrojSedista.Text;
                cmd.Parameters.Add("@Kupac", SqlDbType.NVarChar).Value = cbKupac.SelectedValue;
                cmd.Parameters.Add("@Tip",SqlDbType.NVarChar).Value = cbTipKarte.SelectedValue;
                cmd.Parameters.Add("@Rezervacija", SqlDbType.NVarChar).Value = cbRezervacija.SelectedValue;
                cmd.Parameters.Add("@Blagajnik", SqlDbType.NVarChar).Value = cbBlagajnik.SelectedValue;
                cmd.Parameters.Add("@Zona", SqlDbType.Int).Value = cbZona.SelectedValue;
                cmd.Parameters.Add("@Datum", SqlDbType.Date).Value = datum;
                if (update)
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update Karta set StatusZaposlenostiKupca = @Status, Cena = @Cena, brSedista = @Sediste, KupacID = @Kupac, TipID = @Tip, RezervacijaID = @Rezervacija, BlagajnikID = @Blagajnik, ZonaID = @Zona where KartaID = @ID ";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Karta(StatusZaposlenostiKupca, Cena, Sediste, KupacID, TipID, RezervacijaID, BlagajnikID, ZonaID, DatumID) values (@Status, @Cena, @Sediste, @Kupac, @Tip, @Rezervacija, @Blagajnik, @Zona, @Datum)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Pogresano uneti podaci!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
