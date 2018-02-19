using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OneRoomRPGJam
{
	//TODO: Seperate code. One Function to One Task.
	public class Player : CollisionEntity
	{
		Random random = new Random(); 	
		int score;
		int experience;
		int maxHealth; 
		Vector2 Position;
		Vector2 mousePos;
		Vector2 direction;
		float angle;
		string facingDirection;
		private const string LEFT = "LEFT";
		private const string RIGHT = "RIGHT";
		private StateMachine stateMachine;

		public static int IDLE = 0;
		public static int WALKING = 1; 

		public override void Init()
		{
			//TODO: Split into seperate functions 

			LoadStates();
			InitializeVariables();
		}

		private void LoadStates()
		{
			stateMachine = new StateMachine();
			//AddStates here... 
			stateMachine.AddState(new PlayerIdleState(this));
			stateMachine.AddState(new PlayerWalkingState(this)); 
			stateMachine.Init(); 
		}

		private void InitializeVariables()
		{
			facingDirection = "";
			texture = Content.Load<Texture2D>("knightsprite");
			x = 300;
			y = 100;
			Position = new Vector2(x, y);
			speed = 2; 
			width = texture.Width;
			height = texture.Height;
		}

		public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
		{
			UpdatePosition(); 
			CheckInput();
			stateMachine.Update(gameTime);
		}

		private void UpdatePosition()
		{
			Position.X = x;
			Position.Y = y;
		}

		private void CheckInput()
		{
			SetDirection();
		}
		public StateMachine GetStateMachine()
		{
			return stateMachine; 
		}
		public override void Render(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, Position, Color.White); 

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
