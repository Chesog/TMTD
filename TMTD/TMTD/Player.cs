using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;
using System.IO;

namespace TMTD
{
    class Player : AnimatedObjetBase, IColicionable
    {
        public enum Status { IdleR, IdleL, MovingR, MovingL, Attk1R, Attk1L, Attk2R, Attk2L, ShootR, ShootL, JumpR, JumpL, HitR, HitL, DeadR, DeadL, BlockR, BlockL, BlockedR, BlockedL, RollR, RollL, HangR, HangL, };

        private float speed;
        public List<Bullet> bullets;
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


        public Player(int SheetColums, int SheetRows) : base("Player" + Path.DirectorySeparatorChar + "Sprites" + Path.DirectorySeparatorChar + "PlayerAnimations" + Path.DirectorySeparatorChar + "PlayerMovement3.png", new Vector2f(0.0f, 0.0f), SheetColums, SheetRows)
        {

        }
        public Player(string Name, int MaxLife, int MaxMana, int MinAttk, int MaxAttk, Locations spawnpoint, int SheetColums, int SheetRows) : base("Player" + Path.DirectorySeparatorChar + "Sprites" + Path.DirectorySeparatorChar + "PlayerAnimations" + Path.DirectorySeparatorChar + "PlayerMovement3.png", new Vector2f(-10.0f, 0.0f), SheetColums, SheetRows)
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
            CollitionManager.Getinstance().addToColitionManeger(this);

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
            animations[(int)Status.IdleL].Add(new Vector2i(1, 9));
            animations[(int)Status.IdleL].Add(new Vector2i(2, 9));
            animations[(int)Status.IdleL].Add(new Vector2i(3, 9));
            animations[(int)Status.IdleL].Add(new Vector2i(4, 9));
            animations[(int)Status.IdleL].Add(new Vector2i(5, 9));
            animations[(int)Status.IdleL].Add(new Vector2i(6, 9));
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
            Shoot();
            CheckGarbage();
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
        private void SetStatus(Status changestatus)
        {

            status = changestatus;
            if (CurrentFrame >= animations[(int)changestatus].Count - 1)
            {
                CurrentFrame = 0;
                FrameTimer.Restart();
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
                        if (CurrentFrame >= animations[(int)Status.IdleR].Count - 1)
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
                        if (CurrentFrame >= animations[(int)Status.IdleL].Count - 1)
                        {
                            CurrentFrame = 0;
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.IdleL][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.IdleL][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.MovingR:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.MovingR].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.MovingR].Count - 1)
                        {
                            CurrentFrame = 0;
                            SetStatus(Status.IdleR);
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.MovingR][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.MovingR][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.MovingL:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.MovingL].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.MovingL].Count - 1)
                        {
                            CurrentFrame = 0;
                            SetStatus(Status.IdleL);
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.MovingL][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.MovingL][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.Attk1R:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.Attk1R].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.Attk1R].Count - 1)
                        {
                            CurrentFrame = 0;
                            SetStatus(Status.Attk2R);
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.Attk1R][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.Attk1R][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.Attk1L:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.Attk1L].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.Attk1L].Count - 1)
                        {
                            CurrentFrame = 0;
                            SetStatus(Status.Attk2L);
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.Attk1L][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.Attk1L][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.Attk2R:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.Attk2R].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.Attk2R].Count - 1)
                        {
                            CurrentFrame = 0;
                            SetStatus(Status.IdleR);
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.Attk2R][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.Attk2R][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.Attk2L:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.Attk2L].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.Attk2L].Count - 1)
                        {
                            CurrentFrame = 0;
                            SetStatus(Status.IdleL);
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.Attk2L][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.Attk2L][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.ShootR:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.ShootR].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.ShootR].Count - 1)
                        {
                            CurrentFrame = 0;
                            SetStatus(Status.IdleR);
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.ShootR][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.ShootR][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.ShootL:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.ShootL].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.ShootL].Count - 1)
                        {
                            CurrentFrame = 0;
                            SetStatus(Status.IdleL);
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.ShootL][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.ShootL][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.JumpR:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.JumpR].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.JumpR].Count - 1)
                        {
                            CurrentFrame = 0;
                            SetStatus(Status.IdleR);
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.JumpR][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.JumpR][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.JumpL:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.JumpL].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.JumpL].Count - 1)
                        {
                            CurrentFrame = 0;
                            SetStatus(Status.IdleL);
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.JumpL][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.JumpL][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.HitR:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.HitR].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.HitR].Count - 1)
                        {
                            CurrentFrame = 0;
                            SetStatus(Status.IdleR);
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.HitR][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.HitR][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.HitL:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.HitL].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.HitL].Count - 1)
                        {
                            CurrentFrame = 0;
                            SetStatus(Status.IdleL);
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.HitL][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.HitL][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.DeadR:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.DeadR].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.IdleL].Count - 1)
                        {
                            CurrentFrame = 0;
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.DeadR][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.DeadR][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.DeadL:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.DeadL].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.DeadL].Count - 1)
                        {
                            CurrentFrame = 0;
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.DeadL][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.DeadL][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.BlockR:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.BlockR].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.BlockR].Count - 1)
                        {
                            CurrentFrame = 0;
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.BlockR][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.BlockR][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.BlockL:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.BlockL].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.BlockL].Count - 1)
                        {
                            CurrentFrame = 0;
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.BlockL][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.BlockL][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.BlockedR:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.BlockedR].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.BlockedR].Count - 1)
                        {
                            CurrentFrame = 0;
                            SetStatus(Status.BlockR);
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.BlockedR][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.BlockedR][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.BlockedL:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.BlockedL].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.BlockedL].Count - 1)
                        {
                            CurrentFrame = 0;
                            SetStatus(Status.BlockL);
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.BlockedL][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.BlockedL][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.RollR:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.RollR].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.RollR].Count - 1)
                        {
                            CurrentFrame = 0;
                            SetStatus(Status.IdleR);
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.RollR][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.RollR][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.RollL:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.RollL].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.RollL].Count - 1)
                        {
                            CurrentFrame = 0;
                            SetStatus(Status.IdleL);
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.RollL][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.RollL][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.HangR:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.HangR].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.HangR].Count - 1)
                        {
                            CurrentFrame = 0;
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.HangR][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.HangR][CurrentFrame].Y * frameRect.Height;
                    break;
                case Status.HangL:
                    if (FrameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.HangL].Count)
                    {
                        CurrentFrame++;
                        if (CurrentFrame >= animations[(int)Status.HangL].Count - 1)
                        {
                            CurrentFrame = 0;
                        }
                        FrameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.HangL][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.HangL][CurrentFrame].Y * frameRect.Height;
                    break;
                default:
                    SetStatus(Status.IdleR);
                    frameRect.Left = animations[(int)Status.IdleR][CurrentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.IdleR][CurrentFrame].Y * frameRect.Height;
                    break;
            }
            sprite.TextureRect = frameRect;
        }
        private void Movement()
        {
            if (Joystick.IsConnected(0))
            {
                if (JoystickUtils.GetAxis(0, Joystick.Axis.X) != 0)
                {
                    CurrentPosition.X += JoystickUtils.GetAxis(0, Joystick.Axis.X) * speed * FrameRate.GetDeltaTime();
                }
                if (JoystickUtils.GetAxis(0, Joystick.Axis.Y) != 0)
                {
                    CurrentPosition.Y += JoystickUtils.GetAxis(0, Joystick.Axis.Y) * speed * FrameRate.GetDeltaTime();
                }

                if (Joystick.IsButtonPressed(0, JoystickUtils.GetButton(JoystickType.XBOX360, GameButtons.MainButtonDown)))
                {
                    FrameRate.SetTimeScale(0.5f);
                }

                if (Joystick.IsButtonPressed(0, JoystickUtils.GetButton(JoystickType.XBOX360, GameButtons.MainButtonRight)))
                {
                    FrameRate.SetTimeScale(1.0f);
                }
                Vector2f cameracenter = CurrentPosition;
                cameracenter.X += sprite.Scale.X / 2.0f;
                cameracenter.Y += sprite.Scale.Y / 2.0f;
                Camera.GetInstance().UpdateCamera(cameracenter);
                AllBackground.GetInstance().UpdateBackgroundPosition(cameracenter);
            }
            else
            {
                
                if (status != Status.ShootL && status != Status.ShootR && status != Status.Attk1L && status != Status.Attk1R && status != Status.Attk2L && status != Status.Attk2R && status != Status.BlockL && status != Status.BlockR)
                {

                    if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                    {
                        CurrentPosition.X += speed * FrameRate.GetDeltaTime();
                        SetStatus(Status.MovingR);
                        LastDirectionPresed = 'D';
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                    {
                        CurrentPosition.X -= speed * FrameRate.GetDeltaTime();
                        SetStatus(Status.MovingL);
                        LastDirectionPresed = 'A';
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.W) || Keyboard.IsKeyPressed(Keyboard.Key.Space))
                    {
                        CurrentPosition.Y -= speed * FrameRate.GetDeltaTime();
                        if (LastDirectionPresed == 'A')
                        {
                            SetStatus(Status.JumpL);
                        }
                        else if (LastDirectionPresed == 'D')
                        {
                            SetStatus(Status.JumpR);
                        }

                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                    {
                        CurrentPosition.Y += speed * FrameRate.GetDeltaTime();
                        if (LastDirectionPresed == 'A')
                        {
                            SetStatus(Status.RollL);
                        }
                        else if (LastDirectionPresed == 'D')
                        {
                            SetStatus(Status.RollR);
                        }
                    }
                    bool IsMovingHorizontally = !Keyboard.IsKeyPressed(Keyboard.Key.A) && !Keyboard.IsKeyPressed(Keyboard.Key.D);
                    bool IsMovingVertically = !Keyboard.IsKeyPressed(Keyboard.Key.W) && !Keyboard.IsKeyPressed(Keyboard.Key.S);
                    bool IsInCombat = !Keyboard.IsKeyPressed(Keyboard.Key.K) && !Keyboard.IsKeyPressed(Keyboard.Key.J) && !Keyboard.IsKeyPressed(Keyboard.Key.L);
                    if (IsMovingHorizontally && IsMovingVertically && IsInCombat)
                    {
                        if (LastDirectionPresed == 'A')
                        {
                            SetStatus(Status.IdleL);
                        }
                        else if (LastDirectionPresed == 'D')
                        {
                            SetStatus(Status.IdleR);
                        }
                    }
                    Vector2f cameracenter = CurrentPosition;
                    cameracenter.X += sprite.Scale.X / 2.0f;
                    cameracenter.Y += sprite.Scale.Y / 2.0f;
                    Camera.GetInstance().UpdateCamera(cameracenter);
                }
            }

        }
        private void Gravity()
        {
            //CurrentPosition.Y += GravitySpeed * FrameRate.GetDeltaTime();
            //GravitySpeed += 1.5f;
        }
        private void Atakk()
        {

            if (Keyboard.IsKeyPressed(Keyboard.Key.K))
            {
                if (LastDirectionPresed == 'A')
                {
                    SetStatus(Status.BlockL);
                }
                else if (LastDirectionPresed == 'D')
                {
                    SetStatus(Status.BlockR);
                }
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.L))
            {
                if (LastDirectionPresed == 'A')
                {
                    SetStatus(Status.Attk1L);
                }
                else if (LastDirectionPresed == 'D')
                {
                    SetStatus(Status.Attk1R);
                }
            }
        }
        private void Shoot()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.J))
            {
                if (LastDirectionPresed == 'D')
                {
                    SetStatus(Status.ShootR);
                    Vector2f spawnposition = CurrentPosition;
                    spawnposition.X += (texture.Size.X * sprite.Scale.X) / 2.0f;
                    spawnposition.Y += (texture.Size.Y * sprite.Scale.Y) / 2.0f;
                    bullets.Add(new Bullet(spawnposition));
                    fireDelay = 0.0f;
                }
                else if (LastDirectionPresed == 'A')
                {
                    SetStatus(Status.ShootL);
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
        public Status GetStatus()
        {
            return status;
        }
        public void GoToShop()
        {
            location = Locations.Shop;
            AllBackground.GetInstance().UpdateBackground(location);
        }
        public void GoToVillage()
        {
            location = Locations.Village;
            AllBackground.GetInstance().UpdateBackground(location);
        }
        public void GoToForest()
        {
            location = Locations.Forest;
            AllBackground.GetInstance().UpdateBackground(location);
        }
        public void GoToHome()
        {
            location = Locations.Home;
            AllBackground.GetInstance().UpdateBackground(location);
        }
        public void GoToCastle()
        {
            location = Locations.Castle;
            AllBackground.GetInstance().UpdateBackground(location);
        }
        public void RestPlayer() { }

        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }
        public override void CheckGarbage()
        {
            List<int> indexToDelete = new List<int>();
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].CheckGarbage();
                if (bullets[i].toDelelte)
                {
                    indexToDelete.Add(i);
                }
            }
            for (int i = 0; i < indexToDelete.Count; i++)
            {
                bullets.RemoveAt(i);
            }
            if (toDelelte == true)
            {
                DisposeNow();
            }
            base.CheckGarbage();
        }
        public override void DisposeNow()
        {
            CollitionManager.Getinstance().removeFromColitionManager(this);
            base.DisposeNow();
        }
        public void OnColitionStay(IColicionable other)
        {
            if (other is Wall || other is CollisionableTile)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                {
                    CurrentPosition.X -= speed * FrameRate.GetDeltaTime();
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                {
                    CurrentPosition.X += speed * FrameRate.GetDeltaTime();
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.W) || Keyboard.IsKeyPressed(Keyboard.Key.Space))
                {
                    CurrentPosition.Y += speed * FrameRate.GetDeltaTime();
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                {
                    CurrentPosition.Y -= speed * FrameRate.GetDeltaTime();
                }
                GravitySpeed = 0;
            }
            if (other is InvisibleWall)
            {
                GoToForest();
                CurrentPosition.X = 0;
                CurrentPosition.Y = 0;
                MusicManager.GetInstance().SetIntroMusic();
            }
        }

        public void OnColitionEnter(IColicionable other)
        {

        }

        public void OnColitionExit(IColicionable other)
        {

        }
    }

}