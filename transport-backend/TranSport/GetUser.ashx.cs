using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace TranSport
{
    /// <summary>
    /// Summary description for GetUser
    /// </summary>
    public class GetUser : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:8080");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST");
            context.Response.AddHeader("Access-Control-Allow-Credentials", "true");
            context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, Access-Control-Allow-Origin");
            context.Response.ContentType = "application/json";
            string jsonResponse = null;
            var sessionId = context.Session.SessionID;

            if (context.Session["email"] != null)
            {
                var response = new
                {
                    email = context.Session["email"],
                    sessionId
                };

                jsonResponse = JsonConvert.SerializeObject(response);
                context.Response.StatusCode = 200;
            }
            else
            {
                var response = new
                {
                    error = "Nicht eingeloggt"
                };

                jsonResponse = JsonConvert.SerializeObject(response);
                context.Response.StatusCode = 401;
            }

            context.Response.Write(jsonResponse != null ? jsonResponse : "");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}