using System;

namespace Models
{
    public class Courant : Compte
    {
        private static double _tauxNegatif, _tauxPositif;

        public static double TauxNegatif
        {
            get
            {
                return _tauxNegatif;
            }

            set
            {
                _tauxNegatif = value;
            }
        }

        public static double TauxPositif
        {
            get
            {
                return _tauxPositif;
            }

            set
            {
                _tauxPositif = value;
            }
        }

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

        public Courant(string numero, Personne titulaire)
            :base(numero, titulaire)
        {
        }

        public Courant(string numero, Personne titulaire, double solde)
            : base(numero, titulaire, solde)
        {
        }

        public Courant(string numero, double ligneDeCredit, Personne titulaire)
            : base(numero, titulaire)
        {
            LigneDeCredit = ligneDeCredit;
        }

        public override void Retrait(double montant)
        {
            Retrait(montant, LigneDeCredit);
        }

        protected override double CalculInteret()
        {
            return Solde * ((Solde < 0) ? TauxNegatif : TauxPositif);
        }
    }
}