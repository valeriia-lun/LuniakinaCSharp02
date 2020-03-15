using System;
namespace _02__Luniakina.Exceptions
{
    public class BirthdayInTheFutureExc : Exception
    {
        public BirthdayInTheFutureExc(): base("Wrong date!Date of birth in the future!")
        {
        }
    }
}
