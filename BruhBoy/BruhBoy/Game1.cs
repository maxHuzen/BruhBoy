using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Threading;

namespace BruhBoy
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        List<Character> characters;
        List<Terrain> terrain;
        Color[] greenColor;
        Color[] redColor;
        BruhBoy Player;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Dictionary<string, SoundEffect> fx;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            fx = new Dictionary<string, SoundEffect>();
            Player = new BruhBoy();
            characters = new List<Character>();
            terrain = new List<Terrain>();
            #region threads
            //Creates new thread to handle movement
            Thread Movement = new Thread(() =>
            {
                while (true)
                {
                    Player.Movement();
                    Thread.Sleep(10);
                }
            });
            Thread Gravity = new Thread(() =>
            {
                while (true)
                {
                    foreach (Character ch in characters)
                    {
                        if (ch is IGravity)
                        {
                            ch.Gravity();
                        }
                    }
                }
            });
            Gravity.Start();
            Movement.Start();
            #endregion
            CreateColors();
            characters.Add(Player);

            Content.RootDirectory = "Content";

        }
        #region Colors
        public void CreateColors()
        {
            redColor = new Color[10 * 30];
            for (int i = 0; i < 300; i++)
                redColor[i] = Color.Red;

            greenColor = new Color[10 * 30];
            for (int i = 0; i < 300; i++)
                greenColor[i] = Color.Green;
        }
        #endregion

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Player.Texture = new Texture2D(this.GraphicsDevice, 10, 30);
            Player.Texture.SetData<Color>(greenColor);
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            fx.Add("deathSound", Content.Load<SoundEffect>("Sound\\Bruh"));
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();




            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(Player.Texture, Player.Position);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
