using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OneRoomRPGJam
{
	public class Outline 
	{
		Texture2D texture;
		Color color;
		Rectangle rect; 

		public Outline(Color color)
		{
			this.color = color;
		}
		public void Init()
		{
			texture = new Texture2D(Game1.GetGraphicsDevice(), 1, 1);
			texture.SetData(new Color[] { color });
		}
		public void Update(GameTime gameTime,Rectangle rect)
		{
			this.rect = rect; 
		}
		public void Render(SpriteBatch spriteBatch)
		{
			//Top
			spriteBatch.Draw(texture, new Rectangle(rect.X,rect.Y,rect.Width,1), Color.White); 
			//Bottom
			spriteBatch.Draw(texture, new Rectangle(rect.X, rect.Y + rect.Height, rect.Width, 1), Color.White);
			//Left
			spriteBatch.Draw(texture, new Rectangle(rect.X, rect.Y, 1, rect.Height), Color.White);
			//Right
			spriteBatch.Draw(texture, new Rectangle(rect.X + rect.Width, rect.Y, 1, rect.Height), Color.White);

		}
	}
}
