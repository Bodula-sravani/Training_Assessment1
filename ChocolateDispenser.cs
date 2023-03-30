using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assessement
{
    internal class Dispenser
    {
        public List<Dictionary<string,int>> dispenser_chocolates = new List<Dictionary<string,int>>();
        public int totalChocolates;
        static int maxLimit = 100;
        public Dispenser()
        {
            addChocolates("green", 10);
            addChocolates("silver", 10);
            addChocolates("blue", 10);
            addChocolates("crimson", 10);
            addChocolates("purple", 10);
            addChocolates("red", 10);
            addChocolates("pink", 10);
            totalChocolates = 70;
            
        }
        public void addChocolates(String color,int count)   // TO ADD CHOCOLATES FROM TOP
        {
            Dictionary<string, int> chocolates = new Dictionary<string, int>();  

            chocolates.Add(color,count);
            this.dispenser_chocolates.Add(chocolates);
            this.totalChocolates+= count;
            if(totalChocolates>maxLimit)
            {
                Console.WriteLine();
                Console.WriteLine();
                removeChocolates(totalChocolates-maxLimit);
            }
        }
        public bool DispenserEmpty()   // TO CHECK IF DISENSER IS EMPTY OR NOT
        {
            if (this.dispenser_chocolates.Count == 0)
            {
                Console.WriteLine("Dispenser is Empty!!!!");
                return true;
            }
            return false;
        }
        public Dictionary<string,int> removeChocolates(int count)
        {
            Dictionary<String, int> chocos = new Dictionary<string, int>();
            Dictionary<string, int> chocolates = new Dictionary<string, int>();
            
            while (count > 0)      // WHILE COUNT !=0 WE TAKE EACH ELEMENT FROM LIST AND REDUCE ITEM VALUE 
            {
                if (DispenserEmpty()) return null;
                chocolates = dispenser_chocolates[dispenser_chocolates.Count-1];
                dispenser_chocolates.RemoveAt(dispenser_chocolates.Count - 1);   //REMOVE TOP COLOR CHOCOLATES
                foreach(var item in chocolates )
                {
                    if(item.Value>=count)
                    {
                        chocolates[item.Key] = item.Value-count;
                        this.dispenser_chocolates.Add(chocolates);    //ADDING THE REMAINING CHOCOLATES LEFT AFTER TAKING OUT COUNT
                        chocos.Add(item.Key, count);
                        this.totalChocolates -= count;
                        count = 0;
                    }
                    else
                    {
                        this.totalChocolates -= item.Value;
                        count -= item.Value;
                        chocos.Add(item.Key, item.Value);
                    }
                }
            }
            return chocos;
        }
        public Dictionary<String,int> dispenseChocolates(int count)  //REMOVING CHOCOLATES FROM BOTTOM
        {
            Dictionary<String, int> chocos = new Dictionary<string, int>();
            
            while (count > 0)
            {
                if (DispenserEmpty()) return null;
                Dictionary<string, int> chocolates = new Dictionary<string, int>();
                chocolates = dispenser_chocolates[0];
                dispenser_chocolates.RemoveAt(0);   //REMOVING BOTTOM COLOR CHOCOLATES
                foreach (var item in chocolates)
                {
                    if (item.Value >=count)
                    {
                        chocolates[item.Key] = item.Value - count;
                        this.dispenser_chocolates.Insert(0,chocolates);    //ADDING THE EXCESS
                        this.totalChocolates -= count;
                        chocos.Add(item.Key, count);
                        count = Math.Abs(item.Value - count);
                    }
                    else
                    {
                        this.totalChocolates -= item.Value;
                        count -= item.Value;
                        chocos.Add(item.Key, item.Value);
                    }
                }
            }
            return chocos;
        }
        public Dictionary<String, int> dispenseChocolatesofColor(String color,int count)  //REMOVE FROM BOTTOM USING COLOR AND COUNT
        {
            if (DispenserEmpty()) return null;
            Dictionary<String, int> chocos = new Dictionary<string, int>();
            bool colorExists = false;
            for (int i=0;i<dispenser_chocolates.Count;i++)   
            {
                Dictionary<string, int> chocolates = new Dictionary<string, int>();
                chocolates = dispenser_chocolates[i];
                foreach (var item in chocolates)
                {
                    if (item.Key == color && count>0)             
                    {
                        chocolates[item.Key] = Math.Abs(item.Value - count);
                        dispenser_chocolates[i] = chocolates;
                        chocos.Add(item.Key, Math.Abs(item.Value - count));
                        this.totalChocolates -= count;
                        count = Math.Abs(item.Value - count);
                        colorExists = true;
                    }  
                }
                if (count == 0) break;
            }
            if (!colorExists)
            {
                Console.WriteLine("color is not present");
                Console.WriteLine();
                return null;
            }
            else return chocos;
        }

        public Dictionary<String, int> noOfChocolates()  //STORING ALL CHOCOLATES IN ONE DICT IN A SPECIFIC  ORDER OF KEYS
        {
            if (DispenserEmpty()) return null;
            Dictionary<string, int> sortedchocolates = new Dictionary<string, int>();
            sortedchocolates = createDict();    
            Dictionary<string, int> chocolates = new Dictionary<string, int>();
            chocolates.Add("green", sortedchocolates.GetValueOrDefault("green",0));
            chocolates["silver"] = sortedchocolates.GetValueOrDefault("silver", 0);
            chocolates["blue"] = sortedchocolates.GetValueOrDefault("blue", 0);
            chocolates["crimson"] = sortedchocolates.GetValueOrDefault("crimson", 0);
            chocolates["purple"] = sortedchocolates.GetValueOrDefault("purple", 0);
            chocolates["red"] = sortedchocolates.GetValueOrDefault("red", 0);
            chocolates["pink"] = sortedchocolates.GetValueOrDefault("pink", 0);
            return chocolates;
        }
        public void SortChocolatedByCount()  
        {
            Dictionary<string, int> sortedchocolates = new Dictionary<string, int>();
            sortedchocolates = createDict();
            dispenser_chocolates.Clear();
            foreach (var item in sortedchocolates.OrderByDescending(x => x.Value))
            {

                Dictionary<string, int> chocolates = new Dictionary<string, int>();
                chocolates.Add(item.Key, item.Value);
                dispenser_chocolates.Add(chocolates);
            }
        }

        public void changeChocolateColor(string color , string newcolor , int count)
        {
            int tempCount = count;  //used to add to new color
            bool newColorExists = false;
            for (int i = 0; i < dispenser_chocolates.Count; i++)
            {
                Dictionary<string, int> chocolates = new Dictionary<string, int>();
                chocolates = dispenser_chocolates[i];
                foreach (var item in chocolates)
                {
                    if (item.Key == color && count > 0)
                    {
                        chocolates[item.Key] = Math.Abs(item.Value - count);
                        dispenser_chocolates[i] = chocolates;
                        count = Math.Abs(item.Value - count);
                    }
                }
                    if (chocolates.ContainsKey(newcolor))
                    {
                        chocolates[newcolor] += tempCount;
                        dispenser_chocolates[i] = chocolates;
                        tempCount = 0;  
                        newColorExists = true;
                    }
                }
            if(!newColorExists)
            {
                Dictionary<string, int> chocolates = new Dictionary<string, int>();
                chocolates[newcolor] = tempCount;
                dispenser_chocolates.Add(chocolates);
            }             
        }
        public int changeChocolateColorofAll(string oldcolor, string newcolor)
        {
            int result = 0;
            bool newColorExists = false;
            for (int i = 0; i < dispenser_chocolates.Count; i++)
            {
                Dictionary<string, int> chocolates = new Dictionary<string, int>();
                Dictionary<string, int> newChoco = new Dictionary<string, int>();
                chocolates = dispenser_chocolates[i];
                foreach (var item in chocolates)
                {
                    if (item.Key == oldcolor)
                    {
                        newChoco[newcolor] = item.Value;
                        dispenser_chocolates[i] = newChoco;
                        result += item.Value;
                        
                    }
                    if(item.Key == newcolor)
                    {
                        result += item.Value;
                    }
                }
            }
            return result;
        }
        public bool removeChocolateOfColor(string color)
        {
            Dictionary<string, int> chocolates = new Dictionary<string, int>();
            for (int i = dispenser_chocolates.Count - 1; i >= 0; i--)
            {
                chocolates = dispenser_chocolates[i];
                foreach (var item in chocolates)
                {
                    if (item.Key==color && item.Value >= 1)
                    {

                        chocolates[item.Key]--; ;
                        this.dispenser_chocolates[i] = chocolates;
                        this.totalChocolates--;
                        return true;
                    }
                }
            }
            return false;
            }
        public int dispenseRainbowChocolates()  //EVERY 3 SIMILAR CHOCO MAKE A RAINBOW CHOCOLATE RETURNS NO OF SUCH CHOCO
        {
            int result = 0;
            SortChocolatedByCount();
            
            for (int i=0;i<dispenser_chocolates.Count;i++)
            {
                Dictionary<string, int> chocolates = new Dictionary<string, int>();
                chocolates = dispenser_chocolates[i];
                foreach(var item in chocolates)
                {
                    result += (item.Value / 3);
                }
            }
            return result;
        }
        public void PrintDetails()
        {
            if (this.dispenser_chocolates.Count == 0)
            {
                Console.WriteLine("Dispenser is Empty!!!!");
            }
            else
            {
                Console.WriteLine("| List of chocolates |");
                Console.WriteLine("| Color        Count |");
                for (int i = 0; i < this.dispenser_chocolates.Count; i++)
                {
                    foreach (KeyValuePair<string, int> item in this.dispenser_chocolates[i])
                    {
                        Console.WriteLine($"  {item.Key}          {item.Value}  ");
                    }
                }
                Console.WriteLine($"Total chocolates:    {this.totalChocolates}");
            }
            Console.WriteLine();
        }
        public  Dictionary<string,int> createDict()   //CREATES ONE DICT STORING ALL CHOCLATES KEYS AS COLOR AND VALUE AS COUNT
        {
            Dictionary<string, int> dictChocolates = new Dictionary<string, int>();
            for (int i = 0; i <dispenser_chocolates.Count - 1; i++)
            {
                foreach (var items in dispenser_chocolates[i])
                {
                    if (dictChocolates.ContainsKey(items.Key))
                    {
                        dictChocolates[items.Key] += items.Value;
                    }
                    else
                    {
                        dictChocolates.Add(items.Key, items.Value);
                    }
                }
            }
            return dictChocolates;
        }
        public static void printDict(Dictionary<string,int> d)   //IN CASE A DICT IS NEEDED TO BE PRINTED JUST TO REUSE
        {
            Console.WriteLine("| Color        Count |");
           

            foreach (KeyValuePair<string, int> item in d)
                {
                Console.WriteLine($"  {item.Key}          {item.Value}  ");
            }
            Console.WriteLine();
        }
        public static void Main(string[] strings)
        {
            Dispenser machine = new Dispenser();
            int option;
            Dictionary<string, int> d = new Dictionary<string, int>();
            do
            {
                Console.WriteLine("Enter respective option\n1.Add chocolates\n2.Remove chocolates\n3.Dispense chocolates by count\n" +
                    "4.Dispense chocolates by color & count\n5.Trail 5\n6.sort by count\n7.Change color\n8.Change color of all\n9.Fresh picikings" +
                    "\n10.Rainbow chocolates\n11.View list of chocolates\n12.TO QUIT");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            machine.addChocolates("green", 5);
                            machine.addChocolates("red", 30);
                            machine.PrintDetails();
                            break;
                        }
                    case 2:
                        {
                            d = machine.removeChocolates(10);
                            if (d != null)
                            {
                                Console.WriteLine("Removed list of chocolates");
                                Dispenser.printDict(d);
                            }
                            break;
                        }
                    case 3:
                        {
                            d = null;
                            d = machine.dispenseChocolates(10);
                            if (d != null)
                            {
                                Console.WriteLine("Dispensed list of chocolates  by count");
                                Dispenser.printDict(d);
                            }
                            break;
                        }
                    case 4:
                        {

                            d = null;
                            d = machine.dispenseChocolatesofColor("purple", 5);
                            if (d != null)
                            {
                                Console.WriteLine("Dispense list of chocolates by color and count");
                                Dispenser.printDict(d);
                            }
                            break;
                        }
                    case 5:
                        {

                            d = null;
                            d = machine.noOfChocolates();
                            if (d != null)
                            {
                                Console.WriteLine("List of chocolates in sorted order");
                                Dispenser.printDict(d);
                                
                            }
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("List of chocolates in sorted by count");
                            machine.SortChocolatedByCount();
                            machine.PrintDetails();
                            break;
                        }

                    case 7:
                        {
                            Console.WriteLine("change color by giving color and count");
                            machine.changeChocolateColor("red", "green", 3);
                            machine.PrintDetails();
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("change all color  by given color ");
                            int num = machine.changeChocolateColorofAll("red", "green");
                            Console.WriteLine($"Finalcolor chocolates {num} totalchocolates: {machine.totalChocolates}");
                            break;
                        }
                    case 9:
                        {
                            Console.WriteLine("Remove chocolate of color");
                            Console.WriteLine(machine.removeChocolateOfColor("green"));
                            machine.PrintDetails();
                            break;
                        }
                    case 10:
                        {
                            Console.Write("Rainbow color chocolates:  ");
                            Console.WriteLine(machine.dispenseRainbowChocolates());
                            break;
                        }
                    case 11:
                        {
                            machine.PrintDetails();
                            break;
                        }
                    case 12:
                        { break; }
                    default:
                        {
                            Console.WriteLine("Choose Avaibale options");
                            break;
                        }
                }
            } while (option != 12);
        }
    }
}
