namespace Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            
            
            List<Card> cards = new List<Card>();
            
            foreach (string cardInfo in input)
            {
                string[] tokens = cardInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string face = tokens[0];
                string suit = tokens[1];
                
                try
                {
                    
                    Card card = new Card(face, suit);
                    cards.Add(card.CreateCard(face, suit));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine(string.Join(" ", cards));
        }
    }
    public class Card
    {
        private readonly Dictionary<string, string> suits = new Dictionary<string, string>()
        {
            {"S", "\u2660" },
            {"H", "\u2665" },
            {"D", "\u2666" },
            {"C", "\u2663" }
        };
        private readonly string[] faces = new string[] { "2", "3", "4", "5", "6", "7", "8", "10", "J", "Q", "K", "A" };
        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face { get; private set; }

        public string Suit { get; private set; }


        public override string ToString()
        {
            return $"[{this.Face}{this.Suit}]";
        }

        public Card CreateCard(string face, string suit)
        {
            if (!faces.Contains(face))
            {
                throw new ArgumentException("Invalid card!");
            }
            else
            {
                this.Face = face;
            }
            if (suits.Keys.Contains(suit))
            {
                this.Suit = suits.FirstOrDefault(x => x.Key == suit).Value;
            }
            else
            {
                throw new ArgumentException("Invalid card!");
            }

            return this;
        }
    }
}