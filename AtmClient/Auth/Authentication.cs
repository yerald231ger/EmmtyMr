using System;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace AtmClient.Auth
{
    using System.Configuration;
  
    class Authentication
    {
        private string _userName;
        private string _password;
        private readonly string _uriAuth;
        private Cookie _authCookie;
        
        public string UserName => _userName;
        public string Password => _password;
        public Cookie AuthCookie => _authCookie;

        public Authentication()
        {
            _uriAuth = AtmClientApp.AppConfig.ElementAt(1).Value;
        }

        public void Test()
        {
            Print.SubTitle("Checking Online Server");
            Print.Line("Checking");
            var uriTest = AtmClientApp.AppConfig.ElementAt(0).Value;
            var timer = new System.Timers.Timer();

            try
            {
                var request = WebRequest.CreateHttp(uriTest);
                timer = ProgresAwaiter.StartDot();
                var response = request.GetResponse();
                var headers = response.Headers;
                ProgresAwaiter.StopL(timer);
                Print.NewLine(response.ResponseUri);
                foreach (var key in headers.AllKeys)
                {
                    Print.NewLine($"{key}: {headers[key]}");
                }
                Print.NewLine($"Status Description: {((HttpWebResponse) response).StatusDescription}");
                var stream = response.GetResponseStream();
                if (stream != null)
                {
                    var reader = new StreamReader(stream);
                    var json = JsonConvert.DeserializeObject(reader.ReadToEnd());
                    Print.Success($"Site: {json}");

                    reader.Close();
                    stream.Close();
                }
                response.Close();
            }
            catch (UriFormatException)
            {
                Print.Warning("The Uri Wasn´t found");
            }
            catch (WebException e)
            {
                ProgresAwaiter.StopL(timer);
                Print.Error(e);
                Print.Higlight("Continue?...");
                if (!Scan.ReadDecision()) Environment.Exit(0);
            }
        }

        public bool LoggIn()
        {
            Print.SubTitle("Proccess Loggin");
            Print.Line("Enter UserName: ");
            _userName = Console.ReadLine();
            Print.Line("Enter Password: ");
            _password = Console.ReadLine();
            Print.Line();
            var request = WebRequest.CreateHttp(_uriAuth);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = new CookieContainer();

            var authCredentials = "Email=" + _userName + "&Password=" + _password;
            var bytes = System.Text.Encoding.UTF8.GetBytes(authCredentials);
            request.ContentLength = bytes.Length;
            
            try
            {
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }
            }
            catch (WebException e)
            {
                Console.Write("\r");
                Print.Error(e);
                return false;
            }

            Console.Write("\r");
            Print.Line("Getting AuthCookie");
            var timer1 = ProgresAwaiter.StartDot();
            try
            {
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    ProgresAwaiter.StopL(timer1);
                    if (response == null) throw new WebException("No hubo resupesta del servidor");
                    var headers = response.Headers;
                    Print.NewLine($"Response Uri: {response.ResponseUri}");
                    Print.NewLine($"Status Description: {response.StatusDescription}");
                    if (response.Cookies.Count > 0)
                    {
                        Print.NewLine("Cookies...");
                        foreach (var cookie in response.Cookies)
                        {
                            Print.NewLine($"Name: {cookie}");
                        }
                        _authCookie = response.Cookies[AtmClientApp.AppConfig.ElementAt(3).Value];
                    }
                    var success = (AuthCookie != null);
                    if (success)
                        Print.Success("Loggin Proccess Success");
                    else
                        Print.Error("Loggin Proccess Fail");
                    
                    return success;
                }
            }
            catch (WebException e)
            {
                Print.Error(e);
                return false;
            }
        }

        public bool LoggIn(string username, string password)
        {
            Print.SubTitle("Proccess Loggin");
            _userName = username;
            _password = password;
            Print.Line();
            var request = WebRequest.CreateHttp(_uriAuth);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = new CookieContainer();

            var authCredentials = "Email=" + _userName + "&Password=" + _password;
            var bytes = System.Text.Encoding.UTF8.GetBytes(authCredentials);
            request.ContentLength = bytes.Length;

            try
            {
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }
            }
            catch (WebException e)
            {
                Console.Write("\r");
                Print.Error(e);
                return false;
            }

            Console.Write("\r");
            Print.Line("Getting AuthCookie");
            var timer1 = ProgresAwaiter.StartDot();
            try
            {
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    ProgresAwaiter.StopL(timer1);
                    if (response == null) throw new WebException("No hubo resupesta del servidor");
                    var headers = response.Headers;
                    Print.NewLine($"Response Uri: {response.ResponseUri}");
                    Print.NewLine($"Status Description: {response.StatusDescription}");
                    if (response.Cookies.Count > 0)
                    {
                        Print.NewLine("Cookies...");
                        foreach (var cookie in response.Cookies)
                        {
                            Print.NewLine($"Name: {cookie}");
                        }
                        _authCookie = response.Cookies[AtmClientApp.AppConfig.ElementAt(3).Value];
                    }
                    var success = (AuthCookie != null);
                    if (success)
                        Print.Success("Loggin Proccess Success");
                    else
                        Print.Error("Loggin Proccess Fail");

                    return success;
                }
            }
            catch (WebException e)
            {
                Print.Error(e);
                return false;
            }
        }

    }


}

