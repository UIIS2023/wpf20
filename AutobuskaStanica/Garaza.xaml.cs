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
    /// Interaction logic for Garaza.xaml
    /// </summary>
    public partial class Garaza : Window
    {
        Konekcija con = new Konekcija();
        SqlConnection connection = new SqlConnection();
        private bool update;
        private DataRowView row;

        public Garaza()
        {
            InitializeComponent();
            txtLokacija.Focus();
            connection = con.KreirajKonekciju();
            
            
        }

        public Garaza(bool update, DataRowView row)
        {
            InitializeComponent();
            txtLokacija.Focus();
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
                cmd.Parameters.Add("@Lokacija", SqlDbType.NVarChar).Value = txtLokacija.Text ;
                cmd.Parameters.Add("@Mesto", SqlDbType.Int).Value = txtMesto.Text ;
                if (update)
                {
                    cmd.Parameters.Add("@ID",SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update Garaza set lokacija = @lokacija, brmesta = @mesto where GarazaID = @ID";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Garaza(lokacija, brmesta) values(@lokacija, @mesto)";
                    
                }
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
