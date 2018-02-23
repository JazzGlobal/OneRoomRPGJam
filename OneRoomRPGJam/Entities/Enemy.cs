using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OneRoomRPGJam.Entities;
using OneRoomRPGJam.Entities.EntityStates;
using OneRoomRPGJam.Graphics;

namespace OneRoomRPGJam.Entities
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
	public abstract class SlimeState : State
	{
		protected Slime slime;

		public SlimeState(Slime slime)
		{
			this.slime = slime; 
		}
	}
	public class Slime : Enemy
	{
		//Make Slime act on a timer. 
		//TODO Slime should jump every so often to move closer to the player. 
		Color color; 
		Vector2 Position; 
		const float delay = 4;
		float remaining_delay = delay;
		float positionX, velocityX;
		float positionY, velocityY; 
		float gravity = 0.5f;
		StateMachine stateMachine;
		List<Animation> animationList;
		Animation currentAnimation;

		public Slime()
		{
			
		}
		public Slime(Color color)
		{
			this.color = color; 
		}
		public override void Init()
		{
			x = 50;
			y = 50;
			Position = new Vector2(x, y); 
			LoadAnimations(); 
			LoadStates(); 
		}
		void LoadAnimations()
		{
			animationList = new List<Animation>();
			Texture2D slimeidle = Content.Load<Texture2D>("enemies/slime/slimestill");
			Texture2D slimewalk = Content.Load<Texture2D>("enemies/slime/slimewalk");

			animationList.Add(new Animation(slimeidle, new Rectangle(0, 0, 26, 21), 26, 21, 0, 200f, 0, false,color)); //Right idle
			animationList.Add(new Animation(slimeidle, new Rectangle(0, 0, 26, 21), 26, 21, 0, 200f, 0, true,color)); //Left idle

			animationList.Add(new Animation(slimewalk, new Rectangle(0, 0, 29, 15), 29, 15, 1, 200f, 0, false,color)); //Right walk
			animationList.Add(new Animation(slimewalk, new Rectangle(0, 0, 29, 15), 29, 15, 1, 200f, 0, true,color)); //Left walk

			currentAnimation = animationList[2];
		}
		void LoadStates()
		{
			stateMachine = new StateMachine();
			stateMachine.AddState(new IdleState(this));
			stateMachine.AddState(new SeekState(this));
			stateMachine.AddState(new JumpState(this));
		}
		public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
		{
			foreach (Animation a in animationList)
			{
				if (a.X != (int)Position.X || a.Y != (int)Position.Y)
				{
					a.X = (int)Position.X;
					a.Y = (int)Position.Y;
				}
			}
			UpdatePosition();
			currentAnimation.Update(gameTime); 
		}
		void UpdatePosition()
		{
			Position.X = x;
			Position.Y = y;
		}
		public override void Render(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{
			currentAnimation.Render(spriteBatch); 
		}
		public override void Move()
		{
			
			Console.WriteLine("Slime moved"); 
		}

		class IdleState : SlimeState
		{
			
			public IdleState(Slime slime) : base(slime)
			{
			}
			public override void Init()
			{
			}

			public override void OnEnter()
			{
			}

			public override void OnExit()
			{
			}

			public override void Render(SpriteBatch spriteBatch)
			{
			}

			public override void Update(GameTime gameTime)
			{
			}
		}
		class SeekState : SlimeState
		{
			public SeekState(Slime slime) : base(slime)
			{
			}
			public override void Init()
			{
			}

			public override void OnEnter()
			{
			}

			public override void OnExit()
			{
			}

			public override void Render(SpriteBatch spriteBatch)
			{
			}

			public override void Update(GameTime gameTime)
			{
			}
		}
		class JumpState : SlimeState
		{

			/**
			 * 			//This jumping logic will not work. Constant gravity is not desired. 
			//Can the Slime jump in all four directions? 
			//If so, how do we make the Slime look as if it is jumping when jumping towards the bottom or towards the top?
			
			//if timer is up 
			//Make Slime jump 
			var time = (float) gameTime.ElapsedGameTime.TotalSeconds;
			remaining_delay -= time;

			if (remaining_delay <= 0)
			{
				Move();
				remaining_delay = delay; 
			}
			positionX += velocityX;
			positionY += velocityY;
			velocityY += gravity * (float) gameTime.ElapsedGameTime.TotalMilliseconds;

			 * 
			 **/
			public JumpState(Slime slime) : base(slime)
			{
			}
			public override void Init()
			{
			}

			public override void OnEnter()
			{
			}

			public override void OnExit()
			{
			}

			public override void Render(SpriteBatch spriteBatch)
			{
			}

			public override void Update(GameTime gameTime)
			{
			}
		}
	}
}
