using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA231126
{
    class Laptop
    {
        public int Azonosito { get; set; }
        public string ProcesszorString { get; set; }
        public double ProcesszorSeb { get; set; }
        public string Oprendszer { get; set; }
        public string GyartoModellString { get; set; }
        public string Gyarto { get; set; }
        public double Aksi { get; set; }
        public double suly { get; set; }
        public string VezetekNelkuliString { get; set; }
        public List<string> VezetékNelkuli { get; set; }

        public Laptop(string sor)
        {
            var atmeneti = sor.Split('|');
            this.Azonosito = Convert.ToInt32(atmeneti[0]);
            this.ProcesszorString = atmeneti[1];
            var processzorSeb = atmeneti[1].Split(' ');
            this.ProcesszorSeb = Convert.ToDouble(processzorSeb[processzorSeb.Length - 1]);
            this.Oprendszer = atmeneti[2];
            this.GyartoModellString = atmeneti[3];
            var gyartoModell = atmeneti[3].Split(' ');
            this.Gyarto = gyartoModell[0];
            this.Aksi = Convert.ToDouble(atmeneti[4]);
            this.suly = Convert.ToDouble(atmeneti[5]);
            this.VezetekNelkuliString = atmeneti[6];
            var vezetekNelkuli = atmeneti[6].Split(',');
            this.VezetékNelkuli = new();
            for (int i = 0; i < vezetekNelkuli.Length; i++)
            {
                this.VezetékNelkuli.Add(vezetekNelkuli[i]);
            }
        }

        public override string ToString()
        {
            return $"Azonosító : {this.Azonosito} \nProcesszor típusa és sebessége: {this.ProcesszorString} \nOperációs rendszer: {this.Oprendszer} \nGyártó és modell: {this.GyartoModellString}\nAkkumulátor élettartama: {this.Aksi} \nSúlya: {this.suly} kg \nVezeték nélküli kapcsolatok: {this.VezetekNelkuliString}\n"; 
        }

        public double kgToGramm() 
        {
            return suly * 1000;
        }
    }
}
