using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.System;
using System.IO;
using SFML.Graphics;

namespace TMTD
{
    class MainMenu
    {
        private Title GameName;
        private Title text;

        public bool exitMenu;

        public MainMenu()
        {
            GameName = new Title("AWESOME GAME!", new SFML.System.Vector2f(100.0f, 100.0f));
            text = new Title("PRESS 'F' TO CONTINUE", new SFML.System.Vector2f(100.0F, 500.0F));
            exitMenu = false;
        }

        public void Update()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.F))
            {
                exitMenu = true;
            }
        }

        public void Draw(RenderWindow window)
        {
            GameName.Draw(window);
            text.Draw(window);
        }

    }
}
