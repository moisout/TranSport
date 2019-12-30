using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TranSport
{
    /// <summary>
    /// Summary description for Authentication
    /// </summary>
    public class Authentication : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        private Dictionary<string, string> _credentials = new Dictionary<string, string> {
            {"spieler", "1234"},
            {"fahrer", "1234"},
            {"trainer", "1234"}
        };

        public void ProcessRequest(HttpContext context)
        { 
            context.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:8080");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST");
            context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, Access-Control-Allow-Origin");
            context.Response.ContentType = "application/json";
            string jsonResponse = null;

            string strJson = new System.IO.StreamReader(context.Request.InputStream).ReadToEnd();

            var loginUser = JsonConvert.DeserializeObject<User>(strJson);

            if (!string.IsNullOrEmpty(loginUser.Password) && !string.IsNullOrEmpty(loginUser.Email))
            {
                if (context.Session["email"] == null)
                {
                    string email = loginUser.Email;
                    string password = loginUser.Password;

                    if (_credentials.ContainsKey(email))
                    {
                        if (_credentials[email] == password)
                        {
                            string sessionId = context.Session.SessionID;
                            context.Session["email"] = loginUser.Email;

                            var response = new
                            {
                                status = "Login erfolgreich",
                                sessionId
                            };

                            jsonResponse = JsonConvert.SerializeObject(response);
                            context.Response.StatusCode = 200;
                        }
                        else
                        {
                            var response = new
                            {
                                status = "Error",
                                error = "Falsches Passwort"
                            };

                            jsonResponse = JsonConvert.SerializeObject(response);
                            context.Response.StatusCode = 401;
                        }
                    }
                    else
                    {
                        var response = new
                        {
                            status = "Error",
                            error = "Nutzer existiert nicht"
                        };

                        jsonResponse = JsonConvert.SerializeObject(response);
                        context.Response.StatusCode = 404;
                    }
                }
                else
                {
                    var response = new
                    {
                        status = "Error",
                        error = "Bereits eingeloggt"
                    };

                    jsonResponse = JsonConvert.SerializeObject(response);
                    context.Response.StatusCode = 403;
                }
            }
            else
            {
                var response = new
                {
                    status = "Error",
                    error = "Falsche Parameter"
                };

                jsonResponse = JsonConvert.SerializeObject(response);
                context.Response.StatusCode = 400;
            }

            context.Response.Write(jsonResponse != null ? jsonResponse : "");
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}