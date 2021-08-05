using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
namespace TMTD
{
    class Game
    {
        private static Game instance;
        public static Game GetInstance() 
        {
            if (instance == null)
            {
                instance = new Game();
            }
            return instance;
        }
        private RenderWindow window;
        private static Vector2f windowSize;
        private Gameplay gameplay;
        private MenuPrincipal menu;
        private Game() 
        {
            VideoMode videoMode = new VideoMode();
            videoMode.Width = 1600;
            videoMode.Height = 900;

            window = new RenderWindow(videoMode, "The Mark Of The Deamned");
            window.Closed += CloseWindow;
            window.SetFramerateLimit(FrameRate.FRAMERATE_LIMIT);

            gameplay = new Gameplay();
            menu = new MenuPrincipal();
            Camera.GetInstance().InitCamera(window);
        }
        private void CloseWindow(object sender , EventArgs e) 
        {
            window.Close();
        }
        public bool UpdateGameWindow() 
        {
            window.DispatchEvents();
            window.Clear(Color.Black);
            return window.IsOpen;
        }
        public void UpdateGame() 
        {
            gameplay.UpdateGameplay();
            Camera.GetInstance().UpdateCamera();
            windowSize = window.GetView().Size;
        }
        public void DrawGame() 
        {
            gameplay.DrawGameplay(window);
            window.Display();
        }
        public void CheckGarbage() 
        {
            gameplay.CheckGarbage();
        }
        public Vector2f GetWindowSize() 
        {
            return windowSize;
        }
    }
}
