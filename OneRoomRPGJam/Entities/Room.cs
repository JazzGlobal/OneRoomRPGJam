using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OneRoomRPGJam.Entities
{
	public class Room : Entity
	{
		//TODO Create Controller.cs class.This will handle entity spawns. 


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
			base.Render(spriteBatch);
		}
	}
}
