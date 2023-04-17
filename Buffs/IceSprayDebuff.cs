using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Skyblock.Buffs
{
    class IceSprayDebuff : ModBuff
    {

        public override string Texture => "Skyblock/Textures/WitherShield";


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Freeze");
            Description.SetDefault("Healing ability is on cooldown. Grands 10% damage reduction");
            Main.buffNoSave[Type] = true;
            BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
        }



    }

    public class FrozenNPC : GlobalNPC
    {

        public override bool PreAI(NPC npc)
        {
            if (npc.HasBuff<IceSprayDebuff>())
            {
                npc.velocity = Vector2.Zero;
                return false;
            }
            else return true;
        }
    }


}
