using System;
namespace OneRoomRPGJam
{
	public class Enemy : CollisionEntity
	{
		public Enemy()
		{
			
		}
		public override void Init()
		{
		}
		public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
		{
		}
		public override void Render(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{
		}
		public virtual void Move()
		{
				
		}
	}
	public class Slime : Enemy
	{
		//Make Slime act on a timer. 
		//TODO Slime should jump every so often to move closer to the player. 
		const float delay = 4;
		float remaining_delay = delay;
		float positionX, velocityX;
		float positionY, velocityY; 
		float gravity = 0.5f;
		StateMachine stateMachine; 

		public Slime()
		{
					
		}
		public override void Init()
		{
			base.Init();
		}
		private void LoadStates()
		{
			stateMachine = new StateMachine(); 
			//Add Idle State
			//Add Jumping State
		}
		public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
		{
			//This jumping logic will not work. Constant gravity is not desired. 
			//Can the Slime jump in all four directions? 
			//If so, how do we make the Slime look as if it is jumping when jumping towards the bottom or towards the top?
			
			//if timer is up 
			//Make Slime jump 
			var time = (float) gameTime.ElapsedGameTime.TotalSeconds;
			remaining_delay -= time;
			Console.WriteLine(remaining_delay); 
			if (remaining_delay <= 0)
			{
				Move();
				remaining_delay = delay; 
			}
			positionX += velocityX;
			positionY += velocityY;
			velocityY += gravity * (float) gameTime.ElapsedGameTime.TotalMilliseconds;
		}
		public override void Render(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{
			base.Render(spriteBatch);
		}
		public override void Move()
		{
			
			Console.WriteLine("Slime moved"); 
		}
	}
}
