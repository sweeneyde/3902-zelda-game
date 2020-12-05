using CrossPlatformDesktopProject;
using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Commands;
using CrossPlatformDesktopProject.GameStates;
using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.NPC;
using CrossPlatformDesktopProject.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Threading;

public class ThunderDomeState : IGameState
{
    public Game1 game;
    public Room CurrentRoom { get; }
    private List<INpc> enemyWaves = new List<INpc>();
    private int waveNumber = 0;
    private int timer = 500;

    public ThunderDomeState(Game1 game, Room room)
    {
        this.game = game;
        game.collisionManager.createDetector(room, game.player);
        game.currentHUD.activate(true);
        CurrentRoom = room;
        game.player.currentState = new LinkFacingEastState(game.player);
        game.player.link_health = game.player.link_max_health;

    }
        
    public void Update()
    {
        if (game.pauseCooldown > 0)
        {
            game.pauseCooldown--;
        }
        if (timer > 0)
        {
            timer--;
            if(timer == 0)
            {
                GenerateNextWave();
            }
        }
        game.player.Update();
        //player death
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
        if(timer > 0)
        {
            var location = new Vector2(RoomTextureStorage.ROOM_WIDTH/2, RoomTextureStorage.ROOM_HEIGHT/3);
            if (waveNumber == 0)
            {
                location = new Vector2(RoomTextureStorage.ROOM_WIDTH / 3, RoomTextureStorage.ROOM_HEIGHT / 3);
                sb.DrawString(game.font, "  Welcome to the \n   Thunderdome", location, Color.Red);
            }
            else
            {
                sb.DrawString(game.font, "Wave " + (waveNumber) + "\n  " + (timer / 60 + 1), location, Color.Red);
            }
        }
    }

    public void StartCountdown()
    {
        float[] coords;

        //Add enemies in order of appearance
        enemyWaves = new List<INpc>();
        coords = RowsColumns.ConvertRowsColumns(2, 7);
        enemyWaves.Add(new Gel(coords[0], coords[1], game));
        coords = RowsColumns.ConvertRowsColumns(5, 7);
        enemyWaves.Add(new Gel(coords[0], coords[1], game));
        coords = RowsColumns.ConvertRowsColumns(7, 7);
        enemyWaves.Add(new Gel(coords[0], coords[1], game));

        coords = RowsColumns.ConvertRowsColumns(2, 9);
        enemyWaves.Add(new Bat(coords[0], coords[1], game));
        coords = RowsColumns.ConvertRowsColumns(5, 9);
        enemyWaves.Add(new Bat(coords[0], coords[1], game));
        coords = RowsColumns.ConvertRowsColumns(7, 9);
        enemyWaves.Add(new Bat(coords[0], coords[1], game));

        coords = RowsColumns.ConvertRowsColumns(1, 12);
        enemyWaves.Add(new Skeleton(coords[0], coords[1], game));
        coords = RowsColumns.ConvertRowsColumns(4, 12);
        enemyWaves.Add(new Skeleton(coords[0], coords[1], game));
        coords = RowsColumns.ConvertRowsColumns(7, 12);
        enemyWaves.Add(new Skeleton(coords[0], coords[1], game));

        coords = RowsColumns.ConvertRowsColumns(3, 3);
        enemyWaves.Add(new Skeleton(coords[0], coords[1], game));


        if (waveNumber > enemyWaves.Count)
        {
            game.currentState = new ThunderDomeVictoryState(game, game.font);
        }

        if (timer <= 0)
        {
            timer = 150;
            waveNumber += 1;
        }
    }

    private void GenerateNextWave()
    {
        //Load enemies by wave number
        for (int i = 0; i < waveNumber; i++)
        {
            CurrentRoom.Add(enemyWaves[i]);
        }
    }
}
