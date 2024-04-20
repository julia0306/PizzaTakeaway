using System.ComponentModel.DataAnnotations.Schema;
Console.OutputEncoding = System.Text.Encoding.UTF8;

var pizzas = new List<Pizza>()
{
    new Pizza("4 fromages", 11.5f, true, new List<string> { "tomate", "champignons", "oignons", "mozzarella", "cantal", "gorgonzola", "edam" }),
    new Pizza("margherita", 8f, true, new List < string > { "mozzarella", "tomate", "champignons", "oignons", "poivrons" }),
    new Pizza("indienne", 12.5f, false, new List < string > { "mozzarella", "sauce tomate","curry", "poulet", "champignons", "oignons" }),
    new Pizza("calzone", 11.5f, true, new List < string > { "mozzarella", "tomate", "champignons", "oignons", "cheddar" }),
    new Pizza("mexicaine", 13.5f, false, new List < string > { "mozzarella", "tomate", "merguez", "poulet", "épices","champignons", "oignons", }),
    new PizzaPersonnalisee()
};

foreach (var pizza in pizzas)
{
    pizza.Afficher();
};


class PizzaPersonnalisee : Pizza
{
    static int nbPizzaPersonnalisee = 0;

    public PizzaPersonnalisee() : base("Personnalisee", 5, false, null)
    {
        nbPizzaPersonnalisee++;
        nom = "Personnalisee" + nbPizzaPersonnalisee;

        ingredients = new List<string>();
        while (true)
        {
            Console.Write("Quels ingrédients désirez-vous sur votre pizza " +nbPizzaPersonnalisee + "? (ENTRER pour terminer)");
            var ingredient = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ingredient))
            {
                break;
            }
            if (ingredients.Contains(ingredient))
            {
                Console.WriteLine("Cet ingrédient est déjà présent dans la liste d'ingrédients.");
            }
            else {
                ingredients.Add(ingredient);
                Console.WriteLine(string.Join(", ", ingredients));
            }
            Console.WriteLine();
        }

        prix = 5 + ingredients.Count * 1.5f;

    }

}
class Pizza
{
    protected string nom;
    public float prix { get; protected set; }
    public bool vegetarienne { get; private set; }

    public List<string> ingredients { get; protected set; }
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


