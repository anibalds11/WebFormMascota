using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebFormMascota.Model;

namespace WebFormMascota.Controller
{
    public class MascotasController : ApiController
    {
        private SqlConnection cnn { get; set; }


        // GET api/<controller>
        public IEnumerable<Mascota> GetAll()
        {
            List<Mascota> lista = new List<Mascota>();
            Connect();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM mascota",cnn);
                SqlDataReader datos = command.ExecuteReader();
                while (datos.Read())
                {
                    Mascota mascota = new Mascota();
                    mascota.Id = int.Parse(datos[0].ToString());
                    mascota.Nombre = datos[1].ToString();
                    mascota.Raza = datos[2].ToString();
                    mascota.Edad = int.Parse(datos[3].ToString());
                    lista.Add(mascota);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Close();
            }
            return lista;
        }

        // GET api/<controller>/5
        public Mascota Get(int id)
        {
            Connect();
            Mascota mascota = new Mascota();
            try
            {
                
                SqlCommand command = new SqlCommand("SELECT * FROM mascota WHERE id=@id", cnn);
                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader datos = command.ExecuteReader();
                while (datos.Read())
                {
                    mascota.Id = int.Parse(datos[0].ToString());
                    mascota.Nombre = datos[1].ToString();
                    mascota.Raza = datos[2].ToString();
                    mascota.Edad = int.Parse(datos[3].ToString());

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Close();
            }
            return mascota;
        }

        // POST api/<controller>
        public void Post([FromBody] Mascota value)
        {
            Connect();
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO mascota(nombre,raza,edad) VALUES(@nombre,@raza,@edad)", cnn);
                command.Parameters.Add(new SqlParameter("@nombre", value.Nombre));
                command.Parameters.Add(new SqlParameter("@raza", value.Raza));
                command.Parameters.Add(new SqlParameter("@edad", value.Edad));
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Close();
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] Mascota value)
        {
            Connect();
            try
            {
                SqlCommand command = new SqlCommand("UPDATE mascota set nombre=@nombre,raza=@raza,edad=@edad WHERE id=@id", cnn);
                command.Parameters.Add(new SqlParameter("@nombre", value.Nombre));
                command.Parameters.Add(new SqlParameter("@raza", value.Raza));
                command.Parameters.Add(new SqlParameter("@edad", value.Edad));
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Close();
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            Connect();
            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM mascota WHERE id=@id", cnn);
                command.Parameters.Add(new SqlParameter("@id", id));
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Close();
            }
        }        

        private void Connect()
        {
            try
            {
                cnn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                cnn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void Close()
        {
            try
            {
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}