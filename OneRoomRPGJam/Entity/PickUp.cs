using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OneRoomRPGJam
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

		public void OnPickUp(Player player)
		{
			//TODO Pass the 'size' and 'effect' member to a function called by 'player' and adjust values accordingly
		}

		public override void Render(SpriteBatch spriteBatch)
		{
			//Function renders texture based on it's 'size' member. 
			spriteBatch.Draw(texture, new Rectangle(x, y, width * (int)scale, height * (int)scale), new Rectangle(x, y, width, height), Color.White);
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}
	}
}
