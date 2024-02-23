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
    /// Interaction logic for Polazak.xaml
    /// </summary>
    public partial class Polazak : Window
    {
        Konekcija con = new Konekcija();
        SqlConnection connection = new SqlConnection();
        private bool update;
        private DataRowView row;

        public Polazak()
        {
            InitializeComponent();
            txtVreme.Focus();
            connection = con.KreirajKonekciju();
            this.update = update;
            this.row = row;
        }

        public Polazak(bool update, DataRowView row)
        {
            InitializeComponent();
            txtVreme.Focus();
            connection = con.KreirajKonekciju();
            this.update = update;
            this.row = row;

        }
       

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();
                DateTime date = (DateTime)DatumPolaska.SelectedDate;
                string datum = date.ToString("dd-MM-yyyy");
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = connection
                };
                cmd.Parameters.Add("@Vreme", SqlDbType.NVarChar).Value = txtVreme.Text;
                cmd.Parameters.Add("@Datum", SqlDbType.Date).Value = datum;
                cmd.Parameters.Add("@VremeDolaska", SqlDbType.NVarChar).Value = txtVremeDolaska.Text;

                if (update)
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update Polazak set Vreme = @Vreme, Datum = @Datum, VremeDolaska = @VremeDolaska where PolazakID = @ID";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Polazak(Vreme, Datum, VremeDolaska) values (@Vreme, @Datum, @VremeDolaska)";
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
