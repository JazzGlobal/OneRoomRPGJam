using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OneRoomRPGJam.Entities;
using OneRoomRPGJam.System;

namespace OneRoomRPGJam
{
	public class Controller
	{
		CollisionEntity e;
		Player player; 
		List<CollisionEntity> entityList;
		int maxNumberOfEnemies;
		Outline outline, outline2, outline3, outline4, playerOutline; 

		//TODO Finish Enemy Spawner
		//Create random enemies based on a spawn interval. 
		//Ramp up spawn speed and amount of enemies allowed based on time played. 

		public Controller()
		{
			
		}
		public void Init()
		{
			
			player = new Player();
			player.Init();
			CollisionHandler.Init();
			outline = new Outline(Color.Red);
			outline.Init();
			outline2 = new Outline(Color.Green);
			outline2.Init();
			outline3 = new Outline(Color.Yellow);
			outline3.Init();
			outline4 = new Outline(Color.Blue);
			outline4.Init();
			playerOutline = new Outline(Color.Red);
			playerOutline.Init(); 

			/**How do you make sure that all spawned entities subscribe to the correct events? 
			 *You could make a new event that invokes when an entity is spawned, and then subscribing the entity to the 
			 *correct event.
			 *This approach is highly reliant on how you define an entity as "spawned". It would probably be best to invoke
			 *the event on instantiation. This would allow the subscriptions to finish before their render or update methods
			 *are even called. 
			 **/
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

			outline.Update(gameTime,CollisionHandler.quad1); 
			outline2.Update(gameTime, CollisionHandler.quad2);
			outline3.Update(gameTime, CollisionHandler.quad3);
			outline4.Update(gameTime, CollisionHandler.quad4);
			//TODO Update all entities
			player.Update(gameTime);
			playerOutline.Update(gameTime, player.HitBox); 
			CollisionHandler.Update(gameTime, player, entityList); 
		}
		public void Render(SpriteBatch spriteBatch)
		{
			//TODO Render all entities
			outline.Render(spriteBatch);
			outline2.Render(spriteBatch);
			outline3.Render(spriteBatch);
			outline4.Render(spriteBatch); 
			player.Render(spriteBatch);
			playerOutline.Render(spriteBatch);
		}

	}
}
