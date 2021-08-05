using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace TMTD
{
    public abstract class AnimatedObjetBase : GameObjetBase
    {
       
        protected Clock FrameTimer;
        protected IntRect frameRect;
        protected int sheetColums = 10;
        protected int sheetRows = 18;
        protected List<List<Vector2i>> animations;
        protected float animTime = 1.0f;
        protected int CurrentFrame = 0;
        protected char LastDirectionPresed;
        public AnimatedObjetBase(string texturePath , Vector2f startposition , int SheetColums , int SheetRows) : base (texturePath, startposition)
        {
            frameRect = new IntRect();
            frameRect.Width = (int)texture.Size.X / sheetColums;
            frameRect.Height = (int)texture.Size.Y / sheetRows;
            sprite.TextureRect = frameRect;
        }
    }
}
