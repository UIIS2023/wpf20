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
    /// Interaction logic for Autobus.xaml
    /// </summary>
    public partial class Autobus : Window
    {


        Konekcija con = new Konekcija();
        SqlConnection connection = new SqlConnection();
        private bool update;
        private DataRowView row;

        public Autobus()
        {
            InitializeComponent();
            txtVrsta.Focus();
            connection = con.KreirajKonekciju();
            fillComboBox();
        }

        public Autobus(bool update, DataRowView row) 
        {
            InitializeComponent();
            txtVrsta.Focus();
            connection = con.KreirajKonekciju();
            this.row = row;
            this.update = update;
            fillComboBox();

        }
        private void fillComboBox()
        {
            try
            {
                connection.Open();
                string PopuniGarazu = @"select garazaID, lokacija from tblGaraza";
                string PopuniPolazak = @"select polazakID, vreme from tblPolazak";
                SqlDataAdapter daGaraza = new SqlDataAdapter(PopuniGarazu, connection);
                DataTable dtGaraza = new DataTable();
                SqlDataAdapter daPolazak = new SqlDataAdapter(PopuniPolazak, connection);
                DataTable dtPolazak = new DataTable();
                cbGaraza.ItemsSource = dtGaraza.DefaultView;
                cbPolazak.ItemsSource = dtPolazak.DefaultView;
                daGaraza.Dispose();
                dtGaraza.Dispose();
                daPolazak.Dispose();
                dtPolazak.Dispose();
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
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = connection
                };

                cmd.Parameters.Add("@vrsta", SqlDbType.NVarChar).Value = txtVrsta.Text;
                cmd.Parameters.Add("@putanja", SqlDbType.NVarChar).Value = txtPutanja.Text;
                cmd.Parameters.Add("@prevoznik", SqlDbType.NVarChar).Value = txtPrevoznik.Text;

                cmd.Parameters.Add("@garaza", SqlDbType.Int).Value = cbGaraza.SelectedValue;
                cmd.Parameters.Add("@polazak", SqlDbType.Int).Value = cbPolazak.SelectedValue;


                if (update) 
                {
                    cmd.Parameters.Add(@"ID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update Autobus set vrsta = @vrsta, putanja = @putanja, prevoznik = @prevoznik, garaza = @garaza, polazak = @polazak where AutobusID = @ID";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Autobus(vrsta, putanja, prevoznik, GarazaID, PolazakID) values(@vrsta, @putanja, @prevoznik, @GarazaID, @PolazakID)";
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
