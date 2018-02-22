using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OneRoomRPGJam.Graphics;

namespace OneRoomRPGJam
{
	public class Player : CollisionEntity
	{
		//TODO Create way to give Player Objects' State objects potential access to all key presses. 
		//You can do this by creating a bool function that accepts string parameters to check if a key is being pressed. 
		//This is better than writing the whole check code per need. 

		//TODO Create method that uses items 

		Random random = new Random(); 	
		//int score;
		//int experience;
		//int maxHealth; 
		Vector2 Position;
		Vector2 mousePos;
		Vector2 direction;
		float angle;
		//string facingDirection;
		private const string LEFT = "LEFT";
		private const string RIGHT = "RIGHT";
		private StateMachine stateMachine;
		List<Animation> animationList;
		Animation currentAnimation; 

		//TODO Decide on how you want to change states in the Player's State classes
		public enum States
		{
			
		}
		public static int IDLE = 0;
		public static int WALKING = 1; 

		public override void Init()
		{
			LoadAnimations();
			LoadStates();
			InitializeVariables();
		}

		void LoadAnimations()
		{
			animationList = new List<Animation>();
			Texture2D knight = Content.Load<Texture2D>("player/knightidle");
			animationList.Add(new Animation(knight, new Rectangle(0, 0, 30, 32),
											30, 32, 6, 200f, 0, false));
			
			currentAnimation = animationList[0]; 
		}
		void LoadStates()
		{
			stateMachine = new StateMachine();

			stateMachine.AddState(new PlayerIdleState(this));
			stateMachine.AddState(new PlayerWalkingState(this)); 
			stateMachine.Init(); 
		}

		void InitializeVariables()
		{
			x = 300;
			y = 100;
			Position = new Vector2(x, y);
			speed = 2; 
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
			stateMachine.Update(gameTime);
		}

		void UpdatePosition()
		{
			Position.X = x;
			Position.Y = y;
		}

		public enum Directions
		{
			UP, DOWN, LEFT, RIGHT
		}

		/// <summary>
		/// Move the specified direction.
		/// </summary>
		/// <returns>The move.</returns>
		/// <param name="direction">Direction.</param>
		public void Move(Directions direction)
		{
			if (direction == Directions.UP)
			{
				y -= speed; 
			}
			else if (direction == Directions.LEFT)
			{
				x -= speed; 
			}
			else if (direction == Directions.RIGHT)
			{
				x += speed; 
			}
			else if (direction == Directions.DOWN)
			{
				y += speed;
			}
		}

		public StateMachine GetStateMachine()
		{
			return stateMachine; 
		}
		public Animation CurrentAnimation
		{
			set { currentAnimation = value; }
		}
		public override void Render(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{

			currentAnimation.Render(spriteBatch); 
			//	spriteBatch.Draw(texture, Position, Color.White); 

			//Old render method. Renders according to variable 'angle'. Makes sprite rotate to mouse. 
			/*spriteBatch.Draw(texture, new Rectangle((int)Position.X, (int)Position.Y,width, height), null, 
			                 Color.White, angle, new Vector2(width / 2, height / 2), SpriteEffects.None, 0);
			*/
		}

		/// <summary>
		/// Increases one player state at random by 1 point. 
		/// </summary>
		void LevelUp()
		{
			var v = random.Next(0, 3);
			if (v == 0)
			{
				health++; 
			}
			else if (v == 1)
			{
				attack++; 
			}
			else if (v == 2)
			{
				//If speed < certain amount..
				//then speed++;
				//else
				//then health++ 
			}
		}
		/// <summary>
		/// Sets character sprite's direction to that of the mouse cursor.
		/// Status: Deprecated 
		/// </summary>
		void SetDirection()
		{
			mousePos = new Vector2(Input.GetMouseState().X, Input.GetMouseState().Y);
			direction = mousePos - Position;

			angle = (float)(Math.Atan2(direction.Y, direction.X));
		}
	}
}
