using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Domain.Interfaces
{
    public interface IApiKeyValidator
    {
        public bool IsValidApiKey(string apiKey);
    }
}
