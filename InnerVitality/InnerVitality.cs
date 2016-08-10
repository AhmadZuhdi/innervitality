using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI;
using StardewValley;
using Microsoft.Xna.Framework;

namespace InnerVitality
{
    public class InnerVitality : Mod
    {
        public static Vector2 lastPlayerPosition;

        public override void Entry(params object[] objects)
        {
            base.Entry(objects);
            StardewModdingAPI.Events.GameEvents.OneSecondTick += Events_UpdateTick; // check condition every 1 second
        }

        private static void Events_UpdateTick(object sender, EventArgs e)
        {
            if (Game1.player == null)
                return;

            Vector2 currentPosition = Game1.player.getStandingPosition();

            if (lastPlayerPosition == null)
            {
                lastPlayerPosition = currentPosition;
            } else
            {
                if (currentPosition == lastPlayerPosition) // player standing in same plac
                {
                    float loseStamina = Game1.player.maxStamina - Game1.player.stamina;
                    float gainedStamina = loseStamina * 10 / 100;

                    Game1.player.stamina += gainedStamina;

                } else // player move
                {
                    lastPlayerPosition = currentPosition;
                }
            }
        }
    }
}
