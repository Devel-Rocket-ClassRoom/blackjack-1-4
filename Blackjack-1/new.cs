using System;

class Program
{
    static void Main()
    {
        Game game = new Game();

        while (true)
        {
            game.Play();

            Console.Write("\n새 게임을 하시겠습니까? (Y/N): ");
            string input = Console.ReadLine();

            if (input == null || input.ToUpper() != "Y")
            {
                Console.WriteLine("게임을 종료합니다.");
                break;
            }

            game.Reset();
            Console.Clear();
        }
    }
}
