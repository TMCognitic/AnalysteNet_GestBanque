using System;
using System.Runtime.Serialization;

namespace Models
{
    [Serializable]
    internal class SoldeInsuffisantException : Exception
    {
        public SoldeInsuffisantException() : base("Solde Insuffisant!!")
        {
        }
    }
}