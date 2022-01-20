using LegacyApp.Models;
using LegacyApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.CreditProviders
{
    public class ImportantClientCreditLimitProvider : ICreditLimitProvider
    {
        private readonly IUserCreditService _userCreditService;

        public ImportantClientCreditLimitProvider(IUserCreditService userCreditService)
        {
            _userCreditService = userCreditService;
        }
        public string NameRequirement => "Important Client";

        public (bool HasCreditLimit, int CreditLimit) GetCreditLimits(User user)
        {
            var creditLimit = _userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
            return (true,creditLimit * 2);
        }
    }
}
