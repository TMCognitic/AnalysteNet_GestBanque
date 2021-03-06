using System;

namespace Models
{
    public class Epargne : Compte
    {
        private static double _taux;

        public static double Taux
        {
            get
            {
                return _taux;
            }

            set
            {
                _taux = value;
            }
        }

        private DateTime _dateDernierRetrait;        

        public DateTime DateDernierRetrait
        {
            get
            {
                return _dateDernierRetrait;
            }

            private set
            {
                _dateDernierRetrait = value;
            }
        }

        public Epargne(string numero, Personne titulaire)
            : base(numero, titulaire)
        {
        }

        public Epargne(string numero, Personne titulaire, double solde, DateTime dateDernierRetrait)
            : base(numero, titulaire, solde)
        {
            DateDernierRetrait = dateDernierRetrait;
        }

        public override void Retrait(double montant)
        {
            double ancienSolde = Solde;
            base.Retrait(montant); //<-- Retrait
            if(ancienSolde != Solde)
            {
                DateDernierRetrait = DateTime.Now;
            }
        }

        protected override double CalculInteret()
        {
            return Solde * Taux;
        }
    }
}