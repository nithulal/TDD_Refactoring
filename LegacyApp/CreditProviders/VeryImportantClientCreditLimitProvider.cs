using LegacyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.CreditProviders
{
    public class VeryImportantClientCreditLimitProvider : ICreditLimitProvider
    {
        private readonly ICreditLimitProvider _creditLimitProvider;
        public VeryImportantClientCreditLimitProvider(ICreditLimitProvider creditLimitProvider)
        {
            _creditLimitProvider = creditLimitProvider;
        }
        public string NameRequirement => "VeryImportantClient";

        public (bool HasCreditLimit, int CreditLimit) GetCreditLimits(User user)
        {
            return (false,0);
        }
    }
}
