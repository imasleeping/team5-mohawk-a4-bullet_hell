using System;
using System.Numerics;
namespace MohawkGame2D
{
	public class Boss
	{
		int Health = 100;
		public static Vector2 Position = Window.Size/2;
		float AttackTimer = 0.5f;
		int BulletAmount = 10;
		Vector2 BulletSpawn = Window.Size / 2;
        public void Attack()
		{
			AttackTimer -= Time.DeltaTime;
			if (AttackTimer < 0)
			{

				float time = Time.SecondsElapsed; 
				float cycle = time * MathF.Tau;
				AttackTimer = 0.5f;
					BulletSpawn.Y = Position.Y + 25;
                    BulletSpawn.X = Position.X + 25;
				//for (int i = 0; i < BulletAmount; i++)
				//{
				//	Console.WriteLine(BulletSpawn);
                    Bullets.AddBullet(new Vector2(BulletSpawn.X, BulletSpawn.Y), BulletSpawn - Position);
				//}
            }
			Draw.FillColor = Color.Red;
			Draw.Circle(Position, 20);
		}
	}
}

