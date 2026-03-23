using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Numerics;

public class Bullets
{
    public static List<Vector2> Positions = new List<Vector2>();
    public static List<Vector2> Velocitys = new List<Vector2>();

    public static void AddBullet(Vector2 position, Vector2 velocity)
    {
        //adds new bullets position and velocity to their respective lists
        Positions.Add(position);
        Velocitys.Add(velocity);
    }
    public void MoveAndDraw()
    {
        for (int i = 0; i < Positions.Count; i ++)
        {
            //move position by velocitys
            Positions[i] += Velocitys[i] * Time.DeltaTime;
            // draw circle graphics at positions
            Draw.FillColor = Color.Red;
            Draw.Circle(Positions[i], 10f);
            if (Positions[i].Y > Window.Size.Y || Positions[i].Y < 0 || Positions[i].X > Window.Size.X || Positions[i].X < 0)
            {
                Positions.Remove(Positions[i]);
                Velocitys.Remove(Velocitys[i]);
            }
        } 
    }
}