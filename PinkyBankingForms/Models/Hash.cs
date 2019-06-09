using System;
using System.Collections.Generic;

namespace PinkyBankingForms.Models
{
    public class Hash
    {
        public string UserID { get; set; }
        public List<string> UserBiometricIDList { get; set; }
        public double Amount { get; set; }
    }
}