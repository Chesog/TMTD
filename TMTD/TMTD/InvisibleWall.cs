using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace TMTD
{
    class InvisibleWall : IColicionable
    {
        private Vector2f position;
        private Vector2f Size;
        public bool ToDelete;
        public InvisibleWall(Vector2f position, Vector2f size) 
        {

            this.position = position;
            this.Size = size;
            ToDelete = false;
            CollitionManager.Getinstance().addToColitionManeger(this);
        }

        public FloatRect GetBounds()
        {
            return new FloatRect(position, Size);
        }

        public void OnColitionEnter(IColicionable other)
        {
            if (other is Player)
            {
                ToDelete = true;
            }
        }

        public void OnColitionExit(IColicionable other)
        {
            
        }

        public void OnColitionStay(IColicionable other)
        {

        }
        public void RemoveFromColitionManager() 
        {
            CollitionManager.Getinstance().removeFromColitionManager(this);
        }
    }
}
