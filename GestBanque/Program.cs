using Models;
using Models.ExoCast;

namespace GestBanque
{
    class Program
    {
        static void Main(string[] args)
        {
            Epargne.Taux = .045;
            Courant.TauxPositif = .03;
            Courant.TauxNegatif = .0975;

            Celsius c = new Celsius() { Temperature = 30 };
            Fahrenheit f = c; //Utilisation de l'opérateur de cast implicite
            Console.WriteLine($"30 °C = {f.Temperature} °F");

            c = (Celsius)f; //Utilisation de l'opérateur de cast explicite
            Console.WriteLine($"86 °F = {c.Temperature} °C");



            Banque banque = new Banque()
            {
                Nom = "Technobel Banking"
            };

            Personne thierry = new Personne("Morre", "Thierry", new DateTime(1974, 06, 05));
            Courant compte1 = new Courant("00001", 500, thierry);
            Epargne compte2 = new Epargne("00002", thierry);

            banque.Ajouter(compte1);
            banque.Ajouter(compte2);

            banque["00001"].Depot(500);
            banque["00002"].Depot(1500);

            try
            {
                banque["00001"].Depot(-500);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            banque["00001"].Retrait(700);
            banque["00001"].Retrait(100);
            
            try
            {
                banque["00001"].Retrait(-700);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                banque["00001"].Retrait(700);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            ((Courant)banque["00001"]).LigneDeCredit = 800;

            banque["00001"].AppliquerInteret();
            banque["00002"].AppliquerInteret();

            Console.WriteLine($"Avoir des Compte de {thierry.Nom} {thierry.Prenom} : {banque.AvoirDesComptes(thierry)}");
            Console.WriteLine(banque["00001"].Solde);
        }
    }
}