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
    public partial class bill : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jidesh.DESKTOP-GK95PR8\source\repos\CoffeeShopManagement\CoffeeShopManagement\Coffee.mdf;Integrated Security=True");

        int j;
        int tot = 0;
        public bill()
        {
            InitializeComponent();
        }
        public void get_value(int i)
        {
            j = i;
        }
        private void bill_Load(object sender, EventArgs e)
        {
            
            if(con.State== ConnectionState.Open)
            {
            con.Close();
                
            }
            con.Open();
            DataSet1 ds = new DataSet1();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Orders where OrderId=" + j + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds.DataTable1);

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from orderdetails where OrderId="+ j +"";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(ds.DataTable2);
            da2.Fill(dt2);  

            tot = 0;
            foreach (DataRow dr2 in dt2.Rows)
            {
                tot = tot + Convert.ToInt32(dr2["total"].ToString());
            }
            CrystalReport1 my = new CrystalReport1();
            my.SetDataSource(ds);
            my.SetParameterValue("total", tot.ToString());
            crystalReportViewer1.ReportSource = my;
        }
    }
}
