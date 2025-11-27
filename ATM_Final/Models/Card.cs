namespace ATM_Final.Cards.cs
{
    public class Card
    {
        private string _pin2;
        private string _number2;

        public string Number
        {
            get
            {
                return _number2;
            }
            init
            {
                if (value.Length != 9)
                {
                    throw new ArgumentException("card length is not correct");
                }

                _number2 = value;
            }
        }
        public string Pin
        {
            get
            {
                return _pin2;
            }
            init
            {
                if (value.Length != 4)
                {
                    throw new ArgumentException("pin length is not correct");
                }

                _pin2 = value;
            }
        }

        public decimal Balance { get; set; }

        public Card()
        {
                
        }

        public Card
            (
            string numbers,
            string pin,
            decimal balance
            )
        {
            this.Number = numbers;
            this.Pin = pin;
            this.Balance = balance;
        }
    }
}
