using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace register2
{
    class Database
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter da;

        public Database()
        {
            con = new SqlConnection("Data Source=DESKTOP-INVLEDJ;Initial Catalog=hospital;Integrated Security=True");

        }
        public void opencon()
        {
            con.Open();
        }
        public void closecon()
        {
            con.Close();
        }
        public int save_update_delete(string a)
        {
            opencon();
            cmd = new SqlCommand(a, con);
            int i = cmd.ExecuteNonQuery();
            closecon();
            return i;
        }

        public DataTable getdata(string a)
        {
            opencon();
            da = new SqlDataAdapter(a, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            closecon();
            return dt;
        }
    }
}
