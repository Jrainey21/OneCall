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
            MyClass myClass = JsonConvert.DeserializeObject<MyClass>(jsonText);
            
            //This section was done afterwards because of a few errors I was receiving. I was trying to go frrom json to xml but had extra characters.
            Accounting acc1 = new Accounting()
            {
                FirstName = myClass.Accounting[0].FirstName,
                LastName = myClass.Accounting[0].LastName,
                Age = myClass.Accounting[0].Age
            };
            Accounting acc2 = new Accounting()
            {
                FirstName = myClass.Accounting[1].FirstName,
                LastName = myClass.Accounting[1].LastName,
                Age = myClass.Accounting[1].Age
            };
            Sale sales1 = new Sale()
            {
                FirstName = myClass.Sales[0].FirstName,
                LastName = myClass.Sales[0].LastName,
                Age = myClass.Sales[0].Age
            };
            Sale sales2 = new Sale()
            {
                FirstName = myClass.Sales[1].FirstName,
                LastName = myClass.Sales[1].LastName,
                Age = myClass.Sales[1].Age
            };

            //Instantiating IT Employee objects. billyBob and jackJohnson variables.

            IT billyBob = new IT()
            {
                FirstName = "Bill",
                LastName = "Miller",
                Age = 25
            };
            IT jackJohnson = new IT()
            {
                FirstName = "Jack",
                LastName = "James",
                Age = 45
            };
           

            //Here we are creating a list of accountants. Running a loop through all of the accountants and inserting them in the created list. 
            List<Accounting> accountants = new List<Accounting>();
            for(var i = 0; i < myClass.Accounting.Count;i++)
            {
                accountants.Add(myClass.Accounting[i]);
            }
            //Calculating the average age of all of the accountants by running for loop through the accountant list.
            double totalAccountantAges = 0;
            for(int i = 0; i < accountants.Count; i++)
            {
                totalAccountantAges = totalAccountantAges + accountants[i].Age;
            }
            double avgAccountantAge = totalAccountantAges / accountants.Count;
            Console.WriteLine($"The average age of an accountant is {avgAccountantAge}.");
            ////////-------The first accountant is Jon Doe------/////////
                
            
            ///////////////////////////--SALES EMPLOYEE AGE///////////////////////////////////////////////////////////////////////////////////////
            ///Creating another list of Salesman.
            List<Sale> salesman = new List<Sale>();
            for (var i = 0; i < myClass.Sales.Count; i++)
            {
                salesman.Add(myClass.Sales[i]);
            }
            /////////////////////////////Calculating average age of sales department. 
            double totalSalesmenAges = 0;
            for (int i = 0; i < salesman.Count; i++)
            {
                totalSalesmenAges = totalSalesmenAges + salesman[i].Age;
            }
            double avgSalesmanAge = totalSalesmenAges / salesman.Count;
            Console.WriteLine($"The average age of a salesman is {avgSalesmanAge}.");
            

            /////////////////////////////////----IT EMPLOYEE AGE-----------/////////////
            /////Calculating average age of It specialists. I created an ITSpecialist list later in the application for the sort. 
            double it1Age = billyBob.Age;
            double it2Age = jackJohnson.Age;
             double averageAgeOfIT = (it1Age + it2Age) /2;
            Console.WriteLine($"The average age of IT department employee is {averageAgeOfIT}.");
            Console.WriteLine("-----------------------------------------------------------");

            //////////////////////////----SORTING BY AGE/////////////////////////////////////////////
            /////Printing the first employee in each department in list  before the sort
            Console.WriteLine("The first accountant is currently "+accountants[0].FirstName + " " + accountants[0].LastName + " Age " + accountants[0].Age);
            Console.WriteLine("The first salesman is currently " + salesman[0].FirstName + " " + salesman[0].LastName + " Age " + salesman[0].Age);
            
            //sort method takes two perameters that are compared to each other
            accountants.Sort((x, y) => y.Age.CompareTo(x.Age));

            //------The first accountant"accountant[0]" is now Mary Smith
            Console.WriteLine();
            Console.WriteLine("The following lines are after the list sort.");
            Console.WriteLine();
            Console.WriteLine("The first accountant is now "+accountants[0].FirstName + " " + accountants[0].LastName + " Age " + accountants[0].Age);

            salesman.Sort((x, y) => y.Age.CompareTo(x.Age));
            Console.WriteLine("The first salesman is now " + salesman[0].FirstName + " " + salesman[0].LastName + " Age " + salesman[0].Age);
            //Created list of IT department to run the sort.
            List<IT> itSpecialists = new List<IT> { billyBob,jackJohnson};
            Console.WriteLine("After List Creation of IT Department. before sort");
            Console.WriteLine("The first IT specialist is currently " + itSpecialists[0].FirstName + " " + itSpecialists[0].LastName + " Age " + itSpecialists[0].Age);
            itSpecialists.Sort((x, y) => y.Age.CompareTo(x.Age));
            Console.WriteLine("After Sort");
            Console.WriteLine("The first IT Specialist is now " + itSpecialists[0].FirstName + " " + itSpecialists[0].LastName + " Age " + itSpecialists[0].Age);
            Console.WriteLine("-----------------------------------------------------------");
            //Issues trying to loop through this list. Perhaps because I created the list by looping thru json instead of with objects I later created.


            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Newtonsoft.Json.Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("accounting");
                writer.WriteStartArray();
                writer.WriteStartObject();
                writer.WritePropertyName("firstName");
                writer.WriteValue("Mary");
                writer.WritePropertyName("lastName");
                writer.WriteValue("Smith");
                writer.WritePropertyName("age");
                writer.WriteValue(32);
                writer.WriteEndObject();
                writer.WriteStartObject();
                writer.WritePropertyName("firstName");
                writer.WriteValue("John");
                writer.WritePropertyName("lastName");
                writer.WriteValue("Doe");
                writer.WritePropertyName("age");
                writer.WriteValue(23);
                writer.WriteEndObject();
                writer.WriteEnd();
                //writer.WriteEndObject();


                //writer.WriteStartObject();
                writer.WritePropertyName("sales");
                writer.WriteStartArray();
                writer.WriteStartObject();
                writer.WritePropertyName("firstName");
                writer.WriteValue("Jim");
                writer.WritePropertyName("lastName");
                writer.WriteValue("Galley");
                writer.WritePropertyName("age");
                writer.WriteValue(41);
                writer.WriteEndObject();
                writer.WriteStartObject();
                writer.WritePropertyName("firstName");
                writer.WriteValue("Sally");
                writer.WritePropertyName("lastName");
                writer.WriteValue("Green");
                writer.WritePropertyName("age");
                writer.WriteValue(27);
                writer.WriteEndObject();
                writer.WriteEnd();
                //writer.WriteEndObject();


                //writer.WriteStartObject();
                writer.WritePropertyName("it");
                writer.WriteStartArray();
                writer.WriteStartObject();
                writer.WritePropertyName("firstName");
                writer.WriteValue("Jack");
                writer.WritePropertyName("lastName");
                writer.WriteValue("James");
                writer.WritePropertyName("age");
                writer.WriteValue(45);
                writer.WriteEndObject();
                writer.WriteStartObject();
                writer.WritePropertyName("firstName");
                writer.WriteValue("Bill");
                writer.WritePropertyName("lastName");
                writer.WriteValue("Miller");
                writer.WritePropertyName("age");
                writer.WriteValue(25);
                writer.WriteEndObject();
                writer.WriteEnd();
                //writer.WriteEndObject();

            }
            Console.WriteLine(sw);
            string data = sw.ToString();

            var xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
           Encoding.ASCII.GetBytes(data), new XmlDictionaryReaderQuotas()));

            //XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(data);
            Console.WriteLine(xml);
            xml.Save(@"C:\Users\josep\source\repos\OneCall\XmlOutput.xml");
            //xml.Save(@"XmlOutput.xml");

            string xmltext = File.ReadAllText(@"XmlOutput.xml");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmltext);

            string jsonFromXml = JsonConvert.SerializeXmlNode(doc);

            Console.WriteLine("This is the Json converted from the xml file XMLOutput.xml");
            Console.WriteLine();
            Console.WriteLine(jsonFromXml);
            // jsonFromXml is currently a json string
            string fileloc = @"C:\Users\josep\source\repos\OneCall\JsonOutput.json";
            //string fileloc = @"JsonOutput.json";
            //File.WriteAllText(fileloc, jsonFromXml);

            if (File.Exists(fileloc) == false)
            {
                File.WriteAllText(fileloc, jsonFromXml);
            }
            else
            {
                File.Delete(fileloc);
                File.WriteAllText(fileloc, jsonFromXml);
            }

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
