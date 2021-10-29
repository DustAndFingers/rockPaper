using System;
using System.Linq;
using System.Security.Cryptography;
using ConsoleTables;

namespace rockPaper
{
    class Program
    {

        static void Main(string[] args)
        {
            var key = Key.GetHmacKey();

            if (args.Length % 2 == 1 && args.Distinct().Count() == args.Count() && args.Length >= 3)
            {
                Console.Clear();
                while (true)
                {
                    Console.WriteLine("Available moves:");
                    for (int i = 0; i < args.Length; i++)
                    {
                        Console.WriteLine("{0} - {1}", i + 1, args[i]);
                    }

                    int userMove;
                    var cpuMove = GetRandomNumber(args.Length);
                    var hmac = HMAC.GetHmac(key, args[cpuMove]);

                    Console.WriteLine("\n HMAC: {0}", hmac);

                    Console.WriteLine("\n Enter your move, or '?' for help,  or '0' for exit:");
                    string userCons = Console.ReadLine();
                    if (userCons == "?")
                    {
                        if (args.Length == 3)
                        {
                            var table = new ConsoleTable("User/Cpu", args[0], args[1], args[2]);
                            table.AddRow($"{args[0]}", "Draw", "Lose", "Win")
                                 .AddRow($"{args[1]}", "Win", "Draw", "Lose")
                                 .AddRow($"{args[2]}", "Lose", "Win", "Draw");

                            table.Write();
                            Console.WriteLine();
                        }
                        else if (args.Length == 5)
                        {
                            {
                                var table = new ConsoleTable("User/Cpu", args[0], args[1], args[2], args[3], args[4]);
                                table.AddRow($"{args[0]}", "Draw", "Win", "Win", "Lose", "Lose")
                                     .AddRow($"{args[1]}", "Win", "Draw", "Win", "Win", "Lose")
                                     .AddRow($"{args[2]}", "Lose", "Lose", "Draw", "Win", "Win")
                                     .AddRow($"{args[3]}", "Win", "Lose", "Lose", "Draw", "Win")
                                     .AddRow($"{args[4]}", "Win", "Win", "Lose", "Lose", "Draw"); 

                                table.Write();
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            var table = new ConsoleTable("User/Cpu", args[0], args[1], args[2], args[3], args[4], args[5], args[6]);
                            table.AddRow($"{args[0]}", "Draw", "Win", "Win", "Win", "Lose", "Lose", "Lose")
                                 .AddRow($"{args[1]}", "Lose", "Draw", "Win", "Win", "Win", "Lose", "Lose")
                                 .AddRow($"{args[2]}", "Lose", "Lose", "Draw", "Win", "Win", "Win", "Lose")
                                 .AddRow($"{args[3]}", "Lose", "Lose", "Lose", "Draw", "Win", "Win", "Win")
                                 .AddRow($"{args[4]}", "Win", "Lose", "Lose", "Lose", "Draw", "Win", "Win")
                                 .AddRow($"{args[5]}", "Win", "Win", "Lose", "Lose", "Lose", "Draw", "Win")
                                 .AddRow($"{args[6]}", "Win", "Win", "Win", "Lose", "Lose", "Lose", "Draw");

                            table.Write();
                            Console.WriteLine();

                        }


                    }
                    bool c = Int32.TryParse(userCons, out userMove);
                    if (userMove == 0 && c) break;

                    Regulations.Moves(userMove, args, cpuMove, key);

                    Console.WriteLine("Press 'Escape' for exit or any else key for next game");
                    if (Console.ReadKey().Key == ConsoleKey.Escape) break;
                    Console.Clear();
                }
            }
            else Console.WriteLine("The number of arguments is even, not unique, or less than 3, for example: rock paper scissors lizard spock etc. ");
        }
        public static int GetRandomNumber(int range)
        {
            byte[] random = new byte[1];

            using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
            {
                provider.GetBytes(random);
            }
            return (random[0] % range);
        }
    }
}
