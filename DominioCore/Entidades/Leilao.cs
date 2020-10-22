using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dominio.Entidades
{
    public class Leilao
    {
        public int Id { get; set; }    
        public int IdUsuarioResponsavel { get; set; }
        public string NomeLeilao { get; set; }
        public string ValorInicial { get; set; }
        public string ValorFinal { get; set; }
        public string EstadoDoItem { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime DataAbertura { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? DataFechamento { get; set; }
    }
}
