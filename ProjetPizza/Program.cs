using System.ComponentModel.DataAnnotations.Schema;
Console.OutputEncoding = System.Text.Encoding.UTF8;

var listePizzas = new List<Pizza>()
{
    new Pizza("4 fromages", 11.5f, true),
    new Pizza("margherita", 8f, true),
    new Pizza("indienne", 12.5f, false),
    new Pizza("calzone", 11.5f, true),
    new Pizza("mexicaine", 13.5f, false)
};

foreach (var pizza in listePizzas) {
    pizza.Afficher(); 
};

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

    private static string FormaterNomPizza(string s)
    {
        string minuscules = s.ToLower();
        string majuscules = s.ToUpper();
        string resultat = majuscules[0] + minuscules[1..];
        return resultat;
    }
    public void Afficher()
    {
        string IndicationVege = vegetarienne ? " (V) " : ";";
        string nomAffiche = FormaterNomPizza(nom);
        Console.WriteLine(nomAffiche + IndicationVege + " - " + prix + "€");
    }
}


