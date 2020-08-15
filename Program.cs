using System;
using System.Collections.Generic;
using System.Linq;

namespace EXeption
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Console.WriteLine("======================================================================");
            System.Console.WriteLine("                  How many people are you??");
            System.Console.WriteLine("======================================================================");
            int InputNumbrePeople = int.Parse(Console.ReadLine());      // Number people there are
            var Peoplenumbre = "PeopleNumbre";      //welcome Name 

            DateTime TimeIn = new DateTime();       //Time in the room
            DateTime TimeOff = new DateTime();      //Time exit the room
            TimeSpan TotalInRoom = new TimeSpan();      // Total time in the room
            List<Presone> ListOfList = new List<Presone>();     //List of personal data 

            for (int i = 1; i < InputNumbrePeople + 1; i++)     //Number of personal data  
            {
                //generateur name
                System.Console.WriteLine("----------------------------------------------");
                System.Console.WriteLine($" Hello, {Peoplenumbre.Insert(12, $"{i}")} ");
                System.Console.WriteLine("----------------------------------------------");

                //Room Numbre 
                System.Console.WriteLine("What room number are you signed into ??");
                string InputRoom = Console.ReadLine();

                //Name of the people
                System.Console.WriteLine("Pleas enter your name");
                string InputName = Console.ReadLine();

                //date/time In
                System.Console.WriteLine("What year, date, time are you signed in?       syntax (dd/mm/yyyy hh:mm)");

            Again:;
                try
                {
                    TimeIn = DateTime.Parse(Console.ReadLine());
                }
                catch (System.FormatException ex)
                {
                    System.Console.WriteLine($" You should write something I understand \n\n {ex.Message} \n\n try this syntax e.g:  dd/mm/yyyy hh:mm ");
                    goto Again;
                }

                //Date/Time Off
                System.Console.WriteLine("What time are you out { With Covid19 I still want ask the year and month :) } Date and time you signed in?");
                TimeOff = DateTime.Parse(Console.ReadLine());

                //Total spend in a room      
                TotalInRoom = TimeOff - TimeIn;

                if (TimeOff <= TimeIn)
                {
                    throw new ArithmeticException(" you cannot leave the room before entering the room \n Sign in again please");
                }

                ListOfList.Add(new Presone(InputRoom, InputName, TimeIn, TimeOff, TotalInRoom));        //new list 
            }


            // show all the input 
            for (int i = 0; i < ListOfList.Count; i++)
            {
                System.Console.WriteLine($"{ListOfList[i].GetFulldetail()}\n");
            }

            //Looking for name in data 
            int YN = 0;
            try
            {
                System.Console.WriteLine("Wanna find out if a name is on the list? Press 1 for yes or  2 for no");
                YN = int.Parse(Console.ReadLine());
            }
            catch (FormatException)

            {
                Console.WriteLine("need number 1 or 2");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($" Is something wrong with you? :) \n\n{ex.Message}");
                return;
            }

            if (YN == 1)
            {
                System.Console.WriteLine("What name are you looking for?");
                string LookForName = Console.ReadLine();

                for (int i = 0; i < ListOfList.Count; i++)
                {
                    if (!ListOfList[i].InputName.Equals(LookForName) == true)
                    {
                        System.Console.WriteLine("sorry I can't find you name in the database ");
                        return;
                    }
                    else
                    {
                        System.Console.WriteLine($"{LookForName} is on the list");
                        System.Console.WriteLine($"\n\n{ListOfList[i].GetFulldetail()}");
                    }
                }
            }
            else
            {
                System.Environment.Exit(1);
            }
        }
    }
}