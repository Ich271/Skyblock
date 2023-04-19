using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Skyblock.Buffs
{
    class Absorption : ModBuff
    {

        public override string Texture => "Skyblock/Textures/WitherShield";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Absorption");
            Description.SetDefault("Adds an aditional number of hitpoints");
            Main.buffNoSave[Type] = false;
        }


        
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<AbsorptionPlayer>().hasAbsorption = true;
            Description.SetDefault(player.GetModPlayer<AbsorptionPlayer>().absorption.ToString());
        }

    }

    public class AbsorptionPlayer : ModPlayer
    {
        public bool hasAbsorption = false;
        public double absorption;
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit, int cooldownCounter)
        {
            if (hasAbsorption)
            {
                absorption -= damage;
                if (absorption <= 0) damage = 0;
                else damage = -absorption;
            }

           
        }

    }


}
