using System;
namespace OneRoomRPGJam
{
	public class EntityEvents
	{
		public delegate void EntitySpawnedEventHandler();
		public static event EntitySpawnedEventHandler OnEntitySpawned;

		public static void EntitySpawned()
		{
			if (OnEntitySpawned != null)
			{
				OnEntitySpawned(); 
			}
		}
	}
}
