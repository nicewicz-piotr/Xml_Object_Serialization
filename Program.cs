using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Xml;

namespace PracaZSerializacjaZadadnie
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Ksztalt> listaksztaltow = new List<Ksztalt>{
                new Kolo {Promien = 2.5, Kolor = "czerwony"},
                new Prostokat {Wysokosc = 20, Szerokosc = 10, Kolor = "niebieski"},
                new Kolo {Promien = 8, Kolor = "zielony"},
                new Kolo {Promien = 12.3, Kolor = "purprowy"},
                new Prostokat {Wysokosc = 45, Szerokosc = 18, Kolor = "niebieski"},

            };

            string sciezka = Path.Combine(Environment.CurrentDirectory, "ksztalty.xml");

            FileStream strumienpliku = File.Create(sciezka);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Ksztalt>), new XmlRootAttribute("Kształty"));

            //XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //namespaces.Add("ppp", "https://johnlnelson.com/namespaces/sample");

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new ASCIIEncoding();
            settings.Indent = true;

            //serializer.Serialize(strumienpliku, listaksztaltow, namespaces);
            serializer.Serialize(strumienpliku, listaksztaltow);

            strumienpliku.Close();

            strumienpliku = File.Open(sciezka, FileMode.Open);

            List<Ksztalt> xmlodczyt = (List<Ksztalt>)serializer.Deserialize(strumienpliku);

            foreach (Ksztalt item in xmlodczyt)
                Console.WriteLine($"{item.GetType().Name} jest {item.Kolor} i zajmuje obszar {item.Pole}");

            strumienpliku.Close();

            Console.WriteLine("Zapisano w pliku {0} zajmuje miejsce {1} bajtów", new FileInfo(sciezka).Name, new FileInfo(sciezka).Length);


        }
    }
}
