using System;
using System.Collections.Generic;
using System.Text;

class Deck
{
    private string[] cards;
    private int count;

    public Deck()
    {
        cards = new string[21];
        count = 0;
    }

    public void Add(string card)
    {
        cards[count] = card;
        count++;
    }

    public string GetCard(int index)
    {
        return cards[index];
    }

    public void PlayerInfo()
    {
        Console.Write("플레이어의 패: ");

        for (int i = 0; i < count; i++)
        {
            Console.Write($"[{cards[i]}]");
        }

        Console.WriteLine($"\n플레이어 점수: {SumOfCards()}\n");
    }

    public void DealerHiddenInfo()
    {
        Console.WriteLine($"딜러의 패: [??] [{cards[1]}]");
        Console.WriteLine("딜러 점수: ?\n");
    }

    public void DealerInfo()
    {
        Console.Write("딜러의 패: ");

        for (int i = 0; i < count; i++)
        { 
            Console.Write($"[{cards[i]}]");
        }

        Console.WriteLine($"\n딜러 점수: {SumOfCards()}\n");
    }

    public bool IsBust()
    {
        if (SumOfCards() > 21)
        {
            return true;
        }
        return false;
    }

    public int SumOfCards()
    {
        int sum = 0;
        int aceCount = 0;

        for (int i = 0; i < count; i++)
        {
            string rank = cards[i].Substring(1);

            switch (rank)
            {
                case "A":
                    aceCount++;
                    sum += 11;
                    break;

                case "J":
                case "Q":
                case "K":
                    sum += 10;
                    break;

                default:
                    sum += int.Parse(rank);
                    break;
            }
        }

        while (sum > 21 && aceCount > 0)
        {
            sum -= 10;
            aceCount--;
        }

        return sum;
    }
}