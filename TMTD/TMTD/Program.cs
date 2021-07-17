using System;

namespace TMTD
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            while (game.UpdateGameWindow())
            {
                game.UpdateGame();
                game.DrawGame();
            }
        }
    }
}
