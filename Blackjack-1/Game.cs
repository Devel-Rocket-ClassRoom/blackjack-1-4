using System;
using System.Collections.Generic;
using System.Text;

class Game
{
    private string[] deck = new string[52];
    private Deck player;
    private Deck dealer;
    private int deckIndex;
    private Random random;

    public Game()
    {
        random = new Random();
        Reset();
    }

    public void Reset()
    {
        deckIndex = 0;
        player = new Deck();
        dealer = new Deck();
        SetDeck();
    }

    private void SetDeck()
    {
        string[] suits = { "♠", "♥", "♣", "◆" };
        string[] ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        int index = 0;

        for (int i = 0; i < suits.Length; i++)
        {
            for (int j = 0; j < ranks.Length; j++)
            {
                deck[index++] = suits[i] + ranks[j];
            }
        }
    }

    private void Shuffle()
    {
        for (int i = deck.Length - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            string temp = deck[i];
            deck[i] = deck[j];
            deck[j] = temp;
        }

        Console.WriteLine("카드를 섞는 중...\n");
    }

    private string DrawCard()
    {
        return deck[deckIndex++];
    }

    private bool HitOrStand()
    {
        while (true)
        {
            Console.Write("H(Hit) 또는 S(Stand)를 선택하세요: ");

            string? input = Console.ReadLine();

            if (input != null)
            {
                input = input?.ToUpper();

                if (input == "H")
                {
                    return true;
                }
                if(input == "S")
                {
                    return false ;
                }
            }

            Console.WriteLine("H 또는 S를 입력하세요.\n");
        }
    }

    public void Play()
    {
        Console.WriteLine("=== 블랙잭 게임 ===\n");

        Shuffle();

        player.Add(DrawCard());
        player.Add(DrawCard());
        dealer.Add(DrawCard());
        dealer.Add(DrawCard());

        Console.WriteLine("=== 초기 패 ===");
        dealer.DealerHiddenInfo();
        player.PlayerInfo();
        if (player.SumOfCards() == 21)
        {
            Console.WriteLine("블랙잭! 21점입니다!\n");
        }

        while (true)
        {
            bool isHit = HitOrStand();

            if (isHit)
            {
                string card = DrawCard();
                player.Add(card);

                Console.WriteLine($"\n플레이어가 카드를 받았습니다: [{card}]");
                player.PlayerInfo();

                if(player.IsBust() == true)
                {
                    Console.WriteLine("버스트! 21을 초과했습니다.\n");
                    break;
                }
                if(player.SumOfCards() == 21)
                {
                    Console.WriteLine("21점입니다!\n");
                }
            }
            else
            {
                Console.WriteLine("\n플레이어가 Stand를 선택했습니다.\n");
                break;
            }
        }


        Console.WriteLine($"딜러의 숨겨진 카드: [{dealer.GetCard(0)}]");
        dealer.DealerInfo();

        while (dealer.SumOfCards() < 17)
        {
            string card = DrawCard();
            dealer.Add(card);

            Console.WriteLine($"딜러가 카드를 받습니다: [{card}]");
            dealer.DealerInfo();
        }

        ShowFinalResult();
    }

    private void ShowFinalResult()
    {
        int playerSum = player.SumOfCards();
        int dealerSum = dealer.SumOfCards();

        Console.WriteLine("=== 게임 결과 ===");
        Console.WriteLine($"플레이어: {playerSum}점");
        Console.WriteLine($"딜러: {dealerSum}점\n");

        if (player.IsBust() == true)
        {
            Console.WriteLine("플레이어 패배!");
        }
        else if(dealer.IsBust() == true)
        {
            Console.WriteLine("플레이어 승리!");
        }
        else
        {
            if (playerSum > dealerSum)
            {
                Console.WriteLine("플레이어 승리!");
            }
            else if (playerSum < dealerSum)
            {
                Console.WriteLine("플레이어 패배!");
            }
            else
            {
                Console.WriteLine("무승부!");
            }
        }

    }
}