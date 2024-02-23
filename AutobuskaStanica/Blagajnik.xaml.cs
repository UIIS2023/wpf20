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
    /// Interaction logic for Blagajnik.xaml
    /// </summary>
    public partial class Blagajnik : Window
    {
        Konekcija con = new Konekcija();
        SqlConnection connection = new SqlConnection();
        private bool update;
        private DataRowView row;

        public Blagajnik()
        {
            InitializeComponent();
            txtIme.Focus();
            connection = con.KreirajKonekciju();
        }

        public Blagajnik(bool update, DataRowView row)
        {
            InitializeComponent();
            txtIme.Focus();
            connection = con.KreirajKonekciju();
            this.row = row;
            this.update = update;


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
                cmd.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = txtIme.Text;
                cmd.Parameters.Add("@Prezime", SqlDbType.NVarChar).Value = txtPrezime.Text;
                cmd.Parameters.Add("@JMBG", SqlDbType.Int).Value = txtJMBG.Text;
                cmd.Parameters.Add("@Adresa", SqlDbType.NVarChar).Value = txtKorIme.Text;
                cmd.Parameters.Add("@Grad", SqlDbType.NVarChar).Value = txtLozinka.Text;
                cmd.Parameters.Add("@KorIme", SqlDbType.NVarChar).Value = txtKorIme.Text;
                cmd.Parameters.Add("@Lozinka", SqlDbType.NVarChar).Value = txtLozinka.Text;
                cmd.Parameters.Add("@Kontakt", SqlDbType.NVarChar).Value = txtKontakt.Text;
                if (update)
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update Blagajnik set ime=@Ime, prezime = @Prezime, jmbg=@JMBG, grad=@Grad, adresa=@Adresa korIme = @KorIme, lozinka = @Lozinka, kontakt = @Kontakt where BlagajnikID = @ID";
                }
                else
                {
                    cmd.CommandText = @"insert into Blagajnik(ime, prezime, JMBG, Adresa, Grad, korIme, lozinka, kontakt) values(@ime, @prezime, @jmbg, @grad, @adresa, @korime, @lozinka, @kontakt)";
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
