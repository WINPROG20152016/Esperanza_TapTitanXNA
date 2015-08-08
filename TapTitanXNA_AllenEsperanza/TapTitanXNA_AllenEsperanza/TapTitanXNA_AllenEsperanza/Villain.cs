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
    class Villain
    {
        #region
        Vector2 villainPosition;
        Texture2D villain;
        ContentManager content;
        Level level;

        Animation idleAnimation;
        AnimationPlayer spritePlayer;
        #endregion


        public Villain (ContentManager content, Level level)
	    {
            this.content = content;
            this.level = level;
	    }

        public void LoadContent()
        {
            villain = content.Load<Texture2D>("herosprite/bowser.fw");
           

            idleAnimation = new Animation(villain, 0.1f, true);

            int positionX = (Level.windowWidth / 3) - (villain.Width / 6);
            int positionY = (Level.windowHeight / 7) - (villain.Height / 6);
            villainPosition = new Vector2((float)positionX, (float)positionY);
            spritePlayer.PlayAnimation(idleAnimation);
        }

        public void Update(GameTime gameTime)
        {
            if (level.mouseState.LeftButton == ButtonState.Pressed)
            {
                spritePlayer.PlayAnimation(new Animation(content.Load<Texture2D>("herosprite/bowser.fw"), 0.1f, true));
            }

        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spritePlayer.Draw(gameTime, spriteBatch, villainPosition, SpriteEffects.None);
        }
        

    }
}

