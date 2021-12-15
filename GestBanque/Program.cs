using Models;

namespace GestBanque
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Courant courant = new Courant()
            {
                Numero = "00001",
                Titulaire = thierry,
                LigneDeCredit = 500
            };

            banque.Ajouter(courant);
            banque["00001"].Depot(500);
            banque["00001"].Depot(-500);
            banque["00001"].Retrait(700);
            banque["00001"].Retrait(700);
            banque["00001"].Retrait(-700);

            Console.WriteLine(banque["00001"].Solde);
        }
    }
}