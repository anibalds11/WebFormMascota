using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormMascota.Model;

namespace WebFormMascota
{
    public partial class MascotaCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtGuardar_Click(object sender, EventArgs e)
        {

            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Nombre", TextBox1.Text),
                new KeyValuePair<string, string>("Raza", TextBox2.Text),
                new KeyValuePair<string, string>("Edad",TextBox3.Text),

            });

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44359/api/");

            var consumeapi = hc.PostAsync("Mascotas",formContent);
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                Server.Transfer("~/MascotaList.aspx");
            }

        }
    }
}