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

namespace CoffeeShopManagement
{
    public partial class add_new_user : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jidesh.DESKTOP-GK95PR8\source\repos\CoffeeShopManagement\CoffeeShopManagement\Coffee.mdf;Integrated Security=True");
        public add_new_user()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from registration where username ='" + textBox3.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText="insert into registration values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"')";
                cmd1.ExecuteNonQuery();
                textBox1.Text = ""; textBox2.Text = "";
                textBox3.Text = ""; textBox4.Text = "";
                textBox5.Text = ""; textBox6.Text = ""; 
                MessageBox.Show("User added sucessfully");
            }
            else
            {
                MessageBox.Show("This username already exist please choose another");

            }
        }

        private void add_new_user_Load(object sender, EventArgs e)
        {
        if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
    }
}
