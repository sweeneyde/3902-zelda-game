using CrossPlatformDesktopProject;
using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Levels;
using Microsoft.Xna.Framework.Graphics;
using System;

public class GamePlayState : IGameState
{
    public Game1 game;
    public Room CurrentRoom { get; }

    private CollisionDetector collisionDetector;
    public GamePlayState(Game1 game, Room room)
    {
        this.game = game;
        collisionDetector = new CollisionDetector(room, game.player, game);
        CurrentRoom = room;
    }

    public void Update()
    {
        game.player.Update();
        foreach (IController controller in game.controllerList)
        {
            controller.Update();
        }
        collisionDetector.Update();
        CurrentRoom.Update();
    }

    public void Draw(SpriteBatch sb)
    {
        CurrentRoom.Draw(sb);
        game.player.Draw(sb);
    }
}
