using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OneRoomRPGJam.Entities;

namespace OneRoomRPGJam.Entities.PlayerStates
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
			if (player.FacingDirection == Player.RIGHT)
			{
				player.ChangeAnimation(0);
			}
			else if (player.FacingDirection == Player.LEFT)
			{
				player.ChangeAnimation(1);
			}
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
			if (player.keyboard.IsKeyDown(Keys.W))
			{
				//player.Move(Player.Directions.UP);
				player.Y -= player.Speed;
			}
			else if (player.keyboard.IsKeyDown(Keys.A))
			{
				//player.Move(Player.Directions.LEFT);
				player.X -= player.Speed;
				player.FacingDirection = Player.LEFT;
				player.ChangeAnimation(1);

			}
			else if (player.keyboard.IsKeyDown(Keys.S))
			{
				//player.Move(Player.Directions.DOWN);
				player.Y += player.Speed;
			}
			else if (player.keyboard.IsKeyDown(Keys.D))
			{
				//player.Move(Player.Directions.RIGHT);
				player.X += player.Speed;
				player.FacingDirection = Player.RIGHT;
				player.ChangeAnimation(0);

			}
			else
			{
				player.ChangeState(Player.States.IDLE);
			}
		}

	}
}
