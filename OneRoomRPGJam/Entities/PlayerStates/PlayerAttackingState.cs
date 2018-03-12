using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OneRoomRPGJam.Entities;

namespace OneRoomRPGJam.Entities.PlayerStates
{
	public class PlayerAttackingState : PlayerState
	{
		//TODO Create hitbox for sword that updates its X and Y position based on the player's
		//Width and height of hitbox should be the same. 
		//TODO Make hitbox for sword flip along with the player's direction. 
		//TODO Allow transition to idle, walk, and hurt states.
		public PlayerAttackingState(Player player) : base(player)
		{
			
		}

		public override void Init()
		{
		}

		public override void OnEnter()
		{
			//TODO Check if animation has finished. 
			//If it has or if the player has been hurt.. 
			//Change states accordingly
			//Try changing to idle state if animation finishes normally
			//Change to hurt state if player is hit during attack. 
					
			if (player.FacingDirection == Player.RIGHT)
			{
				//lock player in attack animation until it finishes or until player is hit
				player.ChangeAnimation(4); 
			}
			else if (player.FacingDirection == Player.LEFT)
			{
				//lock player in attack animation until it finishes or until player is hit
				player.ChangeAnimation(5);
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
		}
	}
}
