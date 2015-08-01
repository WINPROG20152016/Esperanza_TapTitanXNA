using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace TapTitanXNA_AllenEsperanza
{
    public class Hero
    {
        #region
        Vector2 playerPosition;
        Texture2D player;
        Texture2D attack;
        //Texture2D support;
        ContentManager content;
        Level level;

        //Animation supportAnimation;
        Animation idleAnimation;
        Animation attackAnimation;
        AnimationPlayer spritePlayer;
        #endregion


        public Hero (ContentManager content, Level level)
	    {
            this.content = content;
            this.level = level;
	    }

        public void LoadContent()
        {
            player = content.Load<Texture2D>("herosprite/64566");
            attack = content.Load<Texture2D>("herosprite/64566-2");

            idleAnimation = new Animation(player, 0.1f, true);
            attackAnimation = new Animation(player, 0.1f, true);

            int positionX = (Level.windowWidth / 2) - (player.Width / 2);
            int positionY = (Level.windowHeight / 2) - (player.Height / 3);
            playerPosition = new Vector2((float)positionX, (float)positionY);
            spritePlayer.PlayAnimation(idleAnimation);
        }

        public void Update(GameTime gameTime)
        {
            if (level.mouseState.LeftButton == ButtonState.Pressed)
            {
                spritePlayer.PlayAnimation(new Animation(content.Load<Texture2D>("herosprite/64566-2"), 0.1f, true));
            }

            if (level.mouseState.RightButton == ButtonState.Pressed)
            {
                spritePlayer.PlayAnimation(new Animation(content.Load<Texture2D>("herosprite/64566"),0.1f, true));

            }
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spritePlayer.Draw(gameTime, spriteBatch, playerPosition, SpriteEffects.None);
        }
        

    }
}
