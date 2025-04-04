using System;

namespace Magazyn
{

    public class Product
    {
        public string Nazwa { get; set; } 
        public int ilosc { get; set; }  
        public double cena { get; set; } 

        public Product(string nazwa, int ilosc, double cena)
        {
            Nazwa = nazwa;
            this.ilosc = ilosc;
            this.cena = cena;
        }
    }
}