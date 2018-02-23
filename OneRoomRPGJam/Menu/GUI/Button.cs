using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OneRoomRPGJam
{
	//TODO: Fix Button click bug. Buttons click more than once per press. 
	//This issue may also be present when interacting with the mouse during gameplay (Sword attack and spell casts). 
	public class Button
	{
		int x;
		int y;
		int width;
		int height;
		string placeHolderText;
		Texture2D texture;
		public MouseState mouseState = new MouseState();
		Texture2D whiteRectangle = new Texture2D(Game1.GetGraphicsDevice(), 1, 1);
		private MouseState oldState = new MouseState(); 

		public Button(int x, int y, Texture2D texture, string placeholdertext)
		{
			whiteRectangle.SetData(new[] { Color.White });
			this.x = x;
			this.y = y;
			this.texture = texture;
			if (texture != null)
			{
				width = texture.Width;
				height = texture.Height;
			}
			this.placeHolderText = placeholdertext;
		}

		public Button(int x, int y, Texture2D texture)
		{
			this.x = x;
			this.y = y;
			this.texture = texture; 
		}

		public static void Update(Button instance, GameTime gameTime, Action performAction)
		{
			instance.mouseState = Mouse.GetState();

			if (instance.Clicked())
			{
				instance.onClick(performAction);
			}
		}

		public void Render(SpriteBatch spriteBatch)
		{
			if (texture != null)
			{
				spriteBatch.Draw(texture, new Vector2(x,y), Color.White);
			}
			else
			{
				//Draw Rectangle with button dimmensions.
				this.width = 100;
				this.height = 100;
				spriteBatch.Draw(whiteRectangle, new Rectangle(x,y,width,height),Color.Chocolate); 
			}
		}

		public bool Clicked()
		{
			MouseState newState = Mouse.GetState();
				if ((newState.X >= this.x && newState.X <= this.x + this.width) &&
					(newState.Y >= this.y && newState.Y <= this.y + this.height) &&
			        (newState.LeftButton == ButtonState.Pressed) && oldState.LeftButton == ButtonState.Released)
				{
					oldState = newState; //y this reassigns the old state so that it is ready for next time
					return true;
				}

			return false; 
		}

		public bool onClick(Action performAction)
		{
			performAction();
			return true; 
		}
	}
}
