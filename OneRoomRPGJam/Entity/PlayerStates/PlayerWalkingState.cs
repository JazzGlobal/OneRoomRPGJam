using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OneRoomRPGJam
{
	public class PlayerWalkingState : PlayerState
	{
		public PlayerWalkingState(Player player) : base (player)
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
			CheckInput();
		}
		void CheckInput()
		{
			if (Input.GetKeyboardState().IsKeyDown(Keys.W))
			{
				player.Move(Player.Directions.UP);
			}
			else if (Input.GetKeyboardState().IsKeyDown(Keys.A))
			{
				player.Move(Player.Directions.LEFT);
			}
			else if (Input.GetKeyboardState().IsKeyDown(Keys.S))
			{
				player.Move(Player.Directions.DOWN);

			}
			else if (Input.GetKeyboardState().IsKeyDown(Keys.D))
			{
				player.Move(Player.Directions.RIGHT);
			}
			else
			{
				player.GetStateMachine().ChangeState(Player.IDLE);
			}
		}

	}
}
