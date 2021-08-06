using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMTD
{
    public class Title
    {
        private Text title;
        public Title(string text, Vector2f position)
        {
            Font arial = new Font("Fonts" + Path.DirectorySeparatorChar + "arial.ttf");
            title = new Text(text, arial);
            title.Position = position;
        }

        public void Draw(RenderWindow window)
        {
            title.Draw(window, RenderStates.Default);
        }
    }
}
