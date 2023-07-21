using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio2_4Grupo5.Models
{
    public class FirmaModel
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public Byte[] Firma { get; set; }
    }
}
