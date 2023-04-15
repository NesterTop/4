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

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-AVGELME\STP;Initial Catalog=root;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            
            string login = textBox1.Text;
            string password = textBox2.Text;

            SqlCommand cmd = new SqlCommand($"select * from users where login = '{login}' and password = '{password}'", connection);
            dt.Load(cmd.ExecuteReader());


            if (dt.Rows.Count > 0)
            {
                Data.Login = login;
                new Form2().Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Такого пользователя не существует");
            }
        }
    }
}
