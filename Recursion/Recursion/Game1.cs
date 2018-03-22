using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// IGME-106 - Game Development and Algorithmic Problem Solving                             
/// Group Project
/// Class Description   : 
/// Created By          : Benjamin Kleynhans
/// Creation Date       : March 21, 2018
/// Authors             : Benjamin Kleynhans
/// Last Modified By    : Benjamin Kleynhans
/// Last Modified Date  : March 21, 2018
/// Filename            : Game1.cs
/// </summary>

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

        SpriteFont spriteFont;

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
            graphics.PreferredBackBufferWidth = 1600;                           // Set desired width of window
            graphics.PreferredBackBufferHeight = 900;                           // Set desired height of window            
            graphics.ApplyChanges();

            Window.Position = new Point(                                        // Center the game view on the screen
                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) -
                    (graphics.PreferredBackBufferWidth / 2),
                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) -
                    (graphics.PreferredBackBufferHeight / 2)
            );

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

            //myTexture = Content.Load<Texture2D>("fractal");                               // A bunch of different images to make it look pretty
            //myTexture = Content.Load<Texture2D>("rectangle");
            //myTexture = Content.Load<Texture2D>("flames");
            myTexture = Content.Load<Texture2D>("smoke");

            spriteFont = Content.Load<SpriteFont>("spriteFont");
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

            spriteBatch.DrawString(
                spriteFont,                
                "Number of recursions: " + 
                    DrawRecursiveThing(                                                     // Call recursive method
                        x: 0,
                        y: 0, 
                        width: GraphicsDevice.Viewport.Width, 
                        height: GraphicsDevice.Viewport.Height, 
                        color: Color.White,
                        recursionCounter: 0
                    ),
                new Vector2(1150, 50),
                Color.White
            );

            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Recursive method that draws an image across the screen diagonally
        /// </summary>
        /// <param name="x">X coordinate of image</param>
        /// <param name="y">Y coordinate of image</param>
        /// <param name="width">Width of image</param>
        /// <param name="height">Height of image</param>
        /// <param name="color">Color of image</param>
        public int DrawRecursiveThing(int x, int y, int width, int height, Color color, int recursionCounter)
        {   
            if ((width > 20) && (height > 20))
            {                
                myRectangle = new Rectangle(x, y, width, height);

                spriteBatch.Draw(
                    myTexture,
                    myRectangle,
                    color
                );

                color = UpdateColor(color);

                recursionCounter = DrawRecursiveThing(                                                         // Call recursive method
                    x, 
                    y, 
                    width / 2, 
                    height / 2, 
                    color,
                    (recursionCounter + 1)
                );

                recursionCounter = DrawRecursiveThing(                                                         // Call recursive method
                    x + width / 2,
                    y + height / 2,
                    width / 2,
                    height / 2,
                    color,
                    recursionCounter
                );
            }

            return recursionCounter;
        }

        /// <summary>
        /// Changes the color used to draw the image
        /// </summary>
        /// <param name="color">Color property used to draw the image</param>
        /// <returns></returns>
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
