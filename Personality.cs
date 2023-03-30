namespace Assessement
{

    internal class Personality
    {
        public string name;
        public DateTime DOB;
        public string personalityType;
        public string zodiac;
        
        public Personality()
        {
            Console.WriteLine("Enter your name: ");
            this.name = Console.ReadLine();
            Console.WriteLine("Enter your DOB in format YYYY-MM-DD");
            int[] tempDate = Array.ConvertAll(Console.ReadLine().Trim().Split('-').ToArray(), int.Parse);
            this.DOB = new DateTime(tempDate[0], tempDate[1], tempDate[2]);
        }
        public void predictPersonality()
        {
            Console.WriteLine("Rate your sense of humor on scale of 1-10?");
            int humor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How often do u get frustrated on scale of 1-10?");
            int frustation = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How active are you in social media on scale of 1-10");
            int SocialMedia = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How open are you in expressing your feelings on scale of 1-10?");
            int openess = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How good are you in engaging with people on scale of 1-10?");
            int engaging = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Do you have a way to deal with your stress positively? Y/N");
            bool stress = Convert.ToBoolean(Console.ReadLine().ToLower() == "y" ? true : false);
            Console.WriteLine("Do you have good friend circle? Y/N");
            bool friends = Convert.ToBoolean(Console.ReadLine().ToLower() == "y" ? true : false);
            Console.WriteLine("Do you cry in front of others? Y/N");
            bool cry = Convert.ToBoolean(Console.ReadLine().ToLower() == "y" ? true : false);
            Console.WriteLine("Do you play or sing or dance or travel for fun? Y/N");
            bool enjoy = Convert.ToBoolean(Console.ReadLine().ToLower() == "y" ? true : false);

            Console.WriteLine("Do you consider yourself messy/organised person?");
            string neatness = Console.ReadLine().ToLower();
            Console.WriteLine("Do you consider yourself online/offline person?");
            string type = Console.ReadLine().ToLower();

            if (friends && enjoy && engaging > 5 && openess > 5 && type == "offline")
            {
                if (cry)
                {
                    this.personalityType = "Feeler & Extrovert";
                }
                else if (humor > 5 && SocialMedia > 5)
                {
                    this.personalityType = "Extreme extrovert";
                }
                else if (neatness == "messy")
                {
                    this.personalityType = "extrovert & messy";
                }
                else if (neatness == "organised")
                {
                    this.personalityType = "Behaves & extrovert";
                }
                else if (frustation > 5)
                {
                    if (stress)
                        this.personalityType = "Disturbed & extrovert";
                    else
                        this.personalityType = "Toxic extrovertness";
                }
                else
                {
                    this.personalityType = "Extrovert";
                }
            }
            else if (friends && enjoy && engaging > 5 && openess > 5 && type == "online" && SocialMedia > 5)

            {
                this.personalityType = "Ambivert";

            }
            else
            {
                this.personalityType = "Introvert";
            }

            Console.WriteLine($"You are {this.personalityType}");
        }

        public void zodiacSign()
        {
            int month = this.DOB.Month;
            int day = this.DOB.Day;

            if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
            {
                this.zodiac = "Aries";
            }
            else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
            {
                this.zodiac = "Taurus";
            }
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
            {
                this.zodiac = "Gemini";
            }
            else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
            {
                this.zodiac = "Cancer";
            }
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
            {
                this.zodiac = "Leo";
            }
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
            {
                this.zodiac = "Virgo";
            }
            else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
            {
                this.zodiac = "Libra";
            }
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
            {
                this.zodiac = "Scorpio";
            }
            else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
            {
                this.zodiac = "Sagittarius";
            }
            else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
            {
                this.zodiac = "Capricorn";
            }
            else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
            {
                this.zodiac = "Aquarius";
            }
            else
            {
                this.zodiac = "Pisces";
            }
        }

        public static void CalcAge(DateTime dob)
        {
            int age = (int)((DateTime.Now - dob).TotalDays / 365.242199);
            Console.WriteLine($"You are {age} years old");
        }

        public void printDetails()
        {
            Console.WriteLine($"Name      DOB        Zodiac\n{this.name}     {this.DOB}       {this.zodiac}");
        }
    }

    public class Matchmaking
    {
        List<Personality> persons = new List<Personality>();

        public void addPerson()
        {
            Personality p = new Personality();
            p.predictPersonality();
            persons.Add(p);
        }

        public void zodiac()
        {
            foreach (Personality p in persons)
            {
                p.zodiacSign();
            }
        }

        public void matches()
        {
            List<string> FireSigns = new List<string>() { "Aries", "Leo", "Sagittarius" };
            List<string> WaterSigns = new List<string>() { "Cancer", "Scorpio", "Pisces" };
            List<string> AirSigns = new List<string>() { "Gemini", "Libra", "Aquarius" };

            Console.WriteLine("Enter your DOB in format YYYY-MM-DD to proceed");
            int[] tempDate = Array.ConvertAll(Console.ReadLine().Trim().Split('-').ToArray(), int.Parse);
            DateTime dob = new DateTime(tempDate[0], tempDate[1], tempDate[2]);

            string zodiac_sign = "";
            foreach(Personality p in persons)
            {
                if(p.DOB == dob)
                {
                    zodiac_sign = p.zodiac;
                }
            }

            Console.WriteLine("you are compatabile with following people");
            Console.WriteLine($"Name        personalityType     Zodiac");
            foreach (Personality p in persons)
            {
                    if (FireSigns.Contains(zodiac_sign) || AirSigns.Contains(zodiac_sign))
                    {
                        if (FireSigns.Contains(p.zodiac) || AirSigns.Contains(p.zodiac))
                        {
                            Console.WriteLine($"{p.name}        {p.personalityType}     {p.zodiac}");
                        }
                    }
                    else
                    {
                        if (WaterSigns.Contains(p.zodiac))
                        {
                            Console.WriteLine($"{p.name}        {p.personalityType}");
                        }

                    }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Application");

            Console.WriteLine();
            Console.WriteLine();
            int option;
            Matchmaking match = new Matchmaking();
            do
            {
                Console.WriteLine("Enter the respective option\n1. To check personality\n2. To see your matches\n3. To calculate your age\n4. To quit");
                option = Convert.ToInt32(Console.ReadLine());
                bool proceed;
                switch (option)
                {
                    case 1:
                        {

                            Console.WriteLine("Lets procceed to identify your personality");

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Do you want to predict your personality? Y/N");
                            proceed = Convert.ToBoolean(Console.ReadLine().ToLower() == "y" ? true : false);
                            while (proceed)
                            {
                                match.addPerson();
                                Console.WriteLine("Do you want to predict another personality? Y/N");
                                proceed = Convert.ToBoolean(Console.ReadLine().ToLower() == "y" ? true : false);
                            }
                            break;

                        }
                    case 2:
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Lets make mathes");
                            match.zodiac();
                            Console.WriteLine();
                            Console.WriteLine("Do you want to procced? Y/N");
                            proceed = Convert.ToBoolean(Console.ReadLine().ToLower() == "y" ? true : false);
                            while (proceed)
                            {
                                match.matches();
                                Console.WriteLine("Do you want to predict another matches? Y/N");
                                proceed = Convert.ToBoolean(Console.ReadLine().ToLower() == "y" ? true : false);
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Lets calculate your age");
                            Console.WriteLine("Enter your DOB in format YYYY-MM-DD to proceed");
                            int[] tempDate = Array.ConvertAll(Console.ReadLine().Trim().Split('-').ToArray(), int.Parse);
                            DateTime dob = new DateTime(tempDate[0], tempDate[1], tempDate[2]);
                            
                            Personality.CalcAge(dob);
                            break;
                        }
                    case 4:
                        { break; }
                    default:
                        {
                            Console.WriteLine("Choose appropriate action");
                            break;
                        }
                }
            } while (option != 4);
        }
    }
}
        


