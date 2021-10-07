using LeaveAppApi.Models;
using PostmarkDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAppApi.Helper
{
    public class Helper
    {
        public static void SendLoginCredential(User user, string PlainPassword)
        {
            // user.Password = PlainPassword;
            standardResonse response = new standardResonse();
            try
            {
                //string TemplateAlias = "code-your-own-6";
                var body = new Dictionary<string, object>()
                    {

                        { "Name",   char.ToUpper(user.FirstName[0]) + user.FirstName.Substring(1)},
                        { "Password", PlainPassword},
                        { "Email", user.Email },
                        //{ "TemplateAlias", TemplateAlias}
                       // {"temp_id", 23812040}
                    };

                var result = SendLoginViaPostmark(body);

                if (result == "success")
                {
                    response.STATUS = "success";
                    response.DESCRIPTION = "Email notification sent.";
                    response.DATA = null;
                }
                else
                {
                    response.STATUS = "fail";
                    response.DESCRIPTION = "Mail notification failed";
                }
            }
            catch (Exception ex)
            {
                response.STATUS = "error";
                response.DESCRIPTION = ex.Message;
            }
        }
        public static string SendLoginViaPostmark(Dictionary<string, object> body)
        {
            try
            {
                string email;
                email = body["Email"].ToString();
                //string TemplateAlias = body["TemplateAlias"].ToString();
                // long templateID = Convert.ToInt64(body["temp_id"]);


                var message = new TemplatedPostmarkMessage
                {
                    From = "sosamuelolatunji@gmail.com",
                    To = email,
                    Bcc = "samnellu4u@yahoo.com",
                    TemplateAlias = "code-your-own-9",
                    //TemplateAlias = TemplateAlias,
                    //TemplateId = templateID,
                    TemplateModel = new Dictionary<string, object>
                        {
                           { "Leave_Portal", "Leave Portal" },
                           { "name", body["Name"].ToString()},
                           { "email", body["Email"].ToString()},
                           { "password", body["Password"].ToString()},
                        },
                };

                var client = new PostmarkClient("542b0f9e-3ebf-4a7d-8dce-29f148428d5d");

                var response = client.SendMessageAsync(message);

                if (response.IsFaulted)
                {
                    return response.Result.Message;
                }

                return "success";
            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
