using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Use apenas letras.")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O login é obrigatório.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O perfil é obrigatório.")]
        public int IdPerfil { get; set; }

        public bool Ativo { get; set; }

        public bool Logado { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UltimaConexao { get; set; }

        public Usuario()
        {
        }
    }

}
