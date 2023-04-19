using Microsoft.Xna.Framework;
using On.Terraria.UI;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Skyblock.Items
{
    public abstract class SkyblockItem : ModItem
    {


        public string abilityName = "Add ability name";

        public string abilityDescription = "Add ability description";

        public float manaDamageMultiply = 1;

        public int abilityDamage;

        public int abilityProjectile;

        public int abilityKnockback;

        public int baseAbilityCooldown = 0;

        public int cooldown = 0;

        public int intelligence = 0;

        public int defense = 0;

        public int abilityCost;

        public override void UpdateInventory(Player player)
        {
            if (cooldown < baseAbilityCooldown) cooldown++;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "Ability name", "Item Ability: " + abilityName + " RIGHT CLICK"));
            tooltips.Add(new TooltipLine(Mod, "Ability description", abilityDescription));
            tooltips.Add(new TooltipLine(Mod, "Ability cost", "Mana cost: " + abilityCost.ToString()));
            tooltips.Add(new TooltipLine(Mod, "Ability cost", "Cooldown: " + (baseAbilityCooldown / 60).ToString() + "s"));



        }

        public override bool AltFunctionUse(Player player) { return true; }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                if (cooldown != baseAbilityCooldown) return false;
                Item.mana = abilityCost;
                return true;
            }
            else
            {
                Item.mana = 0;
                return true;
            }
            
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
                Item.mana = 0;
            }
            return true;
        }

        

    }

}
