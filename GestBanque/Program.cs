using Models;
using Models.ExoCast;

namespace GestBanque
{
    class Program
    {
        static void Main(string[] args)
        {
            Celsius c = new Celsius() { Temperature = 30 };
            Fahrenheit f = c; //Utilisation de l'opérateur de cast implicite
            Console.WriteLine($"30 °C = {f.Temperature} °F");

            c = (Celsius)f; //Utilisation de l'opérateur de cast explicite
            Console.WriteLine($"86 °F = {c.Temperature} °C");



            Banque banque = new Banque()
            {
                Nom = "Technobel Banking"
            };

            Personne thierry = new Personne()
            {
                Nom = "Morre",
                Prenom = "Thierry",
                DateNaiss = new DateTime(1974, 06, 05)
            };

            Courant compte1 = new Courant()
            {
                Numero = "00001",
                Titulaire = thierry,
                LigneDeCredit = 500
            };

            Epargne compte2 = new Epargne()
            {
                Numero = "00002",
                Titulaire = thierry                
            };

            banque.Ajouter(compte1);
            banque.Ajouter(compte2);

            banque["00001"].Depot(500);
            banque["00002"].Depot(1500);
            //banque["00001"].Depot(-500);
            banque["00001"].Retrait(700);
            banque["00001"].Retrait(100);
            banque["00001"].Retrait(700);
            //banque["00001"].Retrait(-700);

            ((Courant)banque["00001"]).LigneDeCredit = 800; 

            Console.WriteLine($"Avoir des Compte de {thierry.Nom} {thierry.Prenom} : {banque.AvoirDesComptes(thierry)}");
            Console.WriteLine(banque["00001"].Solde);
        }
    }
}