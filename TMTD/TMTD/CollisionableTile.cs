using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMTD
{
    class CollisionableTile : Tile , IColicionable
    {
        public CollisionableTile(Texture texture, Vector2f position, Vector2f scale) : base(texture, position, scale)
        {
            CollitionManager.Getinstance().addToColitionManeger(this);
        }

        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }

        public void OnColitionEnter(IColicionable other)
        {

        }

        public void OnColitionExit(IColicionable other)
        {

        }

        public void OnColitionStay(IColicionable other)
        {

        }
    }
}

