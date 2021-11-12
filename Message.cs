using Microsoft.Extensions.Logging;
using System;
using System.Configuration;
using System.Net;

namespace AvitoTelegramBot
{
    public class MessageSender
    {
        private readonly string _token;
        private readonly ILogger _logger;

        public MessageSender()
        {
            _token = ConfigurationManager.AppSettings["token"];
            _logger = Program.Logger.CreateLogger(nameof(MessageSender));
        }

        public void SendMessage(string chatID, string message)
        {
            string url = $"https://api.telegram.org/bot{_token}/sendMessage?chat_id={chatID}&text={message}";
            try
            {
                using var webClient = new WebClient(); webClient.DownloadString(url);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
