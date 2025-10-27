

using ATM_Final.Cards.cs;
using System.Threading.Channels;

namespace ATM
{
    internal class AtmInfo
    {
        
           private List<Card>cards = new List<Card>();

        public bool CreateCard(string number,
                               string pin,
                               decimal balance = 0)
        {

            if (cards.Exists(c => c.Number == number))
            {
                throw new ArgumentException("this card already exists");
            }
            
            cards.Add(new Card(number, pin, balance));
              
            return true;
        }

        //card autorization

        public Card AuthCard(string number,string pin)
        {
            foreach (var c in cards)
            {
                if(c.Number == number && c.Pin == pin)
                {
                    return c;
                }
            }
            throw new ArgumentException("this card does not exist");
        }

        public static string ReadHiddenLine()
        {
            string input = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    input += key.KeyChar;
                    Console.Write("*");

                }
            } 
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return input;
         }



    }   
}
