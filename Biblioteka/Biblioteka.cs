using System;
using System.Xml.Serialization;

namespace PracaZSerializacjaZadadnie
{
    [XmlInclude(typeof(Kolo))]
    [XmlInclude(typeof(Prostokat))]
    [XmlRoot("Kształt")]
    public class Ksztalt
    {
        [XmlAttribute("Kolor")]
        public string Kolor { get; set; }

        public virtual double Pole { get; }

    }

    public class Prostokat : Ksztalt
    {
        [XmlAttribute("Wysokość")]
        public double Wysokosc { get; set; }
        
        [XmlAttribute("Szerokość")]
        public double Szerokosc {get; set; }

        public override double Pole 
        {
            get
            {
                return this.Wysokosc * this.Szerokosc; 
            }
        }

    }

    public class Kolo : Ksztalt
    {
        [XmlAttribute("Promień")]
        public double Promien { get; set; }     

        public override double Pole 
        {
            get
            {
                return this.Promien * this.Promien * Math.PI; 
            }
        }

    }
}
