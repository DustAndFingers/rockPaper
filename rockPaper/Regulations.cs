using System;

namespace rockPaper
{
    class Regulations
    {
        public static void Moves(int us, string[] ar, int cp, string ke)
        {
            if (us > 0 && us <= ar.Length)
            {
                Console.WriteLine("Your move is: {0}", ar[us - 1]);
                Console.WriteLine("Computer move: {0}", ar[cp]);
                var half = (ar.Length - 1) / 2;
                cp += 1;
                if (us - cp == 0)
                {
                    Console.WriteLine("\n  Draw  ");
                }
                else if (Math.Abs(us - cp) <= half && us - cp > 0 || Math.Abs(us - cp) >= half && us - cp < 0)
                {
                    Console.WriteLine("\n  Lost  ");
                }
                else
                {
                    Console.WriteLine("\n  Victory  ");
                }
                Console.WriteLine("\n HMAC key: {0} \n", ke);
            }
            else Console.WriteLine("\n Wrong move! Enter number in range from '1' to '{0}' or '0' to exit", ar.Length);
        }
    }
}
