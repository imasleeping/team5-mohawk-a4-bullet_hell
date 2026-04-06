using MohawkGame2D;
using System;
using System.Numerics;
namespace MohawkGame2D
{
	public class PlayerShooting
	{
		Vector2 PlayerPos = new Vector2(0,0);
		int BulletSpeed = 1;

		public void Shoot()
		{
			Bullets.AddBullet(PlayerPos, (Input.GetMousePosition() - PlayerPos) * BulletSpeed, 1);
		}
	}
}

