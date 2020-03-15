using System;
namespace _02__Luniakina.Exceptions
{
    public class TooOldExc : Exception
    {
        public TooOldExc() : base("Wrong date! You can't be that old!")
        {
        }
    }
}
