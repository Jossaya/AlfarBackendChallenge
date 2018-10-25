using AlfarBackendChallenge.WebAPI.Models;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;

namespace AlfarBackendChallenge.WebAPI.Controllers
{
    public class AlertController : ApiController
    {
        /// <summary>
        /// Web API Controller for handling alerts requests from MVC app,
        /// </summary>
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