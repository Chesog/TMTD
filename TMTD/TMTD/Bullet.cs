using SFML.Graphics;
using SFML.System;
using System;

namespace TMTD
{
    class Bullet
    {
        private Texture texture;
        private Sprite sprite;
        private Vector2f bulletposition;
        private float bulletspeed;
        public Bullet(Vector2f position)
        {
            texture = new Texture("Sprite/Fuego.png");
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f(0.1f, 0.1f);
            bulletposition = position;
            sprite.Position = bulletposition;
            bulletspeed = 250.0f;
        }
        public Vector2f GetBulletPosition()
        {
            return bulletposition;
        }
        public void Update()
        {
            bulletposition.X += bulletspeed * FrameRate.GetDeltaTime() ;
            Console.WriteLine("dispara");
            sprite.Position = bulletposition;
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
        }
        public void Delete()
        {
            sprite.Dispose();
            texture.Dispose();
        }
    }
}
