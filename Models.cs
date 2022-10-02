using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OneCall
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class Accounting
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }
        public List<Accounting> Accountants;

        [JsonProperty("age")]
        public int Age { get; set; }
        private static int Count = 0;
        private static int TotalAgesOfDepartmentEmployees = 0;
        private static int AverageAgeOfAllAccountants = 0;
        public Accounting(string firstName,string lastName,int age)
        {
            this.FirstName = firstName;
            this.LastName = LastName;
            this.Age = age;
            Count++;
            TotalAgesOfDepartmentEmployees = TotalAgesOfDepartmentEmployees + age;
         
           

        }
        public static int getCount() 
        { 
            return Count; 
        }
        public static int getTotalAgesOfDepartmentEmployees()
        {
            return TotalAgesOfDepartmentEmployees;
        }
        public static int getAvgAgeOfAllAccountants()
        {
            if(Count != 0)
            {
          AverageAgeOfAllAccountants=TotalAgesOfDepartmentEmployees / Count;
            return AverageAgeOfAllAccountants;
            }
            else { return 0; }
        }

        //public static double getAvgAgeOfAllAccountants(List<Accounting>employees)
        //{
        //    double totalAges = 0;
        //    double avgAge = 0;
        //    for (var i = 0; i < employees.Count; i++)
        //    {
        //        totalAges = totalAges + employees[i].Age;
        //    }
        //    avgAge = totalAges / employees.Count;
        //    return avgAge;
        //}
    }

    public class Sales
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }
        private static int Count = 0;
        private static int TotalAgesOfDepartmentEmployees = 0;
        private static int AverageAgeOfAllSalesman = 0;
        public Sales(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = LastName;
            this.Age = age;
            Count++;
            TotalAgesOfDepartmentEmployees = TotalAgesOfDepartmentEmployees + age;
        }
        public static int getCount()
        {
            return Count;
        }
        public static int getTotalAgesOfDepartmentEmployees()
        {
            return TotalAgesOfDepartmentEmployees;
        }
        public static int getAvgAgeOfAllAccountants()
        {
            if (Count != 0)
            {
                AverageAgeOfAllSalesman = TotalAgesOfDepartmentEmployees / Count;
                return AverageAgeOfAllSalesman;
            }
            else { return 0; }
        }
    }

    public class Departments
    {
        [JsonProperty("accounting")]
        public List<Accounting> Accounting { get; set; }

        [JsonProperty("sales")]
        public List<Sales> Sales { get; set; }
        [JsonProperty("it")]
        public List<IT> IT { get; set; }
       private static int numOfDepartments = 0;

        public Departments()
        {
            numOfDepartments++;
        }
        public static int getNumOfDepartments()
        {
            return numOfDepartments;
        }

        public static double getAvgAgeOfDepartment(List<Departments> employees)
        {
            double totalAges = 0;
            double avgAge = 0;
            for (var i = 0; i < employees.Count; i++)
            {
                totalAges = totalAges + employees[i].Accounting[i].Age;
            }
            avgAge = totalAges / employees.Count;
            return avgAge;
        }

    }

    public class IT
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }

        private static int Count = 0;
        private static int TotalAgesOfDepartmentEmployees = 0;
        private static int AverageAgeOfAllITSpecialists = 0;
        public IT(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = LastName;
            this.Age = age;
            Count++;
            TotalAgesOfDepartmentEmployees = TotalAgesOfDepartmentEmployees + age;
        }
        public static int getCount()
        {
            return Count;
        }
        public static int getTotalAgesOfDepartmentEmployees()
        {
            return TotalAgesOfDepartmentEmployees;
        }
        public static int getAvgAgeOfAllITSpecialists()
        {
            if (Count != 0)
            {
                AverageAgeOfAllITSpecialists = TotalAgesOfDepartmentEmployees / Count;
                return AverageAgeOfAllITSpecialists;
            }
            else { return 0; }
        }


    }
   
}
