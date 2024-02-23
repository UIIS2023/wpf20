using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace AutobuskaStanica
{
    internal class Konekcija
    {
        public SqlConnection KreirajKonekciju()
        {

            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder
            {
                DataSource = @"OMB-DTD-PR-5-L\SQLEXPRESS",
                InitialCatalog = "AutobuskaStanica",
                IntegratedSecurity = true
            };
            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);
            return konekcija;
        }
    }
}
