using System;

namespace TMTD
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            FrameRate.InitFrameRateSystem();
            while (game.UpdateGameWindow())
            {
                game.UpdateGame();
                game.DrawGame();
                FrameRate.OnFrameEnd();
                Console.WriteLine(FrameRate.GetCurrentFps());
            }
        }
    }
}
