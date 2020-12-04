using CrossPlatformDesktopProject;
using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.NPC;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class ThunderDomeState : IGameState
{
    public Game1 game;
    public Room CurrentRoom { get; }
    private List<INpc> enemyWaves = new List<INpc>();
    private int waveNumber = 0;
    private int timer = 150;

    public ThunderDomeState(Game1 game, Room room)
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
        if (timer > 0)
        {
            timer--;
            if(timer == 0)
            {
                GenerateNextWave();
            }
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

    public void StartCountdown()
    {
        if (timer <= 0)
        {
            timer = 150;
        }
    }

    private void GenerateNextWave()
    {
        //Generate new entities on each reload
        //Don't use Goriya or Boss here, the leave additional INpc objects in the room
        float[] coords;

        //Add enemies in order of appearance
        enemyWaves = new List<INpc>();
        coords = RowsColumns.ConvertRowsColumns(2, 5);
        enemyWaves.Add(new Gel(coords[0], coords[1], game));
        coords = RowsColumns.ConvertRowsColumns(5, 5);
        enemyWaves.Add(new Gel(coords[0], coords[1], game));
        coords = RowsColumns.ConvertRowsColumns(7, 5);
        enemyWaves.Add(new Gel(coords[0], coords[1], game));

        coords = RowsColumns.ConvertRowsColumns(2, 6);
        enemyWaves.Add(new Bat(coords[0], coords[1], game));
        coords = RowsColumns.ConvertRowsColumns(5, 6);
        enemyWaves.Add(new Bat(coords[0], coords[1], game));
        coords = RowsColumns.ConvertRowsColumns(7, 6);
        enemyWaves.Add(new Bat(coords[0], coords[1], game));

        coords = RowsColumns.ConvertRowsColumns(2, 10);
        enemyWaves.Add(new Skeleton(coords[0], coords[1], game));
        coords = RowsColumns.ConvertRowsColumns(5, 10);
        enemyWaves.Add(new Skeleton(coords[0], coords[1], game));
        coords = RowsColumns.ConvertRowsColumns(8, 10);
        enemyWaves.Add(new Skeleton(coords[0], coords[1], game));

        waveNumber += 1;
        if(waveNumber > enemyWaves.Count)
        {
            waveNumber -= 1;
        }

        //Load enemies by wave number
        for (int i = 0; i < waveNumber; i++)
        {
            CurrentRoom.Add(enemyWaves[i]);
        }
    }
}
