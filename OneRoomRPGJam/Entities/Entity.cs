using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OneRoomRPGJam.Entities
{
	public abstract class Entity
	{
		protected int x;
		protected int y;
		protected int height;
		protected int width;
		protected int speed;
		protected int health;
		protected int attack;
		protected Rectangle bounds;
		protected Texture2D texture;
		protected static ContentManager Content;


		public Rectangle getBounds()
		{
			bounds = new Rectangle(x,y,width,height);
			return bounds; 
		}

		public virtual void Init(){}

		public virtual void Update(GameTime gameTime){}

		public virtual void Render(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, getBounds(), Color.White);
		}
		public static void SetContentManager(ContentManager content)
		{
			Content = content; 
		}
	}
}
