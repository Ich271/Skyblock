using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;

namespace Skyblock.Items.Weapons
{

	public class Scylla : SkyblockItem

	{

        public override string Texture => "Skyblock/Textures/WitherBlade";
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Item Ability: Wither Impact RIGHT CLICK \n" +
				"Teleports 30 tiles ahead of you.Then implode dealing damage based on your total mana to nearby enemies.\n"
				 + "Also applies the wither shield scroll ability reducing damage taken and granting an Absorption shield for 5 seconds.\n"
				  + "Mana cost: 190");
			

		}

		public override void HoldItem(Player player)
		{
			player.statManaMax2 += 20;
		}




		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.shootSpeed = 0;
			Item.sellPrice(20, 0, 0, 0);
			Item.damage = 200;
			Item.DamageType = DamageClass.Melee;
			Item.mana = 0;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 3;
			Item.noMelee = false;
			Item.knockBack = 0;
			Item.crit = 80;
			Item.rare = ItemRarityID.Gray;
			Item.autoReuse = false;
			Item.useAnimation = 3;


            abilityProjectile = ModContent.ProjectileType<Projectiles.Witherimpact>();
            abilityDamage = 1000;
            manaDamageMultiply = 2f;
            abilityKnockback = 0;
        }



        public override void Ablity(Player player)
        {
            SoundEngine.PlaySound(new SoundStyle("Skyblock/Sounds/Item/WitherImpactSound"));


            //setting Up tp
            Vector2 playerPos = player.position;
            Vector2 curserWorld = Main.MouseWorld;
            Vector2 PlayerToCurser = curserWorld - playerPos;
            Vector2 direction = PlayerToCurser.SafeNormalize(Vector2.UnitX);

            //executing tp untill collision
            for (int i = 0; i < 250; i++)
            {
                Vector2 distance = new(i, i);
                Vector2 nextLocation = playerPos + (direction * distance);


                if (!Collision.SolidCollision(nextLocation, player.width, player.height)) player.position = nextLocation;
                else break;

            }

            //Wither Shield effect
            if (!player.HasBuff(ModContent.BuffType<Buffs.WitherShield>()) && player.statLife != player.statLifeMax2 && player.altFunctionUse == 2)
            {
                player.AddBuff(ModContent.BuffType<Buffs.WitherShield>(), 300, false, true);
                player.statLife += player.GetWeaponCrit(Item) * 2;
                player.HealEffect(player.GetWeaponCrit(Item) * 2, true);
                SoundEngine.PlaySound(new SoundStyle("Skyblock/Sounds/Item/WitherImpactSound"));
                for (int i = 0; i < 50; i++)
                {
                    Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                    Dust d = Dust.NewDustPerfect(Main.LocalPlayer.Top, DustID.PurpleCrystalShard, speed * 5, Scale: 1.5f);
                    d.noGravity = true;
                }
            }

        }


        public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("Skyblock:WitherBlades")
				.AddIngredient(ItemID.FragmentVortex, 24)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
	
}
