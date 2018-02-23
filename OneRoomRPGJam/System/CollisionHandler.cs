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
		List<CollisionEntity> entitylist;

		//Partitions
		//TODO Define partitions equally. 
		Rectangle quad1, quad2, quad3, quad4; 

		public CollisionHandler()
		{
			entitylist = new List<CollisionEntity>(); 
		}
		public void Update(GameTime gameTime)
		{
			//TODO Check for specific collisions depending on different criteria
			//PlayerAttackState collisions should only be checked in the section that the player is in.
			//foreach enemy in player.currentSection
			//if player.currentState == attackingstate
			//check collision between entity and attack hitbox

			//Player to Enemy body collision checks should only occur if the player and the enemy are in the same section.
			//foreach enemy in player.currentSection
			//check collision between player and enemy 

			//Projectile collisions should only be checked in the section of the projectiles current location (this data will be updated per loop)
			//foreach projectile 
		}

		public static bool Collision(Rectangle r1, Rectangle r2)
		{
			return r1.Intersects(r2);
		}
	}
}
