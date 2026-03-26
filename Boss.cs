using System;
using System.Numerics;
namespace MohawkGame2D
{
	public class Boss
	{
		public static int Health = 100;
		public static Vector2 Position = Window.Size/2;
		float AttackTimer1 = 0.1f;
		float AttackTimerMax1 = 0.1f;
        float AttackTimer2 = 0.1f;
        float AttackTimerMax2 = 0.1f;
        float AttackTimer3 = 0.1f;
        float AttackTimerMax3 = 0.1f;
        float AttackPatternChange = 10f;
        float TargetTimer = 0.3f;
        int LastPattern;
        int AttackPattern = 3;
		int BulletAmount = 10;
		int BulletSpeed = 5;
        public static int Size = 20;
        Vector2 BulletSpawn = Window.Size / 2;
        Vector2 RandomPosition = new Vector2(Random.Float(0, Window.Size.Y), Random.Float(0, Window.Size.X));
        public void Update()
        {
            if (Health > 0)
            {
                AttackPatternChange -= Time.DeltaTime;
                if (AttackPatternChange <= 0)
                {
                    if (AttackPattern == LastPattern)
                    {
                        AttackPattern += 1;
                    }
                    AttackPatternChange = Random.Float(5f, 10f);
                    AttackPattern = Random.Integer(1, 4);
                    LastPattern = AttackPattern;
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
                        Bullets.AddBullet(new Vector2(BulletSpawn.X, BulletSpawn.Y), (BulletSpawn - Position) * BulletSpeed, 2);
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
                            Bullets.AddBullet(new Vector2(BulletSpawn.X, BulletSpawn.Y), (BulletSpawn - Position) * BulletSpeed, 2);
                        }
                    }
                }
                if (AttackPattern == 3)
                {
                    AttackTimerMax3 = 1.5f;
                    BulletSpeed = 5;
                    AttackTimer3 -= Time.DeltaTime;
                    BulletAmount = 20;
                    if (AttackTimer3 < 0)
                    {
                        if (TargetTimer > 0f)
                        {
                            TargetTimer -= Time.DeltaTime;
                            // replace this with image drawing
                            Draw.FillColor = Color.White;
                            Draw.LineColor = Color.White;
                            Draw.Circle(RandomPosition, 15);
                        }
                        if (TargetTimer <= 0f)
                        {
                            for (int i = 0; i < BulletAmount; i++)
                            {
                                BulletSpawn.Y = RandomPosition.Y + MathF.Sin(MathF.Tau * i / BulletAmount) * 10;
                                BulletSpawn.X = RandomPosition.X + MathF.Cos(MathF.Tau * i / BulletAmount) * 10;
                                Bullets.AddBullet(new Vector2(BulletSpawn.X, BulletSpawn.Y), (BulletSpawn - RandomPosition) * BulletSpeed, 2);
                                AttackTimer3 = AttackTimerMax3;
                            }
                            RandomPosition = new Vector2(Random.Float(0, Window.Size.Y), Random.Float(0, Window.Size.X));
                            TargetTimer = 0.3f;
                        }
                    }
                }
                // boss graphics(replace with image)
                Draw.FillColor = Color.Red;
                Draw.LineColor = Color.Red;
                Draw.Circle(Position, Size);
            }
            else
            {
                Position = new Vector2(10000, 1000);
            }
        }
	}
}

