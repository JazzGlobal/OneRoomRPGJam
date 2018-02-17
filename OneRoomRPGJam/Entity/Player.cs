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
		int speed = 2;
		Vector2 Position;
		Vector2 mousePos;
		Vector2 direction;
		float angle;
		string facingDirection;
		private const string LEFT = "LEFT";
		private const string RIGHT = "RIGHT";
		private StateMachine stateMachine; 

		public override void Init()
		{
			//TODO: Split into seperate functions 
			//void LoadStates()
			stateMachine = new StateMachine();
			//Add States 
			stateMachine.Init();

			//void InitializeVariables()

			facingDirection = "";
			texture = Content.Load<Texture2D>("knightsprite");
			x = 300;
			y = 100; 
			Position = new Vector2(x,y);
			width = texture.Width;
			height = texture.Height;
		}

		public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
		{
			//void SetPosition() 
			Position.X = x;
			Position.Y = y;

			CheckInput(); 
		}

		public override void Render(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, new Rectangle((int)Position.X, (int)Position.Y,width, height), null, 
			                 Color.White, angle, new Vector2(width / 2, height / 2), SpriteEffects.None, 0);
		}

		public void CheckInput()
		{
			MovementCheck();
			SetDirection(); 
		}

		/// <summary>
		/// Check if input is received. Move character accordingly. 
		/// </summary>
		private void MovementCheck()
		{
			if (Input.GetKeyboardState().IsKeyDown(Keys.W))
			{
				y -= speed; 
			}
			if (Input.GetKeyboardState().IsKeyDown(Keys.A))
			{
				x -= speed;
				facingDirection = LEFT; 
			}
			if (Input.GetKeyboardState().IsKeyDown(Keys.S))
			{
				y += speed; 
			}
			if (Input.GetKeyboardState().IsKeyDown(Keys.D))
			{
				x += speed;
				facingDirection = RIGHT; 
			}
		}

		/// <summary>
		/// Sets character sprite's direction to that of the mouse cursor. 
		/// </summary>
		private void SetDirection()
		{
			mousePos = new Vector2(Input.GetMouseState().X, Input.GetMouseState().Y);
			direction = mousePos - Position;

			angle = (float)(Math.Atan2(direction.Y, direction.X));
		}
	}
}
