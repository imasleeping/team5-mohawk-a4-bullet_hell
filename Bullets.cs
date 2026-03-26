using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Numerics;

public class Bullets
{
    public static List<Vector2> Positions = new List<Vector2>();
    public static List<Vector2> Velocitys = new List<Vector2>();
    public static List<int> BulletGroups = new List<int>();
    int BulletSize = 10;
    public static void AddBullet(Vector2 position, Vector2 velocity,int bulletgroup)
    {
        //adds new bullets position and velocity to their respective lists
        Positions.Add(position);
        Velocitys.Add(velocity);
        // group 1 = player group 2 = boss
        BulletGroups.Add(bulletgroup);
    }
    public void Update()
    {
        for (int i = 0; i < Positions.Count; i ++)
        {
            // remove if off screen
            if (Positions[i].Y > Window.Size.Y + BulletSize || Positions[i].Y < 0 - BulletSize || Positions[i].X > Window.Size.X + BulletSize || Positions[i].X < 0 - BulletSize)
            {
                Positions.RemoveAt(i);
                Velocitys.RemoveAt(i);
            }
            else
            {
            //move position by velocitys
            Positions[i] += Velocitys[i] * Time.DeltaTime;
            // draw circle graphics at positions(replace with image)
            Draw.FillColor = Color.Red;
            Draw.LineColor = Color.Red;
            Draw.Circle(Positions[i], BulletSize);
            }
        } 
    }
}