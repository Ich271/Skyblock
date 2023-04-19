using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Skyblock.Buffs;
using Skyblock.Rarities;

namespace Skyblock.Items.Weapons
{
	
	public class Hyperion : SkyblockItem

	{

        public override string Texture => "Skyblock/Textures/WitherBlade";




        public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.shootSpeed = 0;
			Item.sellPrice(20, 0, 0, 0);
			Item.damage = 150;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 5;
			Item.noMelee = false; 
			Item.knockBack = 0;
			Item.crit = 50;
            Item.rare = ModContent.RarityType<LEGENDARY>();
			Item.autoReuse = false;
			Item.useAnimation = 5;


            abilityProjectile = ModContent.ProjectileType<Projectiles.Witherimpact>();
            abilityDamage = 500;
            manaDamageMultiply = 2f;
            abilityKnockback = 0;
            intelligence = 200;
            abilityCost = 200;
            baseAbilityCooldown = 1;
            abilityName = "Wither Impact";
            abilityDescription = "Teleport 30 block infront of you and Implode dealing 500 base damage";
        }




        public override void Ablity(Player player)
        {
            SoundEngine.PlaySound(new SoundStyle("Skyblock/Sounds/Item/explode"));


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

            player.AddBuff(ModContent.BuffType<Buffs.Absorption>(), 300);
            player.GetModPlayer<AbsorptionPlayer>().absorption = 300;
            if (!player.HasBuff(ModContent.BuffType<Buffs.WitherShield>()) && player.statLife != player.statLifeMax2)
            {
                // player.AddBuff(ModContent.BuffType<Buffs.WitherShield>(), 300, false, true);
                // player.statLife += player.GetWeaponCrit(Item) * 2;
                // player.HealEffect(player.GetWeaponCrit(Item) * 2, true);
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
				.AddIngredient(ItemID.FragmentNebula, 24)
				.AddTile(TileID.LunarCraftingStation)
				.Register(); 
		}
	}
	
}
