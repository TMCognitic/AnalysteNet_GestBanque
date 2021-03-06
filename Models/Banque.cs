using System.Collections.Generic;

namespace Models
{
    public class Banque
    {
        private Dictionary<string, Compte> _comptes = new Dictionary<string, Compte>();
        public string Nom { get; set; }

        public Compte this[string numero]
        {
            get { return _comptes[numero]; }
        }

        public void Ajouter(Compte compte)
        {
            if (compte == null)
                return;

            _comptes.Add(compte.Numero, compte);
        }

        public void Supprimer(string numero)
        {
            _comptes.Remove(numero);
        }

        public double AvoirDesComptes(Personne titulaire)
        {
            double total = 0D;

            foreach (Compte compte in _comptes.Values)
            {
                if (compte.Titulaire == titulaire)
                {
                    total += compte;
                }
            }

            return total;
        }
    }
}
