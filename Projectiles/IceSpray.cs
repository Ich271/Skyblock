using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;
using Terraria.ID;
using Terraria.DataStructures;
using System.Collections.Generic;

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

        private List<int> dustIndex = new();

        public override void AI()
		{

				Timer += 4;

                Vector2 RelPos = new(Timer, (float)0.25 * (float)Math.Sin(Timer * 0.075) * Timer);   
                Vector2 FinalPos = RelPos.RotatedBy(direction.ToRotation());

				Projectile.Center = FinalPos + playerCenter;

				int d = Dust.NewDust(Projectile.Center, 1, 1,  DustID.FireworkFountain_Blue,  Scale: 1.5f, SpeedX: 0f, SpeedY: 0f);
				Main.dust[d].noGravity = true;

				dustIndex.Add(d);
        }




         public override void Kill(int timeLeft)
		{
			int[] dustIndex = this.dustIndex.ToArray();

			for (int i = 0; i < dustIndex.Length; i++) { 
				Main.dust[dustIndex[i]].noGravity = false;
			}
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(ModContent.BuffType<Buffs.IceSprayDebuff>(), 300);
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            crit = false;
        }

    }
}