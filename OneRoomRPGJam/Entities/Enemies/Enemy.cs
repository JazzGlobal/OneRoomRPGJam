using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OneRoomRPGJam.Entities.EntityStates;
using OneRoomRPGJam.Graphics;
using OneRoomRPGJam.System;

namespace OneRoomRPGJam.Entities.Enemies
{
	public class Enemy : CollisionEntity
	{
		public Enemy() : base()
		{
			CollisionHandler.OnEnemyCollisionWithPlayerSword += Hurt; 
		}
		public override void Init()
		{
		}
		public override void Update(GameTime gameTime)
		{
		}
		public override void Render(SpriteBatch spriteBatch)
		{
		}
		public virtual void Move()
		{
				
		}
		public void Hurt(CollisionEntity player)
		{
			Player p = (Player)player; 
			//Take damage based on the player's current attack power. 
		}
	}
}
