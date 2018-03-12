using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OneRoomRPGJam.Graphics
{
	//TODO Modify to give access to whether or not an animation has finished playing. 
	public class Animation
	{
		protected bool flip;
		public int X;
		public int Y;
		protected Texture2D spriteSheet;
		protected Rectangle destRect;
		public Rectangle sourceRect;
		protected float elapsed;
		protected float delay;
		protected int frameWidth;
		protected int frameHeight;
		protected int totalFrames;
		protected int currentFrame = 0;
		protected int row;
		protected Color color = Color.White;

		public bool finishedPlaying()
		{
			return currentFrame >= totalFrames;
		}
		public void ResetAnimation()
		{
			currentFrame = 0; 
		}
		public Animation(Texture2D pSpriteSheet, Rectangle pDestRectangle, int pFrameWidth, int pFrameHeight, int pTotalFrames, float pDelay, int row, bool flip)
		{
			spriteSheet = pSpriteSheet;
			destRect = pDestRectangle;
			frameHeight = pFrameHeight;
			frameWidth = pFrameWidth;
			totalFrames = pTotalFrames;
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
			totalFrames = pFrames;
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
				if (currentFrame >= totalFrames)
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
		public virtual void Render(SpriteBatch sb)
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
