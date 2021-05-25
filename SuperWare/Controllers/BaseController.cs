using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperWare.Controllers
{
    public class BaseController : Controller
    {
       protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type=="success")
            {
                TempData["AlertType"] = "alert-succes";
            }
            else 
                if (type == "warning")
                {
                    TempData["AlertType"] = "alert-warning";
                }
                else
                    if (type == "error")
                    {
                        TempData["AlertType"] = "alert-danger";
                    }

        }
    }
}