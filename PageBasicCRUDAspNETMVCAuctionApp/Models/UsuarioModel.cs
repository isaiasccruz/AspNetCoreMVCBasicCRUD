using Aplicacao.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces.InjecaoDependencia;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BasicCRUDAspNETMVCAuctionApp.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }        
        [Required(ErrorMessage = "O Nome do Usu�rio � Obrigat�rio")]
        [Display(Name = "Nome do Usuario")]
        [StringLength(300, MinimumLength = 3)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Login do Usu�rio � Obrigat�rio")]
        [Display(Name = "Login do Usuario")]
        [StringLength(50, MinimumLength = 3)]
        public string Login { get; set; }
        [Required(ErrorMessage = "A Senha do Usu�rio � Obrigat�ria")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }      
        public int IdPerfil { get; set; }
        public List<Perfil> Perfis { get; set; }
        [Required]
        public bool Ativo { get; set; }
        [Required]
        public bool Logado { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UltimaConexao { get; set; }        

        public UsuarioModel()
        {
            Perfis = new List<Perfil>();

            Perfis = IoC.Resolver<IPerfilAppServico>().ObterTodos().ToList();
        }
    }
}