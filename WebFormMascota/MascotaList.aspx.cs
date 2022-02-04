using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormMascota.Model;

namespace WebFormMascota
{
    public partial class MascotaList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<Mascota> mascotas = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44359/api/");

            var consumeapi = hc.GetAsync("Mascotas");
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if(readdata.IsSuccessStatusCode)
            {
                var displayrecords = readdata.Content.ReadAsAsync<IList<Mascota>>();
                displayrecords.Wait();
                mascotas = displayrecords.Result;
                GridView1.DataSource = mascotas;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string id = null;
            foreach(DictionaryEntry dic in e.Values)
            {
                Console.Write( "hola " + dic.Key);
                if(dic.Key.ToString() == "Id")
                {
                    id = dic.Value.ToString();
                }
            }

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44359/api/Mascotas/");
            
            var consumeapi = hc.DeleteAsync(id);
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                Server.Transfer("~/MascotaList.aspx");
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           /* con = new SqlConnection(ConfigurationSettings.AppSettings["connect"]);
            Label lblstid = (Label)GridView1.Rows[e.RowIndex].FindControl("lblstId");
            TextBox txtname = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName");
            TextBox txtclassname = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtClassName");
            TextBox txtrollno = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtRollNo");
            TextBox txtemailid = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEmailId");
            cmd.Connection = con;
            cmd.CommandText = "Update StudentRecord set Name='" + txtname.Text + "',ClassName='" + txtclassname.Text + "',RollNo='" + txtrollno.Text + "',EmailId='" + txtemailid.Text + "' where StId='" + lblstid.Text + "'";
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            BindData();
            con.Close();
           */
        }
    }
}