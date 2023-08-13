using System;
using System.Collections.Generic;
using System.Text;

namespace PM2Ejercicio3_1.Models
{
    public class Alumnos
    {
        public Guid Id { get; set; }
        public string Nombres { set; get; }
        public string Apellidos { set; get; }
        public string Sexo { set; get; }
        public string Direccion { set; get; }

        public string RutaImagenFile { get; set; }
        public Uri RutaImagenFileUri { get; set; }
    }
}
