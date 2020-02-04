using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BruhBoy
{
    public abstract class Character
    {
        public bool IsJumping { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Direction FacingDirection { get; set; }

        public Character()
        {
            IsJumping = false;
            FacingDirection = Direction.Right;

        }
        public void Gravity()
        {
            if (this.Position.Y < 400)
            {
                Position = ChangePos(this.Position.X, this.Position.Y + 3);
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
            if (Keyboard.GetState().IsKeyDown(Keys.W) && Position.Y == 402)
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
            while (!IsJumping)
            {

            }
        }
    }
}
