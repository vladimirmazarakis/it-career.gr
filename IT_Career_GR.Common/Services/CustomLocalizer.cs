using IT_Career_GR.Common.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace IT_Career_GR.Common.Services
{
    public class CustomLocalizer : ICustomLocalizer
    {
        private readonly ResourceManager _resourceManager;
        public CustomLocalizer()
        {
            _resourceManager = new ResourceManager("IT_Career_GR.Common.Locales.Locale", typeof(CustomLocalizer).Assembly);
        }

        public string Culture { get; set; }

        public string this[string key] 
        { 
            get 
            {
                if (string.IsNullOrEmpty(Culture))
                {
                    return _resourceManager.GetString(key);
                }
                return _resourceManager.GetString(key, new CultureInfo(Culture));
            } 
        }
    }
}
