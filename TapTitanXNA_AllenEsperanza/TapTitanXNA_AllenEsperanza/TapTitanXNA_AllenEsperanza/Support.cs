using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TapTitanXNA_AllenEsperanza
{
    class Support
    {
        #region
        Vector2 suppPosition;
        Texture2D support;
        ContentManager content;
        Level level;

        Animation idleAnimation;
        AnimationPlayer spritePlayer;
        #endregion


        public Support(ContentManager content, Level level)
	    {
            this.content = content;
            this.level = level;
	    }

        public void LoadContent()
        {
            support = content.Load<Texture2D>("support/luigi");

            idleAnimation = new Animation(support, 0.1f, true);

            int positionX = (Level.windowWidth / 3) - (support.Width / 2);
            int positionY = (Level.windowHeight / 2) - (support.Height / 2);
            suppPosition = new Vector2((float)positionX, (float)positionY);
            spritePlayer.PlayAnimation(idleAnimation);
        }

        public void Update(GameTime gameTime)
        {
            if (level.mouseState.LeftButton == ButtonState.Pressed)
            {
                spritePlayer.PlayAnimation(new Animation(content.Load<Texture2D>("support/luigi"), 0.1f, true));
            }

        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spritePlayer.Draw(gameTime, spriteBatch, suppPosition, SpriteEffects.None);
        }
    }
}
