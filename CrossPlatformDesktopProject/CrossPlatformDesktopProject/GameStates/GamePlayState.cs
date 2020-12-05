using CrossPlatformDesktopProject;
using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.Sound;
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
        game.currentHUD.activate(true);
        CurrentRoom = room;
    }

    public void Update()
    {
        if (game.pauseCooldown > 0)
        {
            game.pauseCooldown--;
        }
        game.player.Update();
        if (game.player.link_health == 0)
        {
            game.player.link_health = -1;
            game.player.currentState = new Death(game.player, game, game.font);
            SoundStorage.music_instance.Stop();
        }

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
