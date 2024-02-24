using System.ComponentModel.DataAnnotations.Schema;
Console.OutputEncoding = System.Text.Encoding.UTF8;

var listePizzas = new List<Pizza>()
{
    new Pizza("4 fromages", 11.5f, true, new List<string> { "tomate", "champignons", "oignons", "mozzarella", "cantal", "gorgonzola", "edam" }),
    new Pizza("margherita", 8f, true, new List < string > { "mozzarella", "tomate", "champignons", "oignons", "poivrons" }),
    new Pizza("indienne", 12.5f, false, new List < string > { "mozzarella", "sauce tomate","curry", "poulet", "champignons", "oignons" }),
    new Pizza("calzone", 11.5f, true, new List < string > { "mozzarella", "tomate", "champignons", "oignons", "cheddar" }),
    new Pizza("mexicaine", 13.5f, false, new List < string > { "mozzarella", "tomate", "merguez", "poulet", "épices","champignons", "oignons", })
};

foreach (var pizza in listePizzas) {
    pizza.Afficher(); 
};

class Pizza
{
    string nom { get; set; }
    float prix { get; set; }
    bool vegetarienne {  get; set; }

    List<string> ingredients { get; set; }
    public Pizza(string nom, float prix, bool vegetarienne, List<string> ingredients)
    {
        this.nom = nom;
        this.prix = prix;
        this.vegetarienne = vegetarienne;
        this.ingredients = ingredients;
    }

    private static string FormaterEcriture(string s)
    {
        if (string.IsNullOrEmpty(s))
            return s;
        string minuscules = s.ToLower();
        string majuscules = s.ToUpper();
        string resultat = majuscules[0] + minuscules[1..];
        return resultat;
    }
    public void Afficher()
    {
        string IndicationVege = vegetarienne ? " (V) " : "";
        string nomAffiche = FormaterEcriture(nom);
        List<string> ingredientsAffiches = new List<string>();
        foreach (var ingredient in ingredients)
        {
            ingredientsAffiches.Add(FormaterEcriture(ingredient));
        }
        Console.WriteLine(nomAffiche + IndicationVege + " - " + prix + "€");
        Console.WriteLine(string.Join(", ", ingredientsAffiches));
        Console.WriteLine();
    }
}


