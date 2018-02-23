using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OneRoomRPGJam.Graphics
{
	public class Animation
	{
		bool flip;
		public int X;
		public int Y;
		Texture2D spriteSheet;
		Rectangle destRect;
		public Rectangle sourceRect;
		float elapsed;
		float delay;
		int frameWidth;
		int frameHeight;
		int frames;
		int currentFrame = 0;
		int row;
		Color color = Color.White;

		public Animation(Texture2D pSpriteSheet, Rectangle pDestRectangle, int pFrameWidth, int pFrameHeight, int pFrames, float pDelay, int row, bool flip)
		{
			spriteSheet = pSpriteSheet;
			destRect = pDestRectangle;
			frameHeight = pFrameHeight;
			frameWidth = pFrameWidth;
			frames = pFrames;
			delay = pDelay;
			this.row = row;
			this.flip = flip;
		}
		public Animation(Texture2D pSpriteSheet, Rectangle pDestRectangle, int pFrameWidth, int pFrameHeight, int pFrames, float pDelay, int row, bool flip, Color color)
		{
			spriteSheet = pSpriteSheet;
			destRect = pDestRectangle;
			frameHeight = pFrameHeight;
			frameWidth = pFrameWidth;
			frames = pFrames;
			delay = pDelay;
			this.row = row;
			this.flip = flip;
			this.color = color;
		}
		public void Update(GameTime gameTime)
		{
			elapsed += (float)gameTime.ElapsedGameTime.Milliseconds;
			if (elapsed >= delay)
			{
				if (currentFrame >= frames)
				{
					currentFrame = 0;
				}
				else
				{
					currentFrame++;
				}
				elapsed = 0;
			}
			sourceRect = new Rectangle(currentFrame * frameWidth, row * frameHeight, frameWidth, frameHeight);
		}
		public void Render(SpriteBatch sb)
		{
			if (!flip)
			{
				sb.Draw(spriteSheet, new Rectangle(X, Y, destRect.Width, destRect.Height), sourceRect, color);
			}
			else if (flip)
			{
				sb.Draw(spriteSheet, new Rectangle(X, Y, destRect.Width, destRect.Height), sourceRect, color, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
			}

		}
	}
}
