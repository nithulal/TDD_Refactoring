using LegacyApp.Models;
using LegacyApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.CreditProviders
{
    public class DefaultCreditLimitProvider : ICreditLimitProvider
    {
        private readonly IUserCreditService _userCreditService;

        public DefaultCreditLimitProvider(IUserCreditService userCreditService)
        {
            _userCreditService = userCreditService;
        }
        public string NameRequirement => string.Empty;

        public (bool HasCreditLimit, int CreditLimit) GetCreditLimits(User user)
        {
            user.HasCreditLimit = true;
            var creditLimit = _userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
            return (true, creditLimit);
        }
    }
}
