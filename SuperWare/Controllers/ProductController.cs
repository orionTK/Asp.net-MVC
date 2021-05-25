
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperWare.Models;
namespace SuperWare.Controllers
{
    public class ProductController : Controller
    {
       
        // GET: Product
        public ActionResult Index()
        {
            
            return View();
        }

      
    }
}