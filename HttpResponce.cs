using Microsoft.Extensions.Logging;
using System;
using System.Configuration;
using System.Net;

namespace AvitoTelegramBot
{
    public class HttpResponce
    {
        private readonly string _url;
        private readonly ILogger _logger;

        public HttpResponce()
        {
            _url = ConfigurationManager.AppSettings["url"];
            _logger = Program.Logger.CreateLogger(nameof(HttpResponce));
        }

        public string GetHtmlString()
        {
            try 
            {
                using WebClient wc = new WebClient();
                return wc.DownloadString(_url);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return String.Empty;
            }
        }
    }
}
