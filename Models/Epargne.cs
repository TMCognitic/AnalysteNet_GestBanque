using System;

namespace Models
{
    public class Epargne : Compte
    {
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

        public override void Retrait(double montant)
        {
            double ancienSolde = Solde;
            base.Retrait(montant); //<-- Retrait
            if(ancienSolde != Solde)
            {
                DateDernierRetrait = DateTime.Now;
            }
        }
    }
}