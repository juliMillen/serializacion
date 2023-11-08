using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace serializacion
{
    [Serializable]
    class Usuario
    {
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }

        public Usuario(string n, string c)
        {
            this.Nombre = n;
            this.Contrasenia = c;
        }
    }
}
