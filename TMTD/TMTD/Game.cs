using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
namespace TMTD
{
    class Game
    {
        private RenderWindow window;
        Gameplay gameplay = new Gameplay();
        public Game() 
        {
            VideoMode videoMode = new VideoMode();
            videoMode.Width = 800;
            videoMode.Height = 600;
            window = new RenderWindow(videoMode, "The Mark Of The Deamned");
            window.Closed += CloseWindow;
            window.SetFramerateLimit(60);
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
            gameplay.Update();
        }
        public void DrawGame() 
        {
            gameplay.DrawGameplay(window);
            window.Display();
        }
    }
}
