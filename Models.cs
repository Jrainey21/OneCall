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

    public class Sales
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }
    }

    public class Departments
    {
        [JsonProperty("accounting")]
        public List<Accounting> Accounting { get; set; }

        [JsonProperty("sales")]
        public List<Sales> Sales { get; set; }
        [JsonProperty("it")]
        public List<IT> IT { get; set; }

    }

    public class IT
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }

        public IT(string firstName,string lastName,int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;

        }
        
        
    }
   
}
