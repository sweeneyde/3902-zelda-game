using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject
{
    public interface ILinkState
    {
        void Draw(SpriteBatch spriteBatch);
        void setTextureIndex(int index);
        void TakeDamage();
        void Update();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void UsePrimary();
        void UseSecondary1();
        void UseSecondary2();
        void UseSecondary3();
    }
}
