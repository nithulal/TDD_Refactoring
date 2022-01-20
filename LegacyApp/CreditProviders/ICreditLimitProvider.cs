using LegacyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.CreditProviders
{
    public interface ICreditLimitProvider
    {
       (bool HasCreditLimit, int CreditLimit) GetCreditLimits(User user);

        public string NameRequirement { get; }
    }
}
