﻿using StardewValley;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class CoolCap
    {
        public const string Name = "Cool Cap";
        public const string Description = "When outside in spring get the Season Protection Buff:\n+2 Foraging\n+1 Farming\n+1 Fishing";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff coolCapBuff = Game1.buffsDisplay.otherBuffs.FirstOrDefault(x => x.which == HatService.BuffId);
                if (Game1.currentLocation.isOutdoors && Game1.currentSeason == "spring")
                {
                    if (coolCapBuff == null)
                    {
                        coolCapBuff = new Buff(
                            farming: 1,
                            fishing: 1,
                            mining: 0,
                            digging: 0,
                            luck: 0,
                            foraging: 2,
                            crafting: 0,
                            maxStamina: 0,
                            magneticRadius: 0,
                            speed: 0,
                            defense: 0,
                            attack: 0,
                            minutesDuration: 1,
                            source: "Deluxe Hats",
                            displaySource: Name)
                        {
                            which = HatService.BuffId,
                        };
                        Game1.buffsDisplay.addOtherBuff(coolCapBuff);
                        coolCapBuff.description = "Season Protection\n+2 Foraging\n+1 Farming\n+1 Fishing";
                        coolCapBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    }
                }
                else
                {
                    if (coolCapBuff != null)
                    {
                        coolCapBuff.millisecondsDuration = 0;
                    }
                }
            };
        }

        public static void Disable()
        {
            Buff coolCapBuff = Game1.buffsDisplay.otherBuffs.FirstOrDefault(x => x.which == HatService.BuffId);
            if (coolCapBuff != null)
            {
                coolCapBuff.millisecondsDuration = 0;
            }
        }
    }
}
