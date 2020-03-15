using System;
namespace _02__Luniakina.Exceptions
{
    public class WrongEMailExc : Exception
    {
        public WrongEMailExc() : base("Wrong e-mail! Your e-mail has to be like this - joeschmoe@mydomain.com !")
        {
        }
    }
}
