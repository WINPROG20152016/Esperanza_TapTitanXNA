using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace TapTitanXNA_AllenEsperanza
{
    public class Level
    {
        public static int windowWidth = 660;
        public static int windowHeight = 480;

        #region Properties
        ContentManager content;

        Texture2D background;
        public MouseState oldMouseState;
        public MouseState mouseState;
        bool mpressed, prev_mpressed = false;
        int mouseX, mouseY;

        Hero hero;

        SpriteFont damageStringFont;
        int damageNumber = 0;

        //Button playButton;
        Button attackButton;
        #endregion

        public Level(ContentManager content)
        {
            this.content = content;
            hero = new Hero(content, this);
        }

        public void LoadContent()
        {
            background = content.Load<Texture2D>("bg/gojirra");
            damageStringFont = content.Load<SpriteFont>("SpriteFont1");
            //playButton = new Button(content, "Button/yellow_button", new Vector2(200,200));
            attackButton = new Button(content, "Button/yellow_button.fw", new Vector2(200, 350));
            hero.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            mouseX = mouseState.X;
            mouseY = mouseState.Y;
            prev_mpressed = mpressed;
            mpressed = mouseState.LeftButton == ButtonState.Pressed;

            hero.Update(gameTime);

            oldMouseState = mouseState;

            if (attackButton.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed))
            {
                damageNumber += 1;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            hero.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(damageStringFont, damageNumber+" Damage", new Vector2(200,10), Color.Wheat);
            attackButton.Draw(gameTime, spriteBatch);
        }

    }
}
