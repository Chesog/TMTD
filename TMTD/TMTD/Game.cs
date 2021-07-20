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
        public static readonly uint FRAMERATE_LIMIT = 60;
        Gameplay gameplay = new Gameplay();
        MenuPrincipal menu = new MenuPrincipal();   
        public Game() 
        {
            
            VideoMode videoMode = new VideoMode();
            videoMode.Width = 800;
            videoMode.Height = 600;
            window = new RenderWindow(videoMode, "The Mark Of The Deamned");
            window.Closed += CloseWindow;
            window.SetFramerateLimit(FRAMERATE_LIMIT);
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
        }
        public void DrawGame() 
        {
            gameplay.DrawGameplay(window);
            window.Display();
        }
    }
}
