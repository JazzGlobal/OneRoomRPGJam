using System;
namespace OneRoomRPGJam
{
	public abstract class PlayerState : State
	{
		protected Player player; 

		public PlayerState(Player player)
		{
			this.player = player; 
		}
	}
}
