using Microsoft.Xna.Framework;
using On.Terraria.UI;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Skyblock.Items
{
    public abstract class SkyblockItem : ModItem
    {


        public string abilityName;

        public float manaDamageMultiply = 1;

        public int abilityDamage;

        public int abilityProjectile;

        public int abilityKnockback;

        public int baseAbilityCooldown = 0;

        public int cooldown = 0;

        public int intelligence = 0;

        public int defense = 0;



        public override void UpdateInventory(Player player)
        {
            if (cooldown < baseAbilityCooldown) cooldown++;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
           
        }

        public override bool AltFunctionUse(Player player) { return true; }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                if (cooldown != baseAbilityCooldown) return false; 

                return true;
            }
            else return true;
            
        }


        public override void HoldItem(Player player)
        {
            player.statManaMax2 += intelligence;
            player.statDefense += defense;
        }


        public virtual void Ablity(Player player)
        {

        }

        public override bool? UseItem(Player player)
        {

            if (player.altFunctionUse == 2)
            {
                Ablity(player);


                int damage = abilityDamage * (1 + (player.statManaMax2 / 100));


                Projectile.NewProjectile(player.GetSource_ItemUse(Item), player.position, Vector2.Zero, abilityProjectile, damage, abilityKnockback, player.whoAmI);
                cooldown = 0;
            }
            return true;
        }

        

    }

}
