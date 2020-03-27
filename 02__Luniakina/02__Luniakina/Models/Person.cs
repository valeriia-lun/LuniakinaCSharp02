using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02__Luniakina.Exceptions;
using System.Text.RegularExpressions;


namespace _02__Luniakina.Models
{
    
    public class Person
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter your name!")]
        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your last name!")]
        [Display(Name = "LastName: ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your date of birth!")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth: ")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate{ get; set; }

        [Required(ErrorMessage = "Please enter your e-mail!")]
        [Display(Name = "E-mail: ")]
        public string EMail { get; set; }

        public int Age { get; set; }

        public string ZodiacSunSign { get; set; }

        public string ZodiacChineseSign { get; set; }

        public Person()
        {
        }

        public Person(string name, string lastName, string dateOfBirth, string email)
        {
            this.Name = name;
            DateTime dt = DateTime.ParseExact(dateOfBirth, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            this.BirthDate = dt;
            this.LastName = lastName;

            var regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
            + "@"
            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            if (!regex.IsMatch(email)) throw new WrongEMailExc();
            this.EMail = email;

            this.Age = CalculateAge(BirthDate);
            this.ZodiacSunSign = SunSign(dt);
            this.ZodiacChineseSign = ChineseZodiacSign(dt);
        }

        public Person(string name, string lastName, string email)
        {
            this.Name = name;
            this.LastName = lastName;
            this.EMail = email;
            this.BirthDate = default;
            this.Age = CalculateAge(BirthDate);
            this.ZodiacSunSign = SunSign(BirthDate);
            this.ZodiacChineseSign = ChineseZodiacSign(BirthDate);

        }


        public static int CalculateAge(DateTime BirthDate)
        {

            int YearsPassed = DateTime.Now.Year - BirthDate.Year;

            if (DateTime.Now.Month < BirthDate.Month ||
                (DateTime.Now.Month == BirthDate.Month &&
                DateTime.Now.Day < BirthDate.Day))
            {
                YearsPassed--;
            }
            if (DateTime.Today < BirthDate.Date) throw new BirthdayInTheFutureExc();
            if (YearsPassed > 135) throw new TooOldExc();

            return YearsPassed;
        }

        public static bool IsBirthday(DateTime BirthDate)
        {
            if (BirthDate.Month == DateTime.Now.Month)
            {
                if (BirthDate.Day == DateTime.Now.Day)
                {
                    return true;
                }
            }
            return false;
        }

        public static String SunSign(DateTime BirthDate)
        {
            int month = BirthDate.Month;
            int day = BirthDate.Day;

            if (month == 12 && day >= 22 ||
                month == 1 && day <= 22)
            {
                return ZodiacSignEnumeration.Capricorn.ToString();
            }

            if (month == 1 && day >= 21 ||
                month == 2 && day <= 18)
            {
                return ZodiacSignEnumeration.Aquarius.ToString();
            }

            if (month == 2 && day >= 19 ||
                month == 3 && day <= 20)
            {
                return ZodiacSignEnumeration.Pisces.ToString();
            }

            if (month == 3 && day >= 21 ||
                month == 4 && day <= 20)
            {
                return ZodiacSignEnumeration.Aries.ToString();
            }

            if (month == 4 && day >= 21 ||
                month == 5 && day <= 20)
            {
                return ZodiacSignEnumeration.Taurus.ToString();
            }

            if (month == 5 && day >= 21 ||
                month == 6 && day <= 21)
            {
                return ZodiacSignEnumeration.Gemini.ToString();
            }

            if (month == 6 && day >= 22 ||
                month == 7 && day <= 22)
            {
                return ZodiacSignEnumeration.Cancer.ToString();
            }

            if (month == 7 && day >= 23 ||
                month == 8 && day <= 23)
            {
                return ZodiacSignEnumeration.Leo.ToString();
            }

            if (month == 8 && day >= 24 ||
                month == 9 && day <= 23)
            {
                return ZodiacSignEnumeration.Virgo.ToString();
            }

            if (month == 9 && day >= 24 ||
                month == 10 && day <= 23)
            {
                return ZodiacSignEnumeration.Libra.ToString();
            }

            if (month == 10 && day >= 24 ||
                month == 11 && day <= 22)
            {
                return ZodiacSignEnumeration.Scorpio.ToString();
            }

            if (month == 11 && day >= 23 ||
                month == 12 && day <= 21)
            {
                return ZodiacSignEnumeration.Sagittarius.ToString();
            }

            return "Error";
        }

        public static String ChineseZodiacSign(DateTime BirthDate)
        {

            switch (BirthDate.Year % 12)
            {
                case 0:
                    return ChineseSignEnumeration.Monkey.ToString();
                  

                case 1:
                    return ChineseSignEnumeration.Rooster.ToString();
                   

                case 2:
                    return ChineseSignEnumeration.Dog.ToString();
                   

                case 3:
                    return ChineseSignEnumeration.Pig.ToString();
                   

                case 4:
                    return ChineseSignEnumeration.Rat.ToString();
                   

                case 5:
                    return ChineseSignEnumeration.Ox.ToString();
                   

                case 6:
                    return ChineseSignEnumeration.Tiger.ToString();
                  

                case 7:
                    return ChineseSignEnumeration.Rabbit.ToString();
                   

                case 8:
                    return ChineseSignEnumeration.Dragon.ToString();
                  

                case 9:
                    return ChineseSignEnumeration.Snake.ToString();
                   

                case 10:
                    return ChineseSignEnumeration.Horse.ToString();
                 

                case 11:
                    return ChineseSignEnumeration.Goat.ToString();
                    

            }
            return "Error";
        }

        public static bool IsAdult(DateTime dateOfBirth)
        {
            if (CalculateAge(dateOfBirth) >= 18)
            {
                return true;
            }
            return false;
        }
    }
}
