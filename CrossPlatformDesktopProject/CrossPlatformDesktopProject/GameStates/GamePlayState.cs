using CrossPlatformDesktopProject;
using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Levels;
using Microsoft.Xna.Framework.Graphics;
using System;

public class GamePlayState : IGameState
{
    public Game1 game;
    public Room CurrentRoom { get; }

    public GamePlayState(Game1 game, Room room)
    {
        this.game = game;
        game.collisionManager.createDetector(room, game.player);
        CurrentRoom = room;
    }

    public void Update()
    {
        if (game.pauseCooldown > 0)
        {
            game.pauseCooldown--;
        }
        game.player.Update();
        foreach (IController controller in game.controllerList)
        {
            controller.Update();
        }
        game.collisionManager.Update();
        CurrentRoom.Update();
        game.currentHUD.Update();
    }

    public void Draw(SpriteBatch sb)
    {
        CurrentRoom.Draw(sb);
        game.player.Draw(sb);
    }
}
