using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TapTitanXNA_AllenEsperanza
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Properties
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ContentManager content;
        Level level;
        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            this.content = Content;
            level = new Level(Content);

            graphics.PreferredBackBufferWidth = Level.windowWidth;
            graphics.PreferredBackBufferHeight = Level.windowHeight;
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            level.LoadContent();
        }
 
        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            level.Update(gameTime);
            base.Update(gameTime);
        }
 
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Vector2 vect = new Vector2(600, 500);
            spriteBatch.Begin();
            level.Draw(gameTime, spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
