using System;

namespace Models
{
    public class Courant
    {
        private string _numero;
        private double _solde, _ligneDeCredit;
        private Personne _titulaire;

        public string Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

        public double Solde
        {
            get
            {
                return _solde;
            }

            private set
            {
                _solde = value;
            }
        }

        public double LigneDeCredit
        {
            get
            {
                return _ligneDeCredit;
            }

            set
            {
                if (value < 0)
                {
                    Console.WriteLine("La valeur de la ligne de crédit doit être positive");
                    return; //Erreur
                }

                _ligneDeCredit = value;
            }
        }

        public Personne Titulaire
        {
            get
            {
                return _titulaire;
            }

            set
            {
                _titulaire = value;
            }
        }

        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("Montant invalide");
                return; //Erreur
            }

            Solde += montant;
        }

        public void Retrait(double montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("Montant invalide");
                return; //Erreur
            }

            if (Solde - montant < -LigneDeCredit)
            {
                Console.WriteLine("Solde Insuffisant");
                return; //Erreur
            }

            Solde -= montant;
        }
    }
}