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
    public partial class Delete : MetroFramework.Forms.MetroForm
    {
        public Delete()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        private void btn_delete_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Delete from register where studentid='"+txt_id.Text+"'",con);
            int i = cmd.ExecuteNonQuery();
            if (i == 1)
                MetroFramework.MetroMessageBox.Show(this,"Data Deleted", "Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
                MetroFramework.MetroMessageBox.Show(this, "Data cannot Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            con.Close();
            cmd.Dispose();


        }

        private void Delete_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-INVLEDJ;Initial Catalog=school10;Integrated Security=True");
        }

        private void btn_display_Click(object sender, EventArgs e)
        {
            this.Hide();
            Display obj = new Display();
            obj.Show();
        }
    }
}
