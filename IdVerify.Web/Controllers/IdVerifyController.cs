using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using IdVerify.api;
using IdVerify.Web.Models;

namespace IdVerify.Web.Controllers
{
    public class IdVerifyController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            var id = new IDNumber();
            return View(id);
        }

        [HttpGet]
        public ActionResult ValidateId(string id)
        {
            var idno = new IDNumber();
            idno.IDnumber = id;
            var uri = Server.MapPath("~/api/id");
            var client = new HttpClient();
            var task = client.GetAsync(uri + "/" + id);  
      

                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                // New code:
                if (task.Result.IsSuccessStatusCode)
                {
                    idno.result = "ID is valid";
                }
                else
                {  idno.result = "ID is NOT valid";}
                   

           return View(idno);

         }
                
  

        [HttpGet]
        public ActionResult GenerateNewId()
        {
            IDNumber idno = new IDNumber();
            
            var uri = Server.MapPath("~/api/id");
            var client = new HttpClient();
            var task = client.GetAsync(uri);

            if (task.Result.IsSuccessStatusCode)
            {
                idno.IDnumber  =  task.Result.Content.ToString();
            }


            return View(idno);
        }


    }
}
