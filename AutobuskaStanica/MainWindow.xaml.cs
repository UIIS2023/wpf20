using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutobuskaStanica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        Konekcija con = new Konekcija();
        SqlConnection connection = new SqlConnection();
        private bool update;
        private DataRowView row;
        private string? CurrentTable;

        #region Select queries
        private static string SelectBlagajnik = @"select BlagajnikID as ID, Ime as Ime, Prezime as Prezime, jmbg as JMBG, Adresa as Adresa, korime as KorisnickoIme, loz as Lozinka from Blagajnik";
        private static string SelectZona = @"select ZonaID as ID, broj as Broj, cena as Cena from Zona";
        private static string SelectKupac = @"select KupacID as ID, ime as Ime, prezime as Prezime, jmbg as JMBG, adresa as Adresa, grad as Grad, kontakt as Kontakt from Kupac 
                                             join Statuss on Kupac.StatusID = Statuss.statusID";//statusID strani kljuc
        private static string SelectRezervacija = @"select rezervacijaID as ID, ime, datum, vreme from Rezervacija 
                                        join Autobus on Rezervacija.AutobusID = Autobus.AutobusID";//AutobusID strani
        private static string SelectKarta = @"select kartaID as ID, Karta.datum as Datum, statusZaposlenostiKupca as Status, Karta.cena as Cena, brSedista as Broj from Karta 
                                        join Kupac on Karta.KupacID = Kupac.KupacID
                                        join TipKarte on Karta.tipID = TipKarte.tipID
                                        join Rezervacija on Karta.RezervacijaID = Rezervacija.RezervacijaID
                                        join Blagajnik on Karta.BlagajnikID = Blagajnik.BlagajnikID
                                        join Zona on Karta.ZonaID = Zona.ZonaID";//strani: KupacID, TipID, BrojSedistaID, RezervacijaID, BlagajnikID, ZonaID
        private static string SelectPolazak = @"select polazakid as ID, vreme, datum, vremeDolaska from Polazak";
        private static string SelectGaraza = @"Select GarazaID as ID, Lokacija, brMesta as Mesto from Garaza";
        private static string SelectStatus = @"select statusID as ID, NazivStatusa as Naziv, UcenickaPotvrda as Potvrda from Statuss";
        private static string SelectAutobus = @"select AutobusID as ID, vrsta as Vrsta, putanja as Putanja, Prevoznik from Autobus
                                        join Garaza on Autobus.GarazaID = Garaza.GarazaID
                                        join Polazak on Autobus.PolazakID = Polazak.PolazakID"; //strani:GarazaId i PolazakID
        private static string SelectTipKarte = @"select tipID as ID, naziv as Naziv from TipKarte";


        #endregion

        #region Select with statements
        private static string SelectStatementBlagajnik = @"select * from Blagajnik where BlagajnikID=";
        private static string SelectStatementZona = @"select * from Zona where ZonaID=";
        private static string SelectStatementKupac = @"select * from Kupac where KupacID=";
        private static string SelectStatementRezervacija = @"select * from Rezervacija where RezervacijaID=";
        private static string SelectStatementPolazak = @"select * from Polazak where PolazakID=";
        private static string SelectStatementGaraza = @"select * from Garaza where GarazaID=";
        private static string SelectStatementKarta = @"select * from Karta where KartaID=";
        private static string SelectStatementStatus = @"select * from Status where StatusID=";
        private static string SelectStatementAutobus = @"select * from Autobus where AutobusID=";
        private static string SelectStatementTipKarte = @"select * from TipKarte where TipKarteID=";
        #endregion

        #region Delete queries
        private static string DeleteBlagajnik = @"delete from Blagajnik where BlagajnikID = ";
        private static string DeleteZona = @"delete from Zona where ZonaID = ";
        private static string DeleteKupac = @"delete from Kupac where KupacID = ";
        private static string DeletePolazak = @"delete from Polazak where PolazakID = ";
        private static string DeleteKarta = @"delete from Karta where KartaID = ";
        private static string DeleteGaraza = @"delete from Garaza where GarazaID = ";
        private static string DeleteRezervacija = @"delete from Rezervacija where RezervacijaID = ";
        private static string DeleteStatus = @"delete from Status where StatusID = ";
        private static string DeleteAutobus = @"delete * from Autobus where AutobusID=";
        private static string DeleteTipKarte = @"delete * from TipKarte where TipKarteID=";
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            InitializeComponent();
            connection = con.KreirajKonekciju();
            loadData(SelectBlagajnik);

        }


        private void loadData(string SelectString)
        {
            try
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(SelectString, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataGridCentralni != null)
                    dataGridCentralni.ItemsSource = dataTable.DefaultView;
                CurrentTable = SelectString;
                dataAdapter.Dispose();
                dataTable.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Podaci neuspesno ucitani!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }



        private void btnBlagajnik_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectBlagajnik);
        }

        private void btnZona_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectZona);
        }

        private void btnKupac_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectKupac);
        }

        private void btnPolazak_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectPolazak);
        }

        private void btnGaraza_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectGaraza);
        }

        private void btnKarta_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectKarta);
        }

        private void btnStatus_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectStatus);
        }

        private void btnRezervacija_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectRezervacija);
        }
        private void btnAutobus_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectAutobus);
        }
        private void btnTipKarte_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectTipKarte);
        }



        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window form;
            if (CurrentTable.Equals(SelectBlagajnik))
            {
                form = new Blagajnik();
                form.ShowDialog();
                loadData(SelectBlagajnik);
            }
            else if (CurrentTable.Equals(SelectZona))
            {
                form = new Zona();
                form.ShowDialog();
                loadData(SelectZona);
            }
            else if (CurrentTable.Equals(SelectKupac))
            {
                form = new Kupac();
                form.ShowDialog();
                loadData(SelectKupac);
            }
            else if (CurrentTable.Equals(SelectPolazak))
            {
                form = new Polazak();
                form.ShowDialog();
                loadData(SelectPolazak);
            }
            else if (CurrentTable.Equals(SelectGaraza))
            {
                form = new Garaza();
                form.ShowDialog();
                loadData(SelectGaraza);
            }
            else if (CurrentTable.Equals(SelectRezervacija))
            {
                form = new Rezervacija();
                form.ShowDialog();
                loadData(SelectRezervacija);
            }
            else if (CurrentTable.Equals(SelectKarta))
            {
                form = new Karta();
                form.ShowDialog();
                loadData(SelectKarta);
            }
            else if (CurrentTable.Equals(SelectStatus))
            {
                form = new Status();
                form.ShowDialog();
                loadData(SelectStatus);
            }
            else if (CurrentTable.Equals(SelectAutobus))
            {
                form = new Autobus();
                form.ShowDialog();
                loadData(SelectAutobus);
            }
            else if (CurrentTable.Equals(SelectTipKarte))
            {
                form = new TipKarte();
                form.ShowDialog();
                loadData(SelectTipKarte);
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTable.Equals(SelectBlagajnik))
            {
                FillForm(SelectStatementBlagajnik);
                loadData(SelectBlagajnik);
            }
            else if (CurrentTable.Equals(SelectZona))
            {
                FillForm(SelectStatementZona);
                loadData(SelectZona);
            }
            else if (CurrentTable.Equals(SelectKupac))
            {
                FillForm(SelectStatementKupac);
                loadData(SelectKupac);
            }
            else if (CurrentTable.Equals(SelectPolazak))
            {
                FillForm(SelectStatementPolazak);
                loadData(SelectPolazak);
            }
            else if (CurrentTable.Equals(SelectGaraza))
            {
                FillForm(SelectStatementGaraza);
                loadData(SelectGaraza);
            }
            else if (CurrentTable.Equals(SelectRezervacija))
            {
                FillForm(SelectStatementRezervacija);
                loadData(SelectRezervacija);
            }
            else if (CurrentTable.Equals(SelectKarta))
            {
                FillForm(SelectStatementKarta);
                loadData(SelectKarta);
            }
            else if (CurrentTable.Equals(SelectStatus))
            {
                FillForm(SelectStatementStatus);
                loadData(SelectStatus);
            }
            else if (CurrentTable.Equals(SelectAutobus))
            {
                FillForm(SelectStatementAutobus);
                loadData(SelectAutobus);
            }
            else if (CurrentTable.Equals(SelectTipKarte))
            {
                FillForm(SelectStatementTipKarte);
                loadData(SelectTipKarte);
            }
        }

        private void FillForm(string selectStatement)
        {
            try
            {
                connection.Open();
                update = true;
                row = (DataRowView)dataGridCentralni.SelectedItems[0];
                SqlCommand cmd = new SqlCommand { Connection = connection };
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = row["ID"];
                cmd.CommandText = selectStatement + "@ID";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (CurrentTable.Equals(SelectBlagajnik))
                    {
                        Blagajnik FormBlagajnik = new Blagajnik(update, row);
                        FormBlagajnik.txtIme.Text = reader["Ime"].ToString();
                        FormBlagajnik.txtPrezime.Text = reader["Prezime"].ToString();
                        FormBlagajnik.txtJMBG.Text = reader["JMBG"].ToString();
                        FormBlagajnik.txtAdresa.Text = reader["Adresa"].ToString();
                        FormBlagajnik.txtKorIme.Text = reader["KorIme"].ToString();
                        FormBlagajnik.txtLozinka.Text = reader["Loz"].ToString();
                        FormBlagajnik.txtKontakt.Text = reader["Kontakt"].ToString();

                        FormBlagajnik.ShowDialog();
                    }
                    else if (CurrentTable.Equals(SelectZona))
                    {
                        Zona FormZona = new Zona(update, row);
                        FormZona.txtBrojZone.Text = reader["Broj"].ToString();
                        FormZona.txtCenaZone.Text = reader["Cena"].ToString();
                        FormZona.ShowDialog();
                    }
                    else if (CurrentTable.Equals(SelectKupac))                    {
                        Kupac FormKupac = new Kupac(update, row);
                        FormKupac.txtIme.Text = reader["Ime"].ToString();
                        FormKupac.txtPrezime.Text = reader["Prezime"].ToString();
                        FormKupac.txtJMBG.Text = reader["JMBG"].ToString();
                        FormKupac.txtAdresa.Text = reader["Adresa"].ToString();
                        FormKupac.txtGrad.Text = reader["Grad"].ToString();
                        FormKupac.txtKontakt.Text = reader["Kontakt"].ToString();

                        FormKupac.ShowDialog();
                    }
                    else if (CurrentTable.Equals(SelectPolazak))
                    {
                        Polazak FormPolazak = new Polazak(update, row);
                        FormPolazak.txtVreme.Text = reader["Polazak"].ToString();
                        FormPolazak.DatumPolaska.SelectedDate = (DateTime)reader["Vreme"];
                        FormPolazak.txtVremeDolaska.Text = reader["Polazak"].ToString();
                        FormPolazak.ShowDialog();
                    }
                    else if (CurrentTable.Equals(SelectGaraza))
                    {
                        Garaza FormGaraza = new Garaza(update, row);
                        FormGaraza.txtLokacija.Text = reader["Lokacija"].ToString();
                        FormGaraza.txtBrojMesta.Text = reader["Mesto"].ToString();

                        FormGaraza.ShowDialog();
                    }
                    else if (CurrentTable.Equals(SelectKarta))
                    {
                        Karta FormKarta = new Karta(update, row);
                        FormKarta.txtStatus.Text = reader["Status"].ToString();
                        FormKarta.txtCena.Text = reader["Cena"].ToString();
                        FormKarta.txtBrojSedista.Text = reader["Broj"].ToString();

                        //strani kljucevi kupacid, tipid, rezervacijaid, blagajnikid, zonaid
                        FormKarta.cbKupac.SelectedValue = reader["kupacID"].ToString();
                        FormKarta.cbTipKarte.SelectedValue = reader["tipID"].ToString();
                        FormKarta.cbRezervacija.SelectedValue = reader["rezervacijaID"].ToString();
                        FormKarta.cbBlagajnik.SelectedValue = reader["blagajnikID"].ToString();
                        FormKarta.cbZona.SelectedValue = reader["zonaID"].ToString();

                        FormKarta.Datum.SelectedDate = (DateTime)reader["Datum"];
                        FormKarta.ShowDialog();
                    }
                    else if (CurrentTable.Equals(SelectRezervacija))
                    {

                        Rezervacija FormRezervacija = new Rezervacija(update, row);
                        FormRezervacija.txtIme.Text = reader["Ime"].ToString();
                        FormRezervacija.DatumRezervacije.SelectedDate = (DateTime)reader["Datum"];
                        FormRezervacija.txtVreme.Text = reader["Status"].ToString();

                        //strani autobusid
                        FormRezervacija.cbAutobus.SelectedValue = reader["autobusID"].ToString();

                        FormRezervacija.ShowDialog();
                    }
                    else if (CurrentTable.Equals(SelectStatus))
                    {
                        Status FormStatus = new Status(update, row);
                        FormStatus.txtNaziv.Text = reader["Naziv"].ToString();
                        FormStatus.txtPotvrda.Text = reader["Potvrda"].ToString();
                        FormStatus.ShowDialog();
                    }
                    else if (CurrentTable.Equals(SelectAutobus))
                    {
                        Autobus FormAutobus = new Autobus(update, row);
                        FormAutobus.txtVrsta.Text = reader["Vrsta"].ToString();
                        FormAutobus.txtPutanja.Text = reader["Putanja"].ToString();
                        FormAutobus.txtPrevoznik.Text = reader["Prevoznik"].ToString();

                        //strani garazaid, polazakid
                        FormAutobus.cbGaraza.SelectedValue = reader["garazaID"].ToString();
                        FormAutobus.cbPolazak.SelectedValue = reader["polazakID"].ToString();

                        FormAutobus.ShowDialog();
                    }
                    else if (CurrentTable.Equals(SelectTipKarte))
                    {
                        TipKarte FormTipKarte = new TipKarte(update, row);
                        FormTipKarte.txtNaziv.Text = reader["Naziv"].ToString();
                        FormTipKarte.ShowDialog();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nije selektovan ni jedan red!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void btnObrisi_Click_1(object sender, RoutedEventArgs e)
        {
            if (CurrentTable.Equals(SelectBlagajnik))
            {
                DeleteData(DeleteBlagajnik);
                loadData(SelectBlagajnik);
            }
            else if (CurrentTable.Equals(SelectZona))
            {
                DeleteData(DeleteZona);
                loadData(SelectZona);
            }
            else if (CurrentTable.Equals(SelectKupac))
            {
                DeleteData(DeleteKupac);
                loadData(SelectKupac);
            }
            else if (CurrentTable.Equals(SelectPolazak))
            {
                DeleteData(DeletePolazak);
                loadData(SelectPolazak);
            }
            else if (CurrentTable.Equals(SelectGaraza))
            {
                DeleteData(DeleteGaraza);
                loadData(SelectGaraza);
            }
            else if (CurrentTable.Equals(SelectKarta))
            {
                DeleteData(DeleteKarta);
                loadData(SelectKarta);
            }
            else if (CurrentTable.Equals(SelectRezervacija))
            {
                DeleteData(DeleteRezervacija);
                loadData(SelectRezervacija);
            }
            else if (CurrentTable.Equals(SelectStatus))
            {
                DeleteData(DeleteStatus);
                loadData(SelectStatus);
            }
            else if (CurrentTable.Equals(SelectAutobus))
            {
                DeleteData(DeleteAutobus);
                loadData(SelectAutobus);
            }
            else if (CurrentTable.Equals(SelectTipKarte))
            {
                DeleteData(DeleteTipKarte);
                loadData(SelectTipKarte);
            }
        }

        private void DeleteData(string deleteQuery)
        {
            try
            {
                connection.Open();
                row = (DataRowView)dataGridCentralni.SelectedItems[0];
                MessageBoxResult result = MessageBox.Show("Da li ste sigurni da zelite da ovo obrisete?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = connection
                    };
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = deleteQuery + "@ID";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nije selektovan ni jedan red!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Ima povezanih podataka sa drugim tabelama!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
    }
}