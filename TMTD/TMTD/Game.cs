using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
namespace TMTD
{
    class Game
    {
        private RenderWindow window;
        private static Vector2f windowSize;
        Gameplay gameplay;
        MenuPrincipal menu;   
        public Game() 
        {
            gameplay = new Gameplay();
            menu = new MenuPrincipal();
            VideoMode videoMode = new VideoMode();
            videoMode.Width = 1600;
            videoMode.Height = 900;
            window = new RenderWindow(videoMode, "The Mark Of The Deamned");
            window.Closed += CloseWindow;
            window.SetFramerateLimit(FrameRate.FRAMERATE_LIMIT);
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
            windowSize = window.GetView().Size;
        }
        public void DrawGame() 
        {
            gameplay.DrawGameplay(window);
            window.Display();
        }
        public Vector2f GetWindowSize() 
        {
            return windowSize;
        }
    }
}
