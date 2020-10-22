using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCRUDAspNETMVCAuctionApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicCRUDAspNETMVCAuctionApp.Controllers
{
    public class CustomController : Controller
    {
        public override ViewResult View(object model)
        {
            if (string.IsNullOrEmpty(ViewBag.ErrorMessage))
                ViewBag.ErrorMessage = HttpContext.Session.GetString("ErrorMessage");
            return base.View(model);
        }
    }
}