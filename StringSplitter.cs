using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AvitoTelegramBot
{
    public class StringSplitter
    {
        private const string Pattern = "<div data-marker=\"item\" data-item-id=";

        private readonly ILogger _logger; 

        public StringSplitter()
        {
            _logger = Program.Logger.CreateLogger(nameof(StringSplitter));
        }

        public string[] GetAdsBody(string htmlString)
        {
            try
            {
                return Regex.Split(htmlString, Pattern);  // todo: redo))))
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
