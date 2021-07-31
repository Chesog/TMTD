using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;
using System.IO;

namespace TMTD
{
    class Player : GameObjetBase
    {
        enum Status {IdleR, IdleL , MovingR , MovingL , JumpR , JumpL , Attk1R , Attk1L , Attk2R , Attk2L , ShootR , ShootL , BlockR , BlockL , BlockedR , BlockedL , RollR , RollL , HangR , HangL , HitR , HitL , DeadR , DeadL };
        private int sheetColums = 10;
        private int sheetRows = 18;
        private float speed;
        public List<Bullet> bullets;
        private float Timer;
        private float RateOfFire;
        private float fireDelay;
        private string Name;
        private int MaxLife;
        private int Life;
        private int MaxMana;
        private int Mana;
        private int MinAtkk;
        private int MaxAttk;
        private Locations location;
        private float GravitySpeed;
        private Status status;
        Clock FrameTimer;
        private IntRect frameRect;
        private List<List<Vector2i>> animations;  
        private float animTime = 1.5f;
        private int CurrentFrame = 0;
        private char LastDirectionPresed;

        public Player() : base("Player" + Path.DirectorySeparatorChar + "Sprites" + Path.DirectorySeparatorChar + "PlayerAnimations" + Path.DirectorySeparatorChar + "PlayerMovement.png", new Vector2f(0.0f, 0.0f))
        {

        }
        public Player(string Name, int MaxLife, int MaxMana, int MinAttk, int MaxAttk, Locations spawnpoint) : base("Player" + Path.DirectorySeparatorChar + "Sprites" + Path.DirectorySeparatorChar + "PlayerAnimations" + Path.DirectorySeparatorChar + "PlayerMovement3.png", new Vector2f(0.0f, 0.0f))
        {

            this.Name = Name;
            this.MaxLife = MaxLife;
            this.Life = MaxLife;
            this.MaxMana = MaxMana;
            this.MinAtkk = MinAttk;
            this.MaxAttk = MaxAttk;
            this.Mana = MaxMana;

            location = spawnpoint;
            bullets = new List<Bullet>();
            frameRect = new IntRect();
            frameRect.Width = (int)texture.Size.X / sheetColums;
            frameRect.Height = (int)texture.Size.Y / sheetRows;
            sprite.TextureRect = frameRect;
            sprite.Position = CurrentPosition;
            sprite.Scale = new Vector2f(2.0f, 2.0f);
            speed = 250.0f;
            RateOfFire = 1.0f;
            GravitySpeed = 3.0f;
            FrameTimer = new Clock();
            animations = new List<List<Vector2i>>();
            #region IdleRight
            animations.Add(new List<Vector2i>());
            animations[(int)Status.IdleR].Add(new Vector2i(0, 0));
            animations[(int)Status.IdleR].Add(new Vector2i(1, 0));
            animations[(int)Status.IdleR].Add(new Vector2i(2, 0));
            animations[(int)Status.IdleR].Add(new Vector2i(3, 0));
            animations[(int)Status.IdleR].Add(new Vector2i(4, 0));
            animations[(int)Status.IdleR].Add(new Vector2i(5, 0));
            animations[(int)Status.IdleR].Add(new Vector2i(6, 0));
            animations[(int)Status.IdleR].Add(new Vector2i(7, 0));
            #endregion
            #region IdleLeft
            animations.Add(new List<Vector2i>());
            animations[(int)Status.IdleL].Add(new Vector2i(0, 9));
            animations[(int)Status.IdleR].Add(new Vector2i(1, 9));
            animations[(int)Status.IdleR].Add(new Vector2i(2, 9));
            animations[(int)Status.IdleR].Add(new Vector2i(3, 9));
            animations[(int)Status.IdleR].Add(new Vector2i(4, 9));
            animations[(int)Status.IdleR].Add(new Vector2i(5, 9));
            animations[(int)Status.IdleR].Add(new Vector2i(6, 9));
            #endregion
            #region MovementRight
            animations.Add(new List<Vector2i>());
            animations[(int)Status.MovingR].Add(new Vector2i(8, 0));
            animations[(int)Status.MovingR].Add(new Vector2i(9, 0));
            animations[(int)Status.MovingR].Add(new Vector2i(0, 1));
            animations[(int)Status.MovingR].Add(new Vector2i(1, 1));
            animations[(int)Status.MovingR].Add(new Vector2i(2, 1));
            animations[(int)Status.MovingR].Add(new Vector2i(3, 1));
            animations[(int)Status.MovingR].Add(new Vector2i(4, 1));
            animations[(int)Status.MovingR].Add(new Vector2i(5, 1));
            animations[(int)Status.MovingR].Add(new Vector2i(6, 1));
            animations[(int)Status.MovingR].Add(new Vector2i(7, 1));
            #endregion
            #region MovementLeft
            animations.Add(new List<Vector2i>());
            animations[(int)Status.MovingL].Add(new Vector2i(8, 9));
            animations[(int)Status.MovingL].Add(new Vector2i(9, 9));
            animations[(int)Status.MovingL].Add(new Vector2i(0, 10));
            animations[(int)Status.MovingL].Add(new Vector2i(1, 10));
            animations[(int)Status.MovingL].Add(new Vector2i(2, 10));
            animations[(int)Status.MovingL].Add(new Vector2i(3, 10));
            animations[(int)Status.MovingL].Add(new Vector2i(4, 10));
            animations[(int)Status.MovingL].Add(new Vector2i(5, 10));
            animations[(int)Status.MovingL].Add(new Vector2i(6, 10));
            animations[(int)Status.MovingL].Add(new Vector2i(7, 10));
            #endregion
            #region AttackRight
            animations.Add(new List<Vector2i>());
            animations[(int)Status.Attk1R].Add(new Vector2i(8, 1));
            animations[(int)Status.Attk1R].Add(new Vector2i(9, 1));
            animations[(int)Status.Attk1R].Add(new Vector2i(0, 2));
            animations[(int)Status.Attk1R].Add(new Vector2i(1, 2));
            animations[(int)Status.Attk1R].Add(new Vector2i(2, 2));
            #endregion
            #region AttackLeft
            animations.Add(new List<Vector2i>());
            animations[(int)Status.Attk1L].Add(new Vector2i(8, 10));
            animations[(int)Status.Attk1L].Add(new Vector2i(9, 10));
            animations[(int)Status.Attk1L].Add(new Vector2i(0, 11));
            animations[(int)Status.Attk1L].Add(new Vector2i(1, 11));
            animations[(int)Status.Attk1L].Add(new Vector2i(2, 11));
            #endregion
            #region Attack2Right
            animations.Add(new List<Vector2i>());
            animations[(int)Status.Attk2R].Add(new Vector2i(3, 2));
            animations[(int)Status.Attk2R].Add(new Vector2i(4, 2));
            animations[(int)Status.Attk2R].Add(new Vector2i(5, 2));
            animations[(int)Status.Attk2R].Add(new Vector2i(6, 2));
            animations[(int)Status.Attk2R].Add(new Vector2i(7, 2));
            animations[(int)Status.Attk2R].Add(new Vector2i(8, 2));
            animations[(int)Status.Attk2R].Add(new Vector2i(9, 2));
            #endregion
            #region Attack2Left
            animations.Add(new List<Vector2i>());
            animations[(int)Status.Attk2L].Add(new Vector2i(3, 11));
            animations[(int)Status.Attk2L].Add(new Vector2i(4, 11));
            animations[(int)Status.Attk2L].Add(new Vector2i(5, 11));
            animations[(int)Status.Attk2L].Add(new Vector2i(6, 11));
            animations[(int)Status.Attk2L].Add(new Vector2i(7, 11));
            animations[(int)Status.Attk2L].Add(new Vector2i(8, 11));
            animations[(int)Status.Attk2L].Add(new Vector2i(9, 11));
            #endregion
            #region ShootRight
            animations.Add(new List<Vector2i>());
            animations[(int)Status.ShootR].Add(new Vector2i(0, 3));
            animations[(int)Status.ShootR].Add(new Vector2i(1, 3));
            animations[(int)Status.ShootR].Add(new Vector2i(2, 3));
            animations[(int)Status.ShootR].Add(new Vector2i(3, 3));
            animations[(int)Status.ShootR].Add(new Vector2i(4, 3));
            animations[(int)Status.ShootR].Add(new Vector2i(5, 3));
            animations[(int)Status.ShootR].Add(new Vector2i(6, 3));
            #endregion
            #region ShootLeft
            animations.Add(new List<Vector2i>());
            animations[(int)Status.ShootL].Add(new Vector2i(0, 12));
            animations[(int)Status.ShootL].Add(new Vector2i(1, 12));
            animations[(int)Status.ShootL].Add(new Vector2i(2, 12));
            animations[(int)Status.ShootL].Add(new Vector2i(3, 12));
            animations[(int)Status.ShootL].Add(new Vector2i(4, 12));
            animations[(int)Status.ShootL].Add(new Vector2i(5, 12));
            animations[(int)Status.ShootL].Add(new Vector2i(6, 12));
            #endregion
            #region JumpRight
            animations.Add(new List<Vector2i>());
            animations[(int)Status.JumpR].Add(new Vector2i(7, 3));
            animations[(int)Status.JumpR].Add(new Vector2i(8, 3));
            animations[(int)Status.JumpR].Add(new Vector2i(9, 3));
            animations[(int)Status.JumpR].Add(new Vector2i(0, 4));
            animations[(int)Status.JumpR].Add(new Vector2i(1, 4));
            animations[(int)Status.JumpR].Add(new Vector2i(2, 4));
            animations[(int)Status.JumpR].Add(new Vector2i(3, 4));
            animations[(int)Status.JumpR].Add(new Vector2i(4, 4));
            #endregion
            #region JumpLeft
            animations.Add(new List<Vector2i>());
            animations[(int)Status.JumpL].Add(new Vector2i(7, 12));
            animations[(int)Status.JumpL].Add(new Vector2i(8, 12));
            animations[(int)Status.JumpL].Add(new Vector2i(9, 12));
            animations[(int)Status.JumpL].Add(new Vector2i(0, 13));
            animations[(int)Status.JumpL].Add(new Vector2i(1, 13));
            animations[(int)Status.JumpL].Add(new Vector2i(2, 13));
            animations[(int)Status.JumpL].Add(new Vector2i(3, 13));
            animations[(int)Status.JumpL].Add(new Vector2i(4, 13));
            #endregion
            #region HitRight
            animations.Add(new List<Vector2i>());
            animations[(int)Status.HitR].Add(new Vector2i(5, 4));
            animations[(int)Status.HitR].Add(new Vector2i(6, 4));
            animations[(int)Status.HitR].Add(new Vector2i(7, 4));
            #endregion
            #region HitLeft
            animations.Add(new List<Vector2i>());
            animations[(int)Status.HitL].Add(new Vector2i(5, 13));
            animations[(int)Status.HitL].Add(new Vector2i(6, 13));
            animations[(int)Status.HitL].Add(new Vector2i(7, 13));
            #endregion
            #region DeadRight
            animations.Add(new List<Vector2i>());
            animations[(int)Status.DeadR].Add(new Vector2i(8, 4));
            animations[(int)Status.DeadR].Add(new Vector2i(9, 4));
            animations[(int)Status.DeadR].Add(new Vector2i(0, 5));
            animations[(int)Status.DeadR].Add(new Vector2i(1, 5));
            animations[(int)Status.DeadR].Add(new Vector2i(2, 5));
            animations[(int)Status.DeadR].Add(new Vector2i(3, 5));
            animations[(int)Status.DeadR].Add(new Vector2i(4, 5));
            animations[(int)Status.DeadR].Add(new Vector2i(5, 5));
            animations[(int)Status.DeadR].Add(new Vector2i(6, 5));
            animations[(int)Status.DeadR].Add(new Vector2i(7, 5));
            #endregion
            #region DeadLeft
            animations.Add(new List<Vector2i>());
            animations[(int)Status.DeadL].Add(new Vector2i(8, 13));
            animations[(int)Status.DeadL].Add(new Vector2i(9, 13));
            animations[(int)Status.DeadL].Add(new Vector2i(0, 14));
            animations[(int)Status.DeadL].Add(new Vector2i(1, 14));
            animations[(int)Status.DeadL].Add(new Vector2i(2, 14));
            animations[(int)Status.DeadL].Add(new Vector2i(3, 14));
            animations[(int)Status.DeadL].Add(new Vector2i(4, 14));
            animations[(int)Status.DeadL].Add(new Vector2i(5, 14));
            animations[(int)Status.DeadL].Add(new Vector2i(6, 14));
            animations[(int)Status.DeadL].Add(new Vector2i(7, 14));
            #endregion
            #region BlockRight
            animations.Add(new List<Vector2i>());
            animations[(int)Status.BlockR].Add(new Vector2i(8, 5));
            animations[(int)Status.BlockR].Add(new Vector2i(9, 5));
            animations[(int)Status.BlockR].Add(new Vector2i(0, 6));
            animations[(int)Status.BlockR].Add(new Vector2i(1, 6));
            animations[(int)Status.BlockR].Add(new Vector2i(2, 6));
            animations[(int)Status.BlockR].Add(new Vector2i(3, 6));
            animations[(int)Status.BlockR].Add(new Vector2i(4, 6));
            animations[(int)Status.BlockR].Add(new Vector2i(5, 6));
            #endregion
            #region BlockLeft
            animations.Add(new List<Vector2i>());
            animations[(int)Status.BlockL].Add(new Vector2i(8, 14));
            animations[(int)Status.BlockL].Add(new Vector2i(9, 14));
            animations[(int)Status.BlockL].Add(new Vector2i(0, 15));
            animations[(int)Status.BlockL].Add(new Vector2i(1, 15));
            animations[(int)Status.BlockL].Add(new Vector2i(2, 15));
            animations[(int)Status.BlockL].Add(new Vector2i(3, 15));
            animations[(int)Status.BlockL].Add(new Vector2i(4, 15));
            animations[(int)Status.BlockL].Add(new Vector2i(5, 15));
            #endregion
            #region BlockedRight
            animations.Add(new List<Vector2i>());
            animations[(int)Status.BlockedR].Add(new Vector2i(6, 6));
            animations[(int)Status.BlockedR].Add(new Vector2i(7, 6));
            animations[(int)Status.BlockedR].Add(new Vector2i(8, 6));
            animations[(int)Status.BlockedR].Add(new Vector2i(9, 6));
            animations[(int)Status.BlockedR].Add(new Vector2i(0, 7));
            #endregion
            #region BlockedLeft
            animations.Add(new List<Vector2i>());
            animations[(int)Status.BlockedL].Add(new Vector2i(6, 15));
            animations[(int)Status.BlockedL].Add(new Vector2i(7, 15));
            animations[(int)Status.BlockedL].Add(new Vector2i(8, 15));
            animations[(int)Status.BlockedL].Add(new Vector2i(9, 15));
            animations[(int)Status.BlockedL].Add(new Vector2i(0, 16));
            #endregion
            #region RollRight
            animations.Add(new List<Vector2i>());
            animations[(int)Status.RollR].Add(new Vector2i(1, 7));
            animations[(int)Status.RollR].Add(new Vector2i(2, 7));
            animations[(int)Status.RollR].Add(new Vector2i(3, 7));
            animations[(int)Status.RollR].Add(new Vector2i(4, 7));
            animations[(int)Status.RollR].Add(new Vector2i(5, 7));
            animations[(int)Status.RollR].Add(new Vector2i(6, 7));
            animations[(int)Status.RollR].Add(new Vector2i(7, 7));
            animations[(int)Status.RollR].Add(new Vector2i(8, 7));
            animations[(int)Status.RollR].Add(new Vector2i(9, 7));
            #endregion
            #region RollLeft
            animations.Add(new List<Vector2i>());
            animations[(int)Status.RollL].Add(new Vector2i(1, 16));
            animations[(int)Status.RollL].Add(new Vector2i(2, 16));
            animations[(int)Status.RollL].Add(new Vector2i(3, 16));
            animations[(int)Status.RollL].Add(new Vector2i(4, 16));
            animations[(int)Status.RollL].Add(new Vector2i(5, 16));
            animations[(int)Status.RollL].Add(new Vector2i(6, 16));
            animations[(int)Status.RollL].Add(new Vector2i(7, 16));
            animations[(int)Status.RollL].Add(new Vector2i(8, 16));
            animations[(int)Status.RollL].Add(new Vector2i(9, 16));
            #endregion
            #region HangRight
            animations.Add(new List<Vector2i>());
            animations[(int)Status.HangR].Add(new Vector2i(0, 8));
            animations[(int)Status.HangR].Add(new Vector2i(1, 8));
            animations[(int)Status.HangR].Add(new Vector2i(2, 8));
            animations[(int)Status.HangR].Add(new Vector2i(3, 8));
            animations[(int)Status.HangR].Add(new Vector2i(4, 8));
            animations[(int)Status.HangR].Add(new Vector2i(5, 8));
            animations[(int)Status.HangR].Add(new Vector2i(6, 8));
            animations[(int)Status.HangR].Add(new Vector2i(7, 8));
            animations[(int)Status.HangR].Add(new Vector2i(8, 8));
            animations[(int)Status.HangR].Add(new Vector2i(9, 8));
            #endregion
            #region HangLeft
            animations.Add(new List<Vector2i>());
            animations[(int)Status.HangL].Add(new Vector2i(0, 17));
            animations[(int)Status.HangL].Add(new Vector2i(1, 17));
            animations[(int)Status.HangL].Add(new Vector2i(2, 17));
            animations[(int)Status.HangL].Add(new Vector2i(3, 17));
            animations[(int)Status.HangL].Add(new Vector2i(4, 17));
            animations[(int)Status.HangL].Add(new Vector2i(5, 17));
            animations[(int)Status.HangL].Add(new Vector2i(6, 17));
            animations[(int)Status.HangL].Add(new Vector2i(7, 17));
            animations[(int)Status.HangL].Add(new Vector2i(8, 17));
            animations[(int)Status.HangL].Add(new Vector2i(9, 17));
            #endregion

        }


