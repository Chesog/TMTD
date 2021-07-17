using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace TMTD
{
    class Player
    {
        private Sprite sprite;
        private Texture texture;
        public Vector2f position;
        private float speed;
        public List<Bullet> bullets;
        private float Timer;
        private float RateOfFire;
        public Player()
        {
            bullets = new List<Bullet>();
            texture = new Texture("Sprite/Mostro.png");
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f(1.0f, 1.0f);
            position = new Vector2f(0.0f, 0.0f);
            sprite.Position = position;
            speed = 250.0f;
            RateOfFire = 1.0f;
        }
        public void Update()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                position.X += (speed * (1.0f / (float)Game.FRAMERATE_LIMIT));
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                position.X -= (speed * (1.0f / (float)Game.FRAMERATE_LIMIT));
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                position.Y -= (speed * (1.0f / (float)Game.FRAMERATE_LIMIT));
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                position.Y += (speed * (1.0f / (float)Game.FRAMERATE_LIMIT));
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && Timer > RateOfFire)
            {
                bullets.Add(new Bullet(position));
                Timer = 0;
            }
            Timer += (1.0f / (float)Game.FRAMERATE_LIMIT);
            sprite.Position = position;
            if (bullets.Count > 0)
            {
                List<int> DeletBullet = new List<int>();
                for (int i = 0; i < bullets.Count; i++)
                {
                    bullets[i].Update();
                    if (bullets[i].GetBulletPosition().X > 800)
                    {
                        DeletBullet.Add(i);
                    }
                }
                for (int i = 0; i < DeletBullet.Count; i++)
                {
                    bullets.RemoveAt(DeletBullet[i]);
                    bullets[DeletBullet[i]].Delete();
                }
                DeletBullet.Clear();
            }
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i] != null)
                {
                    bullets[i].Draw(window);
                }
            }
        }
    }
}
}
