using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OneRoomRPGJam.Entities
{
	public class Room : Entity
	{
		public static int LEFT = 55;
		public static int TOP = 65;
		public static int BOTTOM = 420;
		public static int RIGHT = 595; 

		public override void Init()
		{	
			texture = Content.Load<Texture2D>("map/placeholdermap");		
		}
		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}
		public override void Render(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, new Vector2(0, 0), Color.White); 
		}
	}
}
