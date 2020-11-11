using Microsoft.Xna.Framework.Graphics;
using System;

public interface IGameState
{
    void Update();
    void Draw(SpriteBatch sb);
}
