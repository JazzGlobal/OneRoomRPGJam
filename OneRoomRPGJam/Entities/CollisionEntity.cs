using System;
using Microsoft.Xna.Framework;
using OneRoomRPGJam.System;

namespace OneRoomRPGJam.Entities
{
	public class CollisionEntity : Entity
	{

		protected Rectangle hitbox;
		public Rectangle HitBox
		{
			get { return hitbox; }
		}

		bool dead;

		public CollisionEntity()
		{
			CollisionHandler.OnCollisionWithWall += this.OnCollisionWithWall; 
		}

		public virtual void OnCollisionWithWall()
		{
			//TODO Look into not having to make this always overidden. All moveable entities should have the same behavior when
			//walking into a wall!
		}
		public virtual void OnSpawn()
		{
			//Subscribe to all necessary events. 
		}
		public virtual void OnDeath()
		{
			//Clean up here. 
			//Unload assets
			//Make sure no process is being called. 
		}
		public void Kill()
		{
			dead = true; 
		}
	}
}
