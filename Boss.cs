using System;
using System.Numerics;
namespace MohawkGame2D
{
	public class Boss
	{
		int Health = 100;
		public static Vector2 Position = Window.Size/2;
		float AttackTimer = 0.1f;
		float AttackTimerMax = 0.1f;
		int AttackPattern = 2;
		int BulletAmount = 10;
		int BulletSpeed = 5;
        Vector2 BulletSpawn = Window.Size / 2;
        public void Attack()
		{
			if (AttackPattern == 1)
			{
				AttackTimerMax = 0.1f;
				BulletSpeed = 7;
				AttackTimer -= Time.DeltaTime;
				if (AttackTimer < 0)
				{
					float time = Time.SecondsElapsed; 
					float cycle = time * MathF.Tau;
					AttackTimer = AttackTimerMax;
					BulletSpawn.Y = Position.Y + MathF.Sin(cycle / 2) * 10;
                    BulletSpawn.X = Position.X + MathF.Cos(cycle / 2) * 10;
					//for (int i = 0; i < BulletAmount; i++)
					//{
                    Bullets.AddBullet(new Vector2(BulletSpawn.X, BulletSpawn.Y), (BulletSpawn - Position) * BulletSpeed);
					//}
				}
			}
            if (AttackPattern == 2)
            {
                AttackTimerMax = 5f;
                BulletSpeed = 7;
                AttackTimer -= Time.DeltaTime;
				BulletAmount = 25;
                if (AttackTimer < 0)
                {
                    AttackTimer = AttackTimerMax;
                    for (int i = 0; i < BulletAmount; i++)
                    {
						BulletSpawn.Y = Position.Y + MathF.Sin(MathF.Tau * i / BulletAmount) * 10;
						BulletSpawn.X = Position.X + MathF.Cos(MathF.Tau * i / BulletAmount) * 10;
                        Bullets.AddBullet(new Vector2(BulletSpawn.X, BulletSpawn.Y), (BulletSpawn - Position) * BulletSpeed);
                    }
                }
            }
            // boss graphics
            Draw.FillColor = Color.Red;
			Draw.LineColor = Color.Red;
			Draw.Circle(Position, 20);
		}
	}
}

