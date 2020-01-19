using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.WebApi.Configuration
{
    public class CosmosDbOptions
    {
        public string AccountEndpoint { get; set; } = "";

        public string AccountKey { get; set; } = "";

        public string DatabaseName { get; set; } = "";
    }
}
