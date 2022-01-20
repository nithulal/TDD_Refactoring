using LegacyApp.Models;
using LegacyApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.Validators
{
    public class UserValidator
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public UserValidator(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public  bool HasValidFullName(string firname, string surname)
        {
            return !string.IsNullOrEmpty(firname) || !string.IsNullOrEmpty(surname);
        }

        public  bool HasCreditLimitAndLimitIsLessThan500(User user)
        {
            return user.HasCreditLimit && user.CreditLimit < 500;
        }

        public bool IsUserAtleast21YearsOld(DateTime dateOfBirth)
        {
            var now = _dateTimeProvider.DateTimeNow;
            var age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            return age < 21;

        }

        public  bool HasValidEmail(string email)
        {
            return !email.Contains("@") && !email.Contains(".");
        }
    }
}
