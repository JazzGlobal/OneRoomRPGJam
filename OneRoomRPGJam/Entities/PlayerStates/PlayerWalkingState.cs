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
			if (player.keyboard.IsKeyDown(Keys.A))
			{
				//player.Move(Player.Directions.LEFT);
				player.X -= player.Speed;
			}
			if (player.keyboard.IsKeyDown(Keys.S))
			{
				//player.Move(Player.Directions.DOWN);
				player.Y += player.Speed; 
			}
			if (player.keyboard.IsKeyDown(Keys.D))
			{
				//player.Move(Player.Directions.RIGHT);
				player.X += player.Speed; 
			}
			else
			{
				//player.ChangeState(Player.States.IDLE);
			}
		}

	}
}
