using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Skyblock.Items.Weapons;

namespace Skyblock
{
    public class Skyblock : Mod
	{

        public override void AddRecipeGroups()
        {
            RecipeGroup WitherBlades = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Wither Blade", new int[]
            {
            ModContent.ItemType<NecronsBladeUnrefined>(),
            ModContent.ItemType<Astrea>(),
            ModContent.ItemType<Hyperion>(),
            ModContent.ItemType<Scylla>(),
            ModContent.ItemType<Valkyrie>()
            });
            RecipeGroup.RegisterGroup("Skyblock:WitherBlades", WitherBlades);
        }


    }
}