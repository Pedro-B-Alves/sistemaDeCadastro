using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SistemaDeCadastro.Model
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string idade { get; set; }
        public string sexo { get; set; }
    }
}
