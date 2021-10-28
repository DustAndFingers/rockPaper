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

                if (us - cp - 1 == 0)
                {
                    Console.WriteLine("\n  Draw  ");
                }
                else if (Math.Abs(cp - us) <= half && cp - us > 0 || Math.Abs(cp - us) >= half && cp - us < 0)
                {
                    Console.WriteLine("\n  Victory  ");
                }
                else
                {
                    Console.WriteLine("\n  Lost  ");
                }
                Console.WriteLine("\n HMAC key: {0} \n", ke);
            }
            else Console.WriteLine("\n Wrong move! Enter number in range from '1' to '{0}' or '0' to exit", ar.Length);
        }
    }
}
