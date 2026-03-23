using System;
using System.Numerics;
namespace MohawkGame2D
{
	public class Boss
	{
		int Health = 100;
		public static Vector2 Position = Window.Size/2;
		float AttackTimer1 = 0.1f;
		float AttackTimerMax1 = 0.1f;
        float AttackTimer2 = 0.1f;
        float AttackTimerMax2 = 0.1f;
        float AttackPatternChange = 10f;
        int AttackPattern = 1;
		int BulletAmount = 10;
		int BulletSpeed = 5;
        Vector2 BulletSpawn = Window.Size / 2;
        public void Attack()
		{
			AttackPatternChange -= Time.DeltaTime;
			if (AttackPatternChange <= 0)
			{
                AttackPatternChange = Random.Float(5f,15f);
				AttackPattern += 1;
				if (AttackPattern > 2)
				{
                    AttackPattern = 1;

                }
            }

            if (AttackPattern == 1)
			{
				AttackTimerMax1 = 0.1f;
				BulletSpeed = 7;
				AttackTimer1 -= Time.DeltaTime;
				if (AttackTimer1 < 0)
				{
					float time = Time.SecondsElapsed; 
					float cycle = time * MathF.Tau;
					AttackTimer1 = AttackTimerMax1;
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
                AttackTimerMax2 = 2f;
                BulletSpeed = 7;
                AttackTimer2 -= Time.DeltaTime;
				BulletAmount = 25;
                if (AttackTimer2 < 0)
                {
                    AttackTimer2 = AttackTimerMax2;
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

