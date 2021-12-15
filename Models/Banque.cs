﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Banque
    {
        private Dictionary<string, Courant> _comptes = new Dictionary<string, Courant>();
        public string Nom { get; set; }

        public Courant this[string numero]
        {
            get { return _comptes[numero]; }
        }

        public void Ajouter(Courant compte)
        {
            if (compte == null)
                return;

            _comptes.Add(compte.Numero, compte);
        }

        public void Supprimer(string numero)
        {
            _comptes.Remove(numero);
        }
    }
}
