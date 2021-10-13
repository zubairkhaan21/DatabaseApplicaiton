using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseApplicaiton
{
    public partial class SignUp : Form

    {
        DBAccess dBAccess = new DBAccess();
        DataTable dataTable = new DataTable();
        public SignUp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textEmail.Text;
            string passwrod = textPassword.Text;

            SqlCommand insrtQuery = new SqlCommand("insert into Users(Username,Password) values (@userName,@passwrod)");
            insrtQuery.Parameters.AddWithValue("@userName", userName);
            insrtQuery.Parameters.AddWithValue("@passwrod", passwrod);

            int row = dBAccess.executeQuery(insrtQuery);

            if (row == 1) {
                MessageBox.Show("Account Created Successfully");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textEmail.Text;
            string password = textPassword.Text;

            string query = "select * from Users where Username='"+username+"'AND Password = '"+password+"'";
            dBAccess.readDatathroughAdapter(query,dataTable);

            if(dataTable.Rows.Count == 1) {
                MessageBox.Show("  Successfully");

                dBAccess.closeConn();

            }
        }
    }
}
