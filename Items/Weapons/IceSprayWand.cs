using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Skyblock;

namespace Skyblock.Items.Weapons
{
    class IceSprayWand : SkyblockItem
	{
		public override string Texture => "Skyblock/Textures/MoonLordsHandle";
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Ice Spray Wand");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

		}

		public override void HoldItem(Player player)
		{
			player.statManaMax2 += 20;


		}




		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.sellPrice(20, 0, 0, 0);
			Item.damage = 80;
			Item.DamageType = DamageClass.Melee;
			Item.mana = 0;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 5;
			Item.noMelee = false;
			Item.knockBack = 0;
			Item.crit = 50;
			Item.rare = ItemRarityID.Gray;
			Item.autoReuse = false;



            abilityProjectile = ModContent.ProjectileType<Projectiles.IceSpray>();
            abilityDamage = 200;
            manaDamageMultiply = 2f;
            abilityKnockback = 0;
        }	

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Gel, 1)
				.Register();

		}
	}
}

