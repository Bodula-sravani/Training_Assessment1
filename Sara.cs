using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

public class Sara
{

	public string Name;
	public string personalityType;
	public int age;
	public Sara()
	{
        Console.WriteLine("whats your name?");
        this.Name = Console.ReadLine();
		this.personalityType = "none";
		this.age= 0;
    }


	public void personality()
	{
		Console.WriteLine("Gender?");
		string gender = Console.ReadLine();

		Console.WriteLine("age?");
		this.age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Rate your sense of humor on scale of 1-10?");
		int humor = Convert.ToInt32(Console.ReadLine());

		Console.WriteLine("How often do u get stressed or frustrated on scale of 1-10?");
		int stress = Convert.ToInt32(Console.ReadLine());

		Console.WriteLine("Do you like morning-life or night-life?");
		string am_pm = Console.ReadLine();

        Console.WriteLine("what is your holiday spot: Hill_station or Beach or Temple?");
		string holiday_spot = Console.ReadLine();

		if(gender =="Male" || gender=="Female")
		{
			if(age<=10)
			{
				this.personalityType = "childish";
			}
			else if(age>10 && age<=20)
			{
				if(stress>=5)
				{
					this.personalityType = "Aggressive teenager";
				}
				else
				{
					this.personalityType = "Calm and planned teenager";
				}
			}
			else if(age>20)
			{
				if(stress<=5 && humor>=5)
				{
					this.personalityType = "Living life happily";
				}
				else
				{
					this.personalityType = "Not so funny and overthinker";
				}
			}
			else
			{
				if(stress<5 && humor>=5)
					
				{
					if (holiday_spot == "Beach")
					{ this.personalityType = "Living mid-life with full energy"; }
					else if(holiday_spot=="Temple")
					{
						this.personalityType = "Spiritual";
					}
					else { this.personalityType = "calm like nature"; }
				}
			}
		}
		Console.WriteLine($"You are  {this.personalityType}");
	}

	public void print()
	{
		Console.WriteLine($"Name: {this.Name}\nPersonality: {this.personalityType}");
	}

	public static void Main(string[] args)
	{
		var persons = new List<Sara>();
		bool add_persons = true;
		//itertaion1 
		Console.WriteLine("Enter details and check your personality");
		while (add_persons)
		{
			Sara p1 = new Sara();
			p1.personality();
			persons.Add(p1);
			Console.WriteLine("Check personality of another person? true/false");
			add_persons =   Convert.ToBoolean( Console.ReadLine());
		}

		//Iteraion 2
		Console.WriteLine("Do you like to match the available personalities? true or false");
		bool match = Convert.ToBoolean(Console.ReadLine());
		if(match)
		{
			foreach(Sara p in persons)
			{
				foreach(Sara p2 in persons)
				{
					if(p.personalityType.Equals(p.personalityType) && p.personalityType=="childsih")
					{
                        Console.WriteLine($"{p.Name} and {p2.Name} are a good match");
                    }
					if(p.personalityType== "Aggressive teenager" && p.personalityType== "Calm and planned teenager")
					{
						Console.WriteLine($"{p.Name} and {p2.Name} are a good match");
					}
					if(p.personalityType== "Living life happily" && p.personalityType== "Not so funny and overthinker")
					{
						Console.WriteLine($"{p.Name} and{p2.Name} are a good match");
					}
                    if (p.personalityType == "Living mid-life with full energy" && p.personalityType == "calm like nature")
                    {
                        Console.WriteLine($"{p.Name} and{p2.Name} are a good match");
                    }
                    if (p.personalityType == "Spiritual" && p.personalityType == "calm like nature")
                    {
                        Console.WriteLine($"{p.Name} and{p2.Name} are a good match");
                    }

                }

			}
         }







    }
}
