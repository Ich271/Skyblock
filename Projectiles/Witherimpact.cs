﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;

namespace Skyblock.Projectiles
{
	public class Witherimpact : ModProjectile
	{



        public override string Texture => "Skyblock/Textures/Witherimpact";

        public override void SetDefaults()
		{
			
			Projectile.width = 512;
			Projectile.height = 512;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 16;
			Projectile.aiStyle = -1;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;

			
		}

		public override void SetStaticDefaults()
		{
			
			Main.projFrames[Projectile.type] = 16;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			
			return new Color(255, 255, 255, 1) * Projectile.Opacity;
		}

        public override void AI()
        {
			
			Projectile.Center = Main.player[Projectile.owner].Center;
			
	
			if (++Projectile.frameCounter >= 1)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
					Projectile.frame = 0;
			}
		}
        

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {

            crit = false;
        }

    }
}