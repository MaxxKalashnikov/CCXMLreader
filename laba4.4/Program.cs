using System;
using System.Xml;
using System.Collections.Generic;

namespace laba4_4
{
    public class CD 
    {
        public string name { get; set; }
        public string ARTIST { get; set; }
        public string COUNTRY { get; set; }
        public string COMPANY { get; set; }
        public string PRICE { get; set; }
        public string YEAR { get; set; }
        public void testclass()
        {
            Console.WriteLine($"Трек: {name} - {ARTIST} ({COMPANY}) {COUNTRY} (${PRICE}) - {YEAR} год");
        }
    }

    public class Catalog : CD
    {
        static class Deserialize
        {
            static void Main(string[] args)
            {
                var catalog = new List<CD>();
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("XMLFile1.xml");
                XmlElement? xRoot = xDoc.DocumentElement;                             
                
                if (xRoot != null)
                {
                    foreach (XmlElement xnode in xRoot)
                    {
                        CD CD = new CD();
                        XmlNode attr = xnode.Attributes.GetNamedItem("name");
                        CD.name = attr?.Value;

                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            if (childnode.Name == "ARTIST")
                                CD.ARTIST = childnode.InnerText;

                            if (childnode.Name == "COUNTRY")
                                CD.COUNTRY = childnode.InnerText;

                            if (childnode.Name == "COMPANY")
                                CD.COMPANY = childnode.InnerText;

                            if (childnode.Name == "PRICE")
                                CD.PRICE = childnode.InnerText;

                            if (childnode.Name == "YEAR")
                                CD.YEAR = childnode.InnerText;
                        }
                        catalog.Add(CD);
                    }
                    foreach (var CD in catalog)
                        Console.WriteLine($"Трек: {CD.name} - {CD.ARTIST} ({CD.COMPANY}) {CD.COUNTRY} (${CD.PRICE}) - {CD.YEAR} год");
                }
                Console.WriteLine("\n\n\nНажмите 1 чтобы вывести тестовый метод классов, нажмите любую цифру для выхода");
                int a = Convert.ToInt32(Console.ReadLine());
                if (a==1)
                {
                    foreach (var CD in catalog)
                        CD.testclass();
                    Console.ReadKey();
                }
                else { }
            }
        }
    }
}

            
    


