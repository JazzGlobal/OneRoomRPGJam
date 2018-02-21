﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OneRoomRPGJam
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
				player.GetStateMachine().ChangeState(Player.WALKING); 
			}
			if (Input.GetKeyboardState().IsKeyDown(Keys.A))
			{
				player.GetStateMachine().ChangeState(Player.WALKING);
			}
			if (Input.GetKeyboardState().IsKeyDown(Keys.S))
			{
				player.GetStateMachine().ChangeState(Player.WALKING);
			}
			if (Input.GetKeyboardState().IsKeyDown(Keys.D))
			{
				player.GetStateMachine().ChangeState(Player.WALKING);
			}
			//End of Movement

			//Attack

			//End of Attack

			//Menu

			//End of Menu 
		}
	}
}
