using System;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;

namespace OneCall
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
          
            string fileName = @"Data.json";
            //Opening the provided Json file and printing the Json string to the console. -----------------------------------
            string jsonText = File.ReadAllText(fileName);

            Console.WriteLine("This is the Json String from Data.json file");
            Console.WriteLine();
            Console.WriteLine(jsonText);

            //Deserializing the Json String into the myClass Object. Had to create classes that represented json format.
            //Used jsontocsharp converter. To correctly map classes.
            Departments departments = JsonConvert.DeserializeObject<Departments>(jsonText);

            //This section was done afterwards because of a few errors I was receiving. I was trying to go frrom json to xml but had extra characters.
            //Instantiating IT Employee objects. billyBob and jackJohnson variables.
            IT billyBob = new IT("Billy", "Bob", 25);
            IT jackJohnson = new IT("Jack", "Johnson", 45);
            List<Accounting> accountants = new List<Accounting>();
            double accountingTotal = 0;
            double accountingAvg = 0;
            for (var i = 0; i < departments.Accounting.Count; i++)
            {
                accountants.Add(departments.Accounting[i]);
                accountingTotal = accountingTotal + departments.Accounting[i].Age;
            }
                accountingAvg = accountingTotal / departments.Accounting.Count;
           // Console.WriteLine(accountingAvg);

            double salesmanTotal = 0;
            double salesmanAvg = 0;

            List<Sales> salesman = new List<Sales>();
            for (var i = 0; i < departments.Sales.Count; i++)
            {
                salesman.Add(departments.Sales[i]);
                salesmanTotal = salesmanTotal + departments.Sales[i].Age;
            }
                salesmanAvg = salesmanTotal / departments.Sales.Count;
          //  Console.WriteLine(salesmanAvg);
            List<IT> itGuys = new List<IT>();
            itGuys.Add(billyBob);
            itGuys.Add(jackJohnson);
           var itGuysTotal = 0;
            var itGuysAvg = 0;
            for (var i = 0; i < itGuys.Count; i++)
            {
                itGuysTotal = itGuysTotal + itGuys[i].Age;
            }
                itGuysAvg = itGuysTotal/itGuys.Count;
            Console.WriteLine($"The average age of an accountant is {accountingAvg}.");
            Console.WriteLine($"The average age of a salesman is {salesmanAvg}.");
            Console.WriteLine($"The average age of IT department employee is {itGuysAvg}.");

            accountants.Sort((x, y) => y.Age.CompareTo(x.Age));
            salesman.Sort((x, y) => y.Age.CompareTo(x.Age));
            itGuys.Sort((x, y) => y.Age.CompareTo(x.Age));
            foreach (var employee in accountants)
            {
                Console.WriteLine($"{employee.FirstName} is an accountant and {employee.Age} years old");
            }
            foreach (var employee in salesman)
            {
                Console.WriteLine($"{employee.FirstName} is a salesman and {employee.Age} years old");
            }
            foreach (var employee in itGuys)
            {
                Console.WriteLine($"{employee.FirstName} is an itSpecialist and {employee.Age} years old");
            }
            //XmlDocument doc= new XmlDocument();
            //XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(jsonText);
            //Console.WriteLine(doc);


           // var xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
           //Encoding.ASCII.GetBytes(data), new XmlDictionaryReaderQuotas()));

           // //XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(data);
           // Console.WriteLine(xml);
           // xml.Save(@"C:\Users\josep\source\repos\OneCall\XmlOutput.xml");
           // //xml.Save(@"XmlOutput.xml");

           // string xmltext = File.ReadAllText(@"XmlOutput.xml");
           // XmlDocument doc = new XmlDocument();
           // doc.LoadXml(xmltext);

           // string jsonFromXml = JsonConvert.SerializeXmlNode(doc);

           // Console.WriteLine("This is the Json converted from the xml file XMLOutput.xml");
           // Console.WriteLine();
           // Console.WriteLine(jsonFromXml);
           // // jsonFromXml is currently a json string
           // string fileloc = @"C:\Users\josep\source\repos\OneCall\JsonOutput.json";
           // //string fileloc = @"JsonOutput.json";
           // //File.WriteAllText(fileloc, jsonFromXml);

           // if (File.Exists(fileloc) == false)
           // {
           //     File.WriteAllText(fileloc, jsonFromXml);
           // }
           // else
           // {
           //     File.Delete(fileloc);
           //     File.WriteAllText(fileloc, jsonFromXml);
           // }

            Environment.Exit(0);


            //Created variables to store formatted serialized objects.
            //string accountant1 = JsonConvert.SerializeObject(acc1, Newtonsoft.Json.Formatting.Indented);
            //string accountant2 = JsonConvert.SerializeObject(acc2, Newtonsoft.Json.Formatting.Indented);
            //string salesman1= JsonConvert.SerializeObject(sales1, Newtonsoft.Json.Formatting.Indented);
            //string salesman2=JsonConvert.SerializeObject(sales2, Newtonsoft.Json.Formatting.Indented);
            //string strBillyBob = JsonConvert.SerializeObject(billyBob,Newtonsoft.Json.Formatting.Indented);
            //string strJackJohnson = JsonConvert.SerializeObject(jackJohnson,Newtonsoft.Json.Formatting.Indented);

            ////Attempted to add each string together before transitioning the Json to XML.
            ////Tried to use the lists but the method below wouldn't allow it. This is why I instantiated the objects. 
            //string totalObjects = accountant2 + accountant1 + salesman2 + salesman1 + strJackJohnson + strBillyBob;

            //string listAccountant = JsonConvert.SerializeObject(accountants,Newtonsoft.Json.Formatting.Indented);
            //string listSalesman= JsonConvert.SerializeObject(salesman,Newtonsoft.Json.Formatting.Indented);
            //string listIT= JsonConvert.SerializeObject(itSpecialists,Newtonsoft.Json.Formatting.Indented);
            //string totalLists = listAccountant + listSalesman + listIT;

            //Console.WriteLine(totalObjects);
            //This method unsuccessful.
            //XNode node = JsonConvert.DeserializeXNode(totalObjects, "Root");

            //var xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
            //Encoding.ASCII.GetBytes(totalObjects), new XmlDictionaryReaderQuotas()));
            //Console.WriteLine("-----------This is the XML converted from Json ");
            //Console.WriteLine();
            //    Console.WriteLine(xml);
            //Console.WriteLine();


            //--------------Storing the XML, creatin a new File- XmlOutput.xml------------------
             //xml.Save(@"C:\Users\josep\source\repos\OneCall\XmlOutput.xml");
            //xml.Save(@"XmlOutput.xml");

            //--------------Reading XML file that was just created.
            //string xmltext = File.ReadAllText(@"C:\Users\josep\source\repos\OneCall\XmlOutput.xml");

            //string xmltext = File.ReadAllText(@"XmlOutput.xml");

            //-------------------Converting XML FIle Contents into Json string------------
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(xmltext);

            //string jsonFromXml = JsonConvert.SerializeXmlNode(doc);

            //Console.WriteLine("This is the Json converted from the xml file XMLOutput.xml");
            //Console.WriteLine();
            //Console.WriteLine(jsonFromXml);
            // jsonFromXml is currently a json string

            //FileStream fs = File.Create(@"C: \Users\josep\source\repos\OneCall\JsonOutput.json");

            //string fileloc = @"C:\Users\josep\source\repos\OneCall\JsonOutput.json";
            
            //string fileloc = @"JsonOutput.json";

            //If file location doesn't exist, create the json file and write the json string to the file. If it does exist then delete the file and create new one. 
            //if (File.Exists(fileloc) == false)
            //{
            //    File.WriteAllText(fileloc, jsonFromXml);
            //}
            //else
            //{
            //    File.Delete(fileloc);
            //    File.WriteAllText(fileloc, jsonFromXml);
            //}

            //Environment.Exit(0);
            
            //File.WriteAllText(fs,jsonFromXml);
            //XNode node = JsonConvert.DeserializeXNode(totalObjects, "Root");

            //Console.WriteLine(node);
            //Console.WriteLine(totalLists);

            ///////////////Converting Json to XML////////////////////////////////////////////
            //string newJson = File.ReadAllText(fileName);
            //XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(newJson);
            //Console.WriteLine(doc.OuterXml);
            //XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(listAccountant);
            //Console.WriteLine(doc);

            //I tried to grab the sorted lists but that wouldn't work. I serialized the IT department employee objects and concatenated them to the original Json file.

          
            //Console.WriteLine(JsonConvert.SerializeObject(billyBob, Formatting.Indented));

          

        }
       

        

    }
}
