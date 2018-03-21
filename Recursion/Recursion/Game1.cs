using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Recursion
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D myTexture;
        Rectangle myRectangle;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            myTexture = Content.Load<Texture2D>("rectangle");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            DrawRecursiveThing(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, Color.White);

            spriteBatch.End();


            base.Draw(gameTime);
        }

        void DrawRecursiveThing(int x, int y, int width, int height, Color color)
        {
            
            if (((width - 20) > 0) && ((height - 20) > 0))
            {                
                myRectangle = new Rectangle(x, y, width, height);

                spriteBatch.Draw(
                    myTexture,
                    myRectangle,
                    color
                );

                color = UpdateColor(color);

                DrawRecursiveThing(x, y, width / 2, height / 2, color);
                DrawRecursiveThing(x+width/2, y+height/2 , width / 2, height / 2, color);
                System.Console.WriteLine("");
            } else
            {

            }
        }
        
        private Color UpdateColor(Color color)
        {
            if (color == Color.White)
            {
                color = Color.Blue;
            }
            else
            {
                color = Color.White;
            }

            return color;
        }            
    }
}
