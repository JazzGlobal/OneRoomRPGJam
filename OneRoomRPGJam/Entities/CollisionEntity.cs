using System;
using Microsoft.Xna.Framework;

namespace OneRoomRPGJam.Entities
{
	public class CollisionEntity : Entity
	{
		Rectangle hitbox;
		public Rectangle HitBox;

		public delegate void OnCollisionDelegate(CollisionEntity Other);
		public event Action<CollisionEntity> OnCollision;
	}
}
