using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Skyblock.Items
{
    public abstract class SkyblockItem : ModItem
    {
        public float manaDamageMultiply = 1;

        public int abilityDamage;

        public int abilityProjectile;

        public int abilityKnockback;




        public override bool AltFunctionUse(Player player) { return true; }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.damage = abilityDamage;
                Item.damage += (int) manaDamageMultiply * player.statManaMax2;
            }

            return true;
        }


        public virtual void Ablity(Player player)
        {

        }

        public override bool? UseItem(Player player)
        {

            if (player.altFunctionUse == 2)
            {
                Ablity(player);
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), player.position, Vector2.Zero, abilityProjectile, Item.damage, abilityKnockback, player.whoAmI);
            }
            return true;
        }

        

    }

}
