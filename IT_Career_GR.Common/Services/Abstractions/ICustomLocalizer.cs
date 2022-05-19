using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Career_GR.Common.Services.Abstractions
{
    public interface ICustomLocalizer
    {
        public string this[string key] { get; }

        public string Culture { get; set; }
    }
}
