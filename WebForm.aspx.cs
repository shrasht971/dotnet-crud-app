using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace Application
{
    public partial class WebForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-0L311SU;initial catalog=institute;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                BindGender();
                BindHobbies();
            }

        }
        public void BindGender()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select*from gender", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            rblgender.DataValueField = "IGender";
            rblgender.DataTextField = "UGender";
            rblgender.DataSource = dt;
            rblgender.DataBind();
        }
        public void BindHobbies()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select*from hobbies", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            cblhobbies.DataValueField = "IHobbies";
            cblhobbies.DataTextField = "UHobbies";
            cblhobbies.DataSource = dt;
            cblhobbies.DataBind();
        }
        public void BindGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select*from student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvform.DataSource = dt;
            gvform.DataBind();
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string kk = "";
            for (int i = 0; i < cblhobbies.Items.Count; i++)
            {
                if (cblhobbies.Items[i].Selected == true)
                {

                    kk += cblhobbies.Items[i].Text + ",";
                }
            }
            kk = kk.TrimEnd(',');
            if (btnsubmit.Text == "Submit")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("insert into student(name,mobile,gender,hobbies)values('" + txtname.Text + "','" + txtmob.Text + "','" + rblgender.SelectedValue + "','" + kk + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();

            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update student set name='" + txtname.Text + "',mobile='" + txtmob.Text + "',gender='" + rblgender.SelectedValue + "',hobbies='" + kk +"' where id='" + ViewState["ID"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();



            }
        }
            protected void gvform_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "A")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from student where id='" + e.CommandArgument + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    BindGrid();
                }
                else if (e.CommandName == "B")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select*from student where id='" + e.CommandArgument + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    txtname.Text = dt.Rows[0]["name"].ToString();
                    txtmob.Text = dt.Rows[0]["mobile"].ToString();
                    rblgender.SelectedValue = dt.Rows[0]["gender"].ToString();
                    string[] arr = dt.Rows[0]["hobbies"].ToString().Split(',');
                    cblhobbies.ClearSelection();
                    for(int i = 0; i < cblhobbies.Items.Count; i++)
                    {
                        for(int j = 0;j<arr.Length;j++)
                        {
                            if (cblhobbies.Items[i].Text == arr[j]) 
                            {
                                cblhobbies.Items[i].Selected = true;    
                            }
                        }
                    }
                    btnsubmit.Text = "Update";
                    ViewState["ID"] = e.CommandArgument;
                }
            }
        }
    }





