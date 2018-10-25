using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using AfricasTalkingCS;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AlfarBackendChallenge.WebAPI.Models
{
      /// <summary>
    /// Integrate APIs for sms and emails
    /// </summary>
    public class Utility
    {
        const  string username = "sandbox";
        const  string apiKey   = "3eeb32d976cb08621eebb6b1d0600ede67037b5d4b67e2f685ef9278bf0d9ba1"; 
        string message = "I'm a lumberjack and its ok, I sleep all night and I work all day";

        public HttpStatusCode SendSMS(CustomerRequestModel model)
        {
            try
            {

                AfricasTalkingGateway gateway = new AfricasTalkingGateway(username: username, apikey: apiKey);
                var result = gateway.SendMessage(model.Address.Line1, message);

                return HttpStatusCode.OK;
            }
            catch (Exception)
            {

                return HttpStatusCode.InternalServerError;
            }
        }
        public async Task<HttpStatusCode> SendEmail(CustomerRequestModel model)
        {
            try
            {
                var apiKey ="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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("test@bigmetal", "Test User");
                var subject = "Sending with SendGrid is Fun";
                var to = new EmailAddress(model.EmailAddress, "Example User");
                var plainTextContent = "and easy to do anywhere, even with C#";
                var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
                return HttpStatusCode.OK;
            }
            catch (Exception exception)
            {

                return HttpStatusCode.InternalServerError;
            }

        }

    }
}