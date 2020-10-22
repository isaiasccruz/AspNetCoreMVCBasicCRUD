using Microsoft.AspNetCore.Http;
using SmartRandomAlphanumericGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BasicCRUDAspNETMVCAuctionApp.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Campo Obrigat�rio")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Campo Obrigat�rio")]
        public string Senha { get; set; }

        public LoginModel()
        {
        }
    }
}