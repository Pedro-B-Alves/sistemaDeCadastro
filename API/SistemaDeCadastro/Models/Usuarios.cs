using SistemaDeCadastro.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeCadastro.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A idade completo é obrigatória.")]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime Idade { get; set; }

        [Required(ErrorMessage = "O sexo completo é obrigatório.")]
        [StringLength(9, MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Sexo")]
        [Column("Sexo")]
        public string SexoString
        {
            get { return Sexo.ToString(); }
            private set { Sexo = value.ParseEnum<Sexo>(); }
        }

        [NotMapped]
        public Sexo Sexo { get; set; }
    }
}
