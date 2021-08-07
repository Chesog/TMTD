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
        private Background menuBackground;

        public bool exitMenu;

        public MainMenu()
        {
            menuBackground = new Background("Background/Sprites/Menu/dario.jpg", new Vector2f(1.0f, 1.0f));
            GameName = new Title("The Marck Of The Damned", new Vector2f(100.0f, 100.0f));
            if (Joystick.IsConnected(0))
            {
                text = new Title("PRESS 'START' TO CONTINUE", new Vector2f(100.0f,500.0f));
            }
            else
            {
                text = new Title("PRESS 'ENTER' TO CONTINUE", new Vector2f(100.0F, 500.0F));
            }
            exitMenu = false;
        }

        public void Update()
        {
            if (Joystick.IsConnected(0))
            {
                if (Joystick.IsButtonPressed(0, JoystickUtils.GetButton(JoystickType.XBOX360, GameButtons.ExtraRightButton)))
                {
                    exitMenu = true;
                } 
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Enter))
            {
                exitMenu = true;
            }
        }

        public void Draw(RenderWindow window)
        {
            menuBackground.Draw(window);
            GameName.Draw(window);
            text.Draw(window);
        }

    }
}
