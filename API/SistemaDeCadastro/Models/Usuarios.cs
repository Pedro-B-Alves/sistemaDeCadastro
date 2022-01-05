using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeCadastro.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Idade { get; set; }
        public string Sexo { get; set; }
    }
}
