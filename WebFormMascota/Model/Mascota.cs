using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormMascota.Model
{
    public class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
    }
}