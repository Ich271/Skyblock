using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;
using Terraria.ID;
using Terraria.DataStructures;

namespace Skyblock.Projectiles
{
	public class IceSpray : ModProjectile
	{

        public override string Texture => "Skyblock/Textures/IceSpray";


        private Vector2 playerCenter;
		private Vector2 curserWorld;
		private Vector2 PlayerToCurser;
		private Vector2 direction;


        public override void SetDefaults()
		{

			Projectile.width = 4;
			Projectile.height = 4;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 64;
			Projectile.aiStyle = -1;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;


		}
		public int Timer
		{
			get => (int)Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}

	

		public override Color? GetAlpha(Color lightColor)
		{

			return new Color(255, 255, 255, 0) * Projectile.Opacity;
		}

        public override void OnSpawn(IEntitySource source)
        {
            playerCenter = Main.player[Projectile.owner].Center;
            curserWorld = Main.MouseWorld;
            PlayerToCurser = curserWorld - playerCenter;
            direction = PlayerToCurser.SafeNormalize(Vector2.UnitX);

			
        }





        public override void AI()
		{


				Timer += 4;


            
                Vector2 DustPos = new(Timer, (float)0.25 * (float)Math.Sin(Timer * 0.075) * Timer);
                float angle = direction.ToRotation();
                Vector2 finalDustPos = new Vector2(DustPos.Length() * (float)Math.Cos(DustPos.ToRotation() + angle), DustPos.Length() * (float)Math.Sin(DustPos.ToRotation() + angle));

				Projectile.Center = finalDustPos + playerCenter;

				Dust.NewDustPerfect(Projectile.Center, DustID.FireworkFountain_Blue, Velocity: Vector2.Zero, Scale: 1.5f).noGravity = true;



        }




    }
}