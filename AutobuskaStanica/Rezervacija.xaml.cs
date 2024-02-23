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

namespace AutobuskaStanica
{
    /// <summary>
    /// Interaction logic for Rezervacija.xaml
    /// </summary>
    public partial class Rezervacija : Window
    {
        Konekcija con = new Konekcija();
        SqlConnection connection = new SqlConnection();
        private bool update;
        private DataRowView row;

        public Rezervacija()
        {
            InitializeComponent();
        }

        public Rezervacija(bool update, DataRowView row)
        {


        }
        private void fillComboBox()
        {
            try
            {

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
                DateTime date = (DateTime)DatumRezervacije.SelectedDate;
                string datum = date.ToString("dd-MM-yyyy");
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = connection
                };

                cmd.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = txtIme.Text;
                cmd.Parameters.Add("@Vreme", SqlDbType.NVarChar).Value = txtVreme.Text;
                cmd.Parameters.Add("@Datum", SqlDbType.Date).Value = datum;
                cmd.Parameters.Add("@Autobus", SqlDbType.NVarChar).Value = cbAutobus.SelectedValue;

                if (update)
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update Rezervacija set Ime = @Ime, Vreme = @Vreme, Datum = @Datum, AutobusID = @Autobus where RezervacijaID = @ID";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Polazak(Ime, Vreme, Datum, AutobusID) values (@Ime, @Vreme, @Datum, @Autobus)";
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
