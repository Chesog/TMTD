using System;

namespace TMTD
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = Game.GetInstance();
            MusicManager.GetInstance().Play();

            FrameRate.InitFrameRateSystem();
            while (game.UpdateGameWindow())
            {
                game.UpdateGame();
                CollitionManager.Getinstance().CheckColitions();
                game.CheckGarbage();
                game.DrawGame();

                FrameRate.OnFrameEnd();
                Console.WriteLine(FrameRate.GetCurrentFps());
            }

        }
    }
}
