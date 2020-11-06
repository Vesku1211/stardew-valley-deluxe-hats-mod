﻿using StardewValley;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class HuntersCap
    {
        public const string Name = "Hunter's Cap";
        public const string Description = "When outside in fall get the Season Protection Buff:\n+2 Foraging\n+1 Farming\n+1 Fishing";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff huntersCapBuff = Game1.buffsDisplay.otherBuffs.FirstOrDefault(x => x.which == HatService.BuffId);
                if (Game1.currentLocation.isOutdoors && Game1.currentSeason == "fall")
                {
                    if (huntersCapBuff == null)
                    {
                        huntersCapBuff = new Buff(
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
                        Game1.buffsDisplay.addOtherBuff(huntersCapBuff);
                        huntersCapBuff.description = "Season Protection\n+2 Foraging\n+1 Farming\n+1 Fishing";
                        huntersCapBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    }
                }
                else
                {
                    if (huntersCapBuff != null)
                    {
                        huntersCapBuff.millisecondsDuration = 0;
                    }
                }
            };
        }

        public static void Disable()
        {
            Buff huntersCapBuff = Game1.buffsDisplay.otherBuffs.FirstOrDefault(x => x.which == HatService.BuffId);
            if (huntersCapBuff != null)
            {
                huntersCapBuff.millisecondsDuration = 0;
            }
        }
    }
}
