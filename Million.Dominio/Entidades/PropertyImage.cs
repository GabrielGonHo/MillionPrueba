using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Million.Dominio.Entidades
{
    public class PropertyImage
    {
        public int IdPropertyImage { get; set; }
        public int IdProperty { get; set; }
        public Property? Property { get; set; } // Marcar como opcional para poder añadir la imagen sin tener que añadir la propiedad
        public string File { get; set; }
        public bool Enabled { get; set; }
    }
}
