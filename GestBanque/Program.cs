using Models;

namespace GestBanque
{
    class Program
    {
        static void Main(string[] args)
        {            
            Personne thierry = new Personne()
            {
                Nom = "Morre",
                Prenom = "Thierry",
                DateNaiss = new DateTime(1974, 06, 05)
            };

            Courant courant = new Courant()
            {
                Numero = "00001",
                Titulaire = thierry,
                LigneDeCredit = 500
            };

            courant.Depot(500);
            courant.Depot(-500);
            courant.Retrait(700);
            courant.Retrait(700);
            courant.Retrait(-700);

            Console.WriteLine(courant.Solde);
        }
    }
}