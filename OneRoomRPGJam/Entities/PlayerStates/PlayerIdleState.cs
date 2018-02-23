using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OneRoomRPGJam.Entities;

namespace OneRoomRPGJam.Entities.PlayerStates
{
	public class PlayerIdleState : PlayerState
	{
		//Idle Animation variable

		public PlayerIdleState(Player player) : base(player)
		{
			
		}
		public override void Init()
		{
			//Load textures that will be used within the idle state. 
		}

		public override void OnEnter()
		{
			//Reset needed variables. 
		}

		public override void OnExit()
		{
			
		}

		public override void Render(SpriteBatch spriteBatch)
		{
			//render current animation .
		}

		public override void Update(GameTime gameTime)
		{
			//Update necessary routines. 

			CheckInput();
		}

		/// <summary>
		/// Check if input is received. Move character accordingly. 
		/// </summary>
		private void CheckInput()
		{
			//Movement
			if (Input.GetKeyboardState().IsKeyDown(Keys.W))
			{
				player.ChangeState(Player.States.WALKING); 
			}
			if (Input.GetKeyboardState().IsKeyDown(Keys.A))
			{
				player.ChangeState(Player.States.WALKING);
			}
			if (Input.GetKeyboardState().IsKeyDown(Keys.S))
			{
				player.ChangeState(Player.States.WALKING);
			}
			if (Input.GetKeyboardState().IsKeyDown(Keys.D))
			{
				player.ChangeState(Player.States.WALKING);
			}
			//End of Movement

			//Attack

			//End of Attack

			//Menu

			//End of Menu 
		}
	}
}