        public override void Update()
        {
            Movement();
            UpdateAnimation();
            Atakk();
            Gravity();
            base.Update();

        }
        public override void Draw(RenderWindow window)
        {
            base.Draw(window);
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i] != null)
                {
                    bullets[i].Draw(window);
                }
            }
        }
        public void UpdateAnimation()
        {
            switch (status)
            {
                case Status.IdleR:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.IdleR].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame == animations[(int)Status.IdleR].Count)
                        {
                            CurrentFrame = 0;
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.IdleR][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.IdleR][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.IdleL:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.IdleL].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame == animations[(int)Status.IdleL].Count)
                        {
                            CurrentFrame = 0;
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.IdleL][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.IdleL][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.MovingR:

                    break;
                case Status.MovingL:
                    break;
                case Status.JumpR:
                    break;
                case Status.JumpL:
                    break;
                case Status.Attk1R:
                    break;
                case Status.Attk1L:
                    break;
                case Status.Attk2R:
                    break;
                case Status.Attk2L:
                    break;
                case Status.ShootR:
                    break;
                case Status.ShootL:
                    break;
                case Status.BlockR:
                    break;
                case Status.BlockL:
                    break;
                case Status.BlockedR:
                    break;
                case Status.BlockedL:
                    break;
                case Status.RollR:
                    break;
                case Status.RollL:
                    break;
                case Status.HangR:
                    break;
                case Status.HangL:
                    break;
                case Status.HitR:
                    break;
                case Status.HitL:
                    break;
                case Status.DeadR:
                    break;
                case Status.DeadL:
                    break;
                default:
                    break;
            }
            sprite.TextureRect = frameRect;
        }
        private void Movement()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                CurrentPosition.X += speed * FrameRate.GetDeltaTime();
                status = Status.MovingR;
                LastDirectionPresed = 'D';
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                CurrentPosition.X -= speed * FrameRate.GetDeltaTime();
                status = Status.MovingL;
                LastDirectionPresed = 'A';
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                CurrentPosition.Y -= speed * FrameRate.GetDeltaTime();
                status = Status.JumpR;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                CurrentPosition.Y += speed * FrameRate.GetDeltaTime();
                status = Status.RollR;
            }
            bool IsMovingHorizontally = !Keyboard.IsKeyPressed(Keyboard.Key.A) && !Keyboard.IsKeyPressed(Keyboard.Key.D);
            bool IsMovingVertically = !Keyboard.IsKeyPressed(Keyboard.Key.W) && !Keyboard.IsKeyPressed(Keyboard.Key.S);
            if (IsMovingHorizontally && IsMovingVertically)
            {
                if (LastDirectionPresed == 'A')
                {
                    status = Status.IdleR;
                }
                else if (LastDirectionPresed == 'D')
                {
                    status = Status.IdleL;
                }
            }

        }
        private void Gravity()
        {
            CurrentPosition.Y += GravitySpeed * FrameRate.GetDeltaTime();
            GravitySpeed += 0.02f;
        }
        private void Atakk()
        {

            if (Keyboard.IsKeyPressed(Keyboard.Key.K))
            {

            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.L))
            {

            }
        }
        private void Shoot() 
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.J) && fireDelay >= RateOfFire)
            {
                if (LastDirectionPresed == 'D')
                {
                  status = Status.ShootR;
                  Vector2f spawnposition = CurrentPosition;
                  spawnposition.X += (texture.Size.X * sprite.Scale.X) / 2.0f;
                  spawnposition.Y += (texture.Size.Y * sprite.Scale.Y) / 2.0f;
                  bullets.Add(new Bullet(spawnposition));
                    fireDelay = 0.0f;
                }
                else if (LastDirectionPresed == 'A')
                {
                    status = Status.ShootL;
                    status = Status.ShootR;
                    Vector2f spawnposition = CurrentPosition;
                    spawnposition.X += (texture.Size.X * sprite.Scale.X) / 2.0f;
                    spawnposition.Y += (texture.Size.Y * sprite.Scale.Y) / 2.0f;
                    bullets.Add(new Bullet(spawnposition));
                    fireDelay = 0.0f;
                }
            }
        }
        public void HealPlayer()
        {
            Life = MaxLife;
        }
        public void HealPlayer(int Amount)
        {
            Life += Amount;
            if (Life > MaxLife)
            {
                Life = MaxLife;
            }
        }
        public void RestoreMana()
        {
            Mana = MaxMana;
        }
        public void RestoreMana(int Amount)
        {
            Mana += Amount;
            if (Mana > MaxMana)
            {
                Mana = MaxMana;
            }
        }
        public Locations GetLocations()
        {
            return location;
        }
        public void GoToShop()
        {
            location = Locations.Shop;
        }
        public void GoToVillage()
        {
            location = Locations.Village;
        }
        public void GoToForest()
        {
            location = Locations.Forest;
        }
        public void GoToHome()
        {
            location = Locations.Home;
        }
        public void GoToCastle()
        {
            location = Locations.Castle;
        }
        public void RestPlayer() { }


    }

}






