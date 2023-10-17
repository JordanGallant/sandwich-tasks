using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    internal class Secrets
    {
         string API_KEY = "f0MastlmVn0YODooYoPfzK3A";
         string API_SECRET = "48uarB-jI8yOa4S7Qop1DclE6X4kLloimXTYBSqLInHno9fp";

        

        public string GetAPIKEY()
        {
            return this.API_KEY;
        }

        public string GETAPISECRET()
        {
            return this.API_SECRET;
        }
    }
        
    
}
