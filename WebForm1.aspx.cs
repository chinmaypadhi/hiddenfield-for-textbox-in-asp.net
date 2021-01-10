using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace hiddenfield_for_textbox
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void update(string idhid)
        {
            string str = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "update1";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", idhid);
                cmd.Parameters.AddWithValue("@name", TextBox1.Text);
                cmd.Parameters.AddWithValue("@city", TextBox2.Text);

                int x = cmd.ExecuteNonQuery();
               
              
                    
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                
            }
        }

        protected void select(string param1)
        {
            string str = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd;
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "disp1";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", param1);

                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    HiddenField1.Value = rdr["id"].ToString();
                    TextBox1.Text = rdr["name"].ToString();
                    TextBox2.Text = rdr["city"].ToString();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            select(TextBox3.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            update(HiddenField1.Value);
        }


    }
}