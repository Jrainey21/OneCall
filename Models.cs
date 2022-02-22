using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OneCall
{
    public class Accounting
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }
    }

    public class Sale
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }
    }

    public class MyClass
    {
        [JsonProperty("accounting")]
        public List<Accounting> Accounting { get; set; }

        [JsonProperty("sales")]
        public List<Sale> Sales { get; set; }
        [JsonProperty("it")]
        public List<Sale> IT { get; set; }

    }

    public class IT
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        
        
    }
   
}
