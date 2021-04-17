using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace register2
{
    public partial class Display : MetroFramework.Forms.MetroForm
    {
        public Display()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;

        private void Display_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-INVLEDJ;Initial Catalog=school10;Integrated Security=True");
        }

        private void btn_display_Click(object sender, EventArgs e)
        {
            con.Open();
            da = new SqlDataAdapter("Select studentid,student_name from register where studentid='"+txt_id.Text+"'",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            view_data.DataSource = dt;
            con.Close();
        }
    }
}
