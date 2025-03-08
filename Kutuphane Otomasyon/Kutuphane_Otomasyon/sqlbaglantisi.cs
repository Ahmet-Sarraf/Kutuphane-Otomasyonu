using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Kutuphane_Otomasyon
{
    class sqlbaglantisi
    {
        public SqlConnection baglantı() // SQL Adresinin Tutulduğu ve Bağlantının Açıldığı Metot
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-IE2HASL\\SQLEXPRESS;Initial Catalog=Kutuphane_Otomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
            
        }


    }
}
