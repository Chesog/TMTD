using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace TMTD
{
    public class Camera 
    {
        private static Camera instance;
        public static Camera GetInstance() 
        {
            if (instance == null)
            {
                instance = new Camera();
            }
            return instance;
        }

        private RenderWindow window;
        private View view;
        private Vector2f currentPosition;
        private Camera() 
        {

        }
        public void InitCamera(RenderWindow window) 
        {
            this.window = window;
            view = window.GetView();
            currentPosition = view.Center;
        }
        public void UpdateCamera(Vector2f newCenter) 
        {
            view.Center = newCenter;
            window.SetView(view);
        }
    }
}
