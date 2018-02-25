using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OneRoomRPGJam.Entities
{
	public class PickUp : CollisionEntity
	{
		public enum Effect {HEALTH, MANA, SCORE, EXPERIENCE}
		public enum Size {LARGE, MEDIUM, SMALL}
		Effect effect;
		Size size;
		float scale;  

		public PickUp(Effect effect, Size size)
		{
			this.effect = effect;
			this.size = size; 
		}

		public override void Init()
		{
			SizeCheck();
			TypeCheck();
		}

		void SizeCheck()
		{
			if (size == Size.SMALL)
			{
				scale = 0.5f;
			}
			else if (size == Size.MEDIUM)
			{
				scale = 1;
			}
			else if (size == Size.LARGE)
			{
				scale = 1.5f;
			}
		}

		void TypeCheck()
		{
			if (effect == Effect.HEALTH)
			{
				//change to health graphic
			}
			else if (effect == Effect.MANA)
			{
				//Change to mana graphic
			}
			else if (effect == Effect.EXPERIENCE)
			{
				//Change to experience graphic
			}
			else if (effect == Effect.SCORE)
			{
				if (size == Size.SMALL)
				{
					texture = Content.Load<Texture2D>("pickups/coppercoin");
				}
				else if (size == Size.MEDIUM)
				{
					texture = Content.Load<Texture2D>("pickups/silvercoin");
				}
				else if (size == Size.LARGE)
				{
					texture = Content.Load<Texture2D>("pickups/goldcoin");
				}
			}
		}

		public void OnUse(Player player)
		{
			//TODO Pass the 'size' and 'effect' member to a function called by 'player' and adjust values accordingly
		}

		public override void Render(SpriteBatch spriteBatch)
		{
			if (effect == Effect.SCORE)
			{
				//Do not scale Score textures. 
				spriteBatch.Draw(texture, new Rectangle(x, y, width, height), Color.White); 
			}
			else
			{
				//Function renders texture based on it's 'size' member. 
				spriteBatch.Draw(texture, new Rectangle(x, y, width * (int)scale, height * (int)scale), 
				                 new Rectangle(x, y, width, height), Color.White);
			}		
		}
		public void OnCollisionWithPlayer()
		{
			//Check if player actually picked up item. 
			Kill(); 
		}
	}
}
