using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;

namespace BruhBoy
{
    public abstract class Character
    {
        private float ground { get; set; } = 400;
        Timer JumpTimer;
        public bool IsJumping { get; set; } = false;
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Direction FacingDirection { get; set; }

        public Character()
        {
            FacingDirection = Direction.Right;
        }
        public void Gravity()
        {
            if (Position.Y != ground)
            {
                Position = ChangePos(Position.X, Position.Y + 10);
            }
        }
        public Vector2 ChangePos(float X, float Y)
        {
            Vector2 pos = new Vector2();
            pos.X = X;
            pos.Y = Y;
            return pos;
        }
        public void Movement()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) && Position.Y == ground && IsJumping == false)
            {
                Jump();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Position = ChangePos(Position.X + 3, Position.Y);
                FacingDirection = Direction.Right;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Position = ChangePos(Position.X - 3, Position.Y);
                FacingDirection = Direction.Left;
            }
        }
        public void Jump()
        {
            IsJumping = true;
            SetTimer(100);

        }

        public void SetTimer(int interval)
        {
            JumpTimer = new Timer(interval);
            JumpTimer.Elapsed += OnTimerElapsed;
            JumpTimer.AutoReset = true;
            JumpTimer.Enabled = true;
        }

        public void OnTimerElapsed(object source, ElapsedEventArgs e)
        {

        }
    }
}
