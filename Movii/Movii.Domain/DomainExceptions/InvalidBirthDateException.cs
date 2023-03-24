using System;

namespace Movii.Domain.DomainExceptions
{
    public class InvalidBirthDateException: Exception
    {
        public InvalidBirthDateException(DateTime birthDate): base(ModifyMessage(birthDate))
        {
        }
        
        private static string ModifyMessage(DateTime birthDate)
        {
            return $"Invalid birth date {birthDate}.";
        }
    }

}