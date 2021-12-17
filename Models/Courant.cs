using System;

namespace Models
{
    public class Courant : Compte
    {
        private double _ligneDeCredit;

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

        public override void Retrait(double montant)
        {
            Retrait(montant, LigneDeCredit);
        }
    }
}