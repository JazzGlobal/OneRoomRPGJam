using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OneRoomRPGJam
{
	public class Button
	{
		int x;
		int y;
		int width;
		int height;
		string placeHolderText; 

		Texture2D texture;
		public MouseState mouseState = new MouseState();

		public Button(int x, int y, Texture2D texture, string placeholdertext)
		{			
			this.x = x;
			this.y = y;
			this.texture = texture;
			this.placeHolderText = placeholdertext; 
		}

		public Button(int x, int y, Texture2D texture)
		{
			this.x = x;
			this.y = y;
			this.texture = texture; 
		}

		public static void Update(Button instance, GameTime gameTime)
		{
			instance.mouseState = Mouse.GetState();
			if (instance.Clicked())
			{
				instance.onClick(); 
			}
		}

		public bool Clicked()
		{
			//Return if mouse click was on the button.
			return false; 
		}

		public virtual void onClick()
		{
			//Perform this if button was clicked. 
		}
	}
}
