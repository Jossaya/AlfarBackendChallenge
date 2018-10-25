using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AfricasTalkingCS;
using AlfarBackendChallenge.WebAPI.Models;

namespace AlfarBackendChallenge.WebAPI.Controllers
{
    public class AlertController : ApiController
    {
       
        public ActionResult SendAlert(CustomerRequestModel model)
        {
            Utility utility = new Utility();
            var resultSendSms = utility.SendSMS(model);
            var resultSendEmail = utility.SendEmail(model);
            if (resultSendSms == HttpStatusCode.OK && resultSendEmail.Result == HttpStatusCode.OK)
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK); 
           }
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError); 
        }

    }
}