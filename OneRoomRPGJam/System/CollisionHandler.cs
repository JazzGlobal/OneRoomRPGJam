using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using OneRoomRPGJam.Entities;

namespace OneRoomRPGJam.System
{
	//TODO Partition the space in the game room into 4 sections. 
	//Only check for PlayerAttackState to Enemy Collisions for the section the player is in. 

	//TODO Create method that draws rectangles around entities. This is useful for debugging. 

	public class CollisionHandler
	{
		//Partitions
		//TODO Define partitions equally. 
		public static Rectangle quad1, quad2, quad3, quad4; 
		public delegate void OnCollisionEventHandler();
		public static event OnCollisionEventHandler OnCollisionWithWall;
		public static event OnCollisionEventHandler OnPlayerCollisionWithEnemy;



		public delegate void OnPlayerCollisionEventHandler(CollisionEntity collisionEntity); 
		public static event OnPlayerCollisionEventHandler OnPlayerCollisionWithPickUp;
		public static event OnPlayerCollisionEventHandler OnEnemyCollisionWithPlayerSword;

		/// <summary>
		/// General boundary collision method for all collision entities. 
		/// </summary>
		public static void CollisionWithWall()
		{
			if (OnCollisionWithWall != null)
			{
				OnCollisionWithWall();
			}
		}

		public static void PlayerCollisionWithEnemy()
		{
			if (OnPlayerCollisionWithEnemy != null)
			{
				OnPlayerCollisionWithEnemy();
			}
		}

		public void PlayerCollisionWithPickup(CollisionEntity pickup)
		{
			if (OnPlayerCollisionWithPickUp != null)
			{
				OnPlayerCollisionWithPickUp(pickup); 
			}
		}

		public static void EnemyCollisionWithPlayerSword(Player player)
		{
			if (OnEnemyCollisionWithPlayerSword != null)
			{
				OnEnemyCollisionWithPlayerSword(player);
			}
		}

		public static void Init()
		{
			quad1 = new Rectangle(0,0,Game1.WIDTH / 2,Game1.HEIGHT / 2);
			quad2 = new Rectangle(Game1.WIDTH / 2,0,Game1.WIDTH / 2,Game1.HEIGHT / 2);
			quad3 = new Rectangle(0,Game1.HEIGHT / 2, Game1.WIDTH / 2, Game1.HEIGHT / 2);
			quad4 = new Rectangle(Game1.WIDTH / 2, Game1.HEIGHT / 2, Game1.WIDTH / 2, Game1.HEIGHT / 2); 
		}

		public static void Update(GameTime gameTime, Player p, List<CollisionEntity> enemylist)
		{
			PlayerCollision(p);
		}

		public static bool Collision(Rectangle r1, Rectangle r2)
		{
			return r1.Intersects(r2);
		}

		static void PlayerCollision(Player p)
		{
			if (p.X <= Room.LEFT)
			{
				OnCollisionWithWall();
			}
			if (p.Y <= Room.TOP)
			{
				OnCollisionWithWall();
			}
			if (p.X + p.CurrentAnimation.sourceRect.Width >= Room.RIGHT)
			{
				OnCollisionWithWall(); 
			}
			if (p.Y + p.CurrentAnimation.sourceRect.Height >= Room.BOTTOM)
			{
				OnCollisionWithWall(); 
			}
		}
	}
}
