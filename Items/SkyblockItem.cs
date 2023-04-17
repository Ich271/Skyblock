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

        public int baseAbilityCooldown = 0;

        public int cooldown = 0;

        public int intelligence;





        public override void UpdateInventory(Player player)
        {
            if (cooldown < baseAbilityCooldown) cooldown++;
        }



        public override bool AltFunctionUse(Player player) { return true; }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                if (cooldown != baseAbilityCooldown) return false; 

                Item.damage = abilityDamage;
                Item.damage += (int)manaDamageMultiply * player.statManaMax2;

                return true;
            }
            else return true;
            
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
                cooldown = 0;
            }
            return true;
        }

        

    }

}
