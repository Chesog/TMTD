using SFML.Window;
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
            JoystickUtils.SetDrift(0.2f);
            while (game.UpdateGameWindow())
            {
                game.UpdateGame();
                CollitionManager.Getinstance().CheckColitions();
                game.CheckGarbage();
                game.DrawGame();
                Joystick.Update();
                FrameRate.OnFrameEnd();
                Console.WriteLine(FrameRate.GetCurrentFps());
            }

        }
    }
}
