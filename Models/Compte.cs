using System;

namespace Models
{
    public abstract class Compte : ICustomer, IBanker
    {
        public static double operator +(double total, Compte compte)
        {
            return (total < 0 ? 0 : total) + (compte.Solde < 0 ? 0 : compte.Solde);
        }

        private string _numero;
        private double _solde;
        private Personne _titulaire;

        public string Numero
        {
            get
            {
                return _numero;
            }

            private set
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

        public Personne Titulaire
        {
            get
            {
                return _titulaire;
            }

            private set
            {
                _titulaire = value;
            }
        }

        public Compte(string numero, Personne titulaire)
        {
            Numero = numero;
            Titulaire = titulaire;
        }

        public Compte(string numero, Personne titulaire, double solde)
            : this(numero, titulaire)
        {
            Solde = solde;
        }

        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException("montant invalide!");
            }

            Solde += montant;
        }

        public virtual void Retrait(double montant)
        {
            Retrait(montant, 0);
        }

        private protected void Retrait(double montant, double ligneDeCredit)
        {
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException("montant invalide!");
            }

            if (Solde - montant < -ligneDeCredit)
            {
                throw new SoldeInsuffisantException();
            }

            Solde -= montant;
        }

        protected abstract double CalculInteret();

        public void AppliquerInteret()
        {
            double interet = CalculInteret();
            Console.WriteLine($"J'applique un intérêt de {interet} au compte {Numero}");
            Solde += interet;
        }
    }
}