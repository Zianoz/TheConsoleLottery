using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TheConsoleLottery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool lotterygame = true;
            while (lotterygame)
            {
                Usercheck(Userinput(), Numbergenerator());
                Console.WriteLine("Vill du spela igen? (ja/nej)");
                string answer = Console.ReadLine();
                if (answer != "ja")
                {
                    lotterygame = false;
                }
                else
                {
                Console.Clear();
                }

            }

            //En method för användarens input
            int[] Userinput()
            {
                Console.WriteLine("Hur många lotter vill du köpa?");
                int ticketAmount = Convert.ToInt32(Console.ReadLine());
                int[] myTickets = new int[ticketAmount];
                for (int i = 1; i <= ticketAmount; i++)
                {
                    Console.WriteLine($"Vilket nummber vill du ha på lott {i}?");
                    myTickets[i - 1] = Convert.ToInt32(Console.ReadLine());
                }
                return myTickets;
            }

            int[] Numbergenerator()
            {
                Random random = new Random();
                int[] winningTickets = new int[3];
                for (int i = 0; i < 3; i++) 
                { 
                    int x = random.Next(1, 51);
                    winningTickets[i] = x;
                }
                return winningTickets;
            }

            void Usercheck(int[] myTickets, int[] winningTickets)
            {
                bool check = false;

                foreach (int ticket in myTickets)
                {
                    foreach (int winningnumber in winningTickets)
                    {
                        if (ticket == winningnumber)
                        {
                            check = true;
                            Console.WriteLine("Vinst för lott nummer " + winningnumber);
                        }
                    }   
                                            
                }
                if (!check)
                {
                    Console.Write($"Du vann absolut ingenting! Vinstlotterna var ");
                    foreach (int item in winningTickets)
                    {
                        Console.Write(item + " ");
                    }
                }


            }
        }
    }
}
