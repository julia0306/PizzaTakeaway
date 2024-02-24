// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations.Schema;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Hello, World!");
var pizza1 = new Pizza("4 fromages", 11.5f, true);
pizza1.Afficher();


class Pizza
{
    string nom { get; set; }
    float prix { get; set; }
    bool vegetarienne {  get; set; }
    public Pizza(string nom, float prix, bool vegetarienne) 
    {
        this.nom = nom;
        this.prix = prix;
        this.vegetarienne = vegetarienne;
    }

    public void Afficher()
    {
        Console.WriteLine(nom + "-" + prix + "€");
    }
}


