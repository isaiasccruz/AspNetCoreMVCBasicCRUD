using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BasicCRUDAspNETMVCAuctionApp.Models
{
    public class LeilaoModel
    {
        public int Id { get; set; }
        public int IdUsuarioResponsavel { get; set; }
        [Required(ErrorMessage = "O nome do Leilao é Obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome do Leilao")]
        [StringLength(300, MinimumLength = 3)]
        public string NomeLeilao { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "ValorInicial")]
        [StringLength(100, MinimumLength = 3)]
        public string ValorInicial { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "ValorFinal")]
        [StringLength(100, MinimumLength = 3)]
        public string ValorFinal { get; set; }
        [Required(ErrorMessage = "A descrição do Estado do Item é Obrigatória", AllowEmptyStrings = false)]
        [Display(Name = "Estado do Item")]
        [StringLength(100, MinimumLength = 3)]
        public string EstadoDoItem { get; set; }
        [Required(ErrorMessage = "A Data de criação do Leilão é Obrigatória", AllowEmptyStrings = false)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        public DateTime DataAbertura { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        public DateTime? DataFechamento { get; set; }

        public LeilaoModel()
        {
        }
    }
}