using System;
using System.Numerics;

{
    Game g = new Game();
    g.Play();
    //시작

    //카드 섞기

    //while (true)
    //{
    //    //처음 카드 나누기
    //
    //
    //
    //}
}
class Game
{
    private static string[] deck = new string[52];
    private Deck player = new Deck('p');
    private Deck dealer = new Deck('d');

    private int Count = 0;

    public Game()
    {
        string[] suits = { "♠", "♥", "♣", "◆" };
        string[] ranks = { "A", "J", "K", "Q", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        int index = 0;
        foreach (string s in suits)
        {
            foreach (string rank in ranks)
            {
                deck[index++] += s + rank;
            }
        }
    }

    public void Play()
    {
        if (Count == 0)
        {
            Console.WriteLine("=== 블랙잭 게임 ===\n");

            Shuffle();

            player.Add(deck[Count++]);
            player.Add(deck[Count++]);
            dealer.Add(deck[Count++]);
            dealer.Add(deck[Count++]);

            Console.WriteLine("=== 초기 패 ===");

            dealer.ShowInfo(0);
            player.ShowInfo(0);
        }
        else
        {

        }
    }

    public void Shuffle()
    {
        Random random = new Random();
        for (int i = deck.Length - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            string temp = deck[i];
            deck[i] = deck[j];
            deck[j] = temp;
        }

        Console.WriteLine("카드를 섞는 중...\n");
    }


}

class Deck
{
    public string[] _deck { get; private set; }

    public int count { get; private set; } = 0;
    private readonly char name;
  
    public Deck(char name)
    {
        _deck = new string[20];
        this.name = name;
    }

    public void Add(string s)
    {
        _deck[count] = s;
        count++;
    }

    public void ShowInfo(int Count = 1)
    {
        if (this.name == 'p')
        {
            Console.Write($"플레이어의  패: ");

            foreach (string s in _deck)
            {
                if (s == null)
                {
                    break;
                }
                else
                {
                    Console.Write($"[{s}] ");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"플레이어의  점수: {SumOfCards(_deck)}\n");
        }
        if (this.name == 'd')
        {
            if (Count == 0)
            {
                Console.WriteLine($"딜러의 패: [??] [{_deck[1]}]");
                Console.WriteLine($"딜러의 점수: ?\n");
            }
            else
            {
                Console.Write($"딜러의 패: ");

                foreach (string s in _deck)
                {
                    if (s == null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"[{s}]");
                    }
                }

                Console.WriteLine($"딜러의 점수: {SumOfCards(_deck)}\n");
            }
        }
    }
    public int StringToInt(string card)
    {
        switch (card)
        {
            case "A":
                { return 11; }
                break;
            case "J":
            case "K":
            case "Q":
                { return 10; }
                break;
            default:
                {
                    int.TryParse(card, out int value);
                    return value;
                }
        }
    }

    public int SumOfCards(string[] arr)
    {
        int sum = 0;
        foreach (string c in arr)
        {
            sum += StringToInt(c);
        }
        return sum;
    }

}
