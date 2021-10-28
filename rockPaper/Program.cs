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


                        var table = new ConsoleTable("", "Rock", "Paper", "Scissors");
                        table.AddRow("Rock", "Draw", "Win", "Defeat")
                             .AddRow("Paper", "Defeat", "Draw", "Win");

                        table.Write();
                        Console.WriteLine();

                        var rows = Enumerable.Repeat(new Regulations(), 10);

                        ConsoleTable
                            .From<Regulations>(rows)
                            .Configure(o => o.NumberAlignment = Alignment.Right)
                            .Write(Format.Alternative);

                        Console.ReadKey();
                        continue;
                    }
                    bool c = Int32.TryParse(userCons, out userMove);
                    if (userMove == 0 && c) break;


                    Regulations.Moves(userMove, args, cpuMove, key);

                    Console.WriteLine("Press 'Escape' for exit or any else key for next game");
                    if (Console.ReadKey().Key == ConsoleKey.Escape) break;
                    Console.Clear();

                }
            }
            else Console.WriteLine("The number of arguments is even, not unique, or less than 3, for example: dotnet run rock paper scissors lizard Spock");
        }



        public static int GetRandomNumber(int range)
        {
            byte[] random = new byte[1];

            using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
            {
                provider.GetBytes(random);
            }
            return ((random[0] % range));
        }
    }
}
