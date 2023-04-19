using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Skyblock.Rarities;

namespace Skyblock.Items.Weapons
{
    class IceSprayWand : SkyblockItem
	{
		public override string Texture => "Skyblock/Textures/MoonLordsHandle";
		public override void SetStaticDefaults()
		{

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

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
			Item.rare = ModContent.RarityType<RARE>();
			Item.autoReuse = false;



            abilityProjectile = ModContent.ProjectileType<Projectiles.IceSpray>();
            abilityDamage = 100;
			abilityCost = 100;
            manaDamageMultiply = 2f;
            abilityKnockback = 0;
			baseAbilityCooldown = 300;
			cooldown = 300;
			intelligence = 20;
			abilityName = "Ice Spray";
			abilityDescription = "Produces a cone of ice in front of the caster that deals 100 base damage to mobs and freezes them in place for 5 seconds! \nFrozen mobs take 10% increased damage!";
        }	

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Gel, 1)
				.Register();

		}
	}
}

