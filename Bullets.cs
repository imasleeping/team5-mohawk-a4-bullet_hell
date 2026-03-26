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
                BulletGroups.RemoveAt(i);
            }
            else
            {
            //move position by velocitys
            Positions[i] += Velocitys[i] * Time.DeltaTime;
            // draw circle graphics at positions(replace with image)
                if (BulletGroups[i] == 2)
                {
                    //boss bullet
                Draw.FillColor = Color.Red;
                Draw.LineColor = Color.Red;
                BulletSize = 10;
                Draw.Circle(Positions[i], BulletSize);
                }
                else
                {
                    //player bullet
                Draw.FillColor = Color.Blue;
                Draw.LineColor = Color.Blue;
                BulletSize = 8;
                Draw.Circle(Positions[i], BulletSize);
                    //check if bullet hits boss
                    if (Boss.Position.Y - Positions[i].Y < BulletSize + Boss.Size && Boss.Position.X - Positions[i].X < BulletSize + Boss.Size && Boss.Position.Y - Positions[i].Y > -BulletSize - Boss.Size && Boss.Position.X - Positions[i].X > -BulletSize - Boss.Size)
                    {
                        Boss.Health -= 10;
                        Positions.RemoveAt(i);
                        Velocitys.RemoveAt(i);
                        BulletGroups.RemoveAt(i);
                    }
                }
            }
        } 
    }
}