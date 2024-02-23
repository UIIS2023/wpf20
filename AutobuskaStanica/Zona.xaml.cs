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
    /// Interaction logic for Zona.xaml
    /// </summary>
    public partial class Zona : Window
    {
        Konekcija con = new Konekcija();
        SqlConnection connection = new SqlConnection();
        private bool update;
        private DataRowView row;

        public Zona()
        {
            InitializeComponent();
            txtBrojZone.Focus();
            connection = con.KreirajKonekciju();
            
        }

        public Zona(bool update, DataRowView row)
        {
            InitializeComponent();
            txtBrojZone.Focus();
            connection = con.KreirajKonekciju();
            this.update = update;
            this.row = row;

        }
       



        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = connection
                };
                cmd.Parameters.Add("@BrojZone", SqlDbType.Int).Value = txtBrojZone.Text;
                cmd.Parameters.Add("@CenaZone", SqlDbType.Int).Value = txtCenaZone.Text;
                if (update)
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update Zona set broj = @BrojZone, cena = @CenaZone where ZonaID = @ID";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Zona(broj, cena) values (@BrojZone, @CenaZone)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Pogresno uneti podaci!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
