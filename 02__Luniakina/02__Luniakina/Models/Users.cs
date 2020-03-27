using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace _02__Luniakina.Models
{
    public class Users
    {
        public List<Person> UsersList { get; set; }

        public Users()
        {
            
        }

        public static List<Person> GetList()
        {
            List<Person> Users = new List<Person>
            {
                new Person("Valerie", "Luniakina","2001-02-20","valerie@gmail.com"),
                new Person("Ilia", "Yatsyshyn","2001-06-12","ilia@gmail.com"),
                new Person("Sophie", "Olenyn","2001-06-06","sophie@gmail.com"),
                new Person("Anika", "Chirilova","2001-07-21","anika@gmail.com"),
        };
            return Users;
        }
    }
}
