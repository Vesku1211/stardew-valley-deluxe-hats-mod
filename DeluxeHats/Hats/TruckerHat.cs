﻿using StardewValley;
using System;
using System.Linq;

namespace DeluxeHats.Hats
{
    public static class TruckerHat
    {
        public const string Name = "Trucker Hat";
        public const string Description = "When outside in summer get the Season Protection Buff:\n+2 Foraging\n+1 Farming\n+1 Fishing";
        public static void Activate()
        {
            HatService.OnUpdateTicked = (e) =>
            {
                Buff truckerHatBuff = Game1.buffsDisplay.otherBuffs.FirstOrDefault(x => x.which == HatService.BuffId);
                if (Game1.currentLocation.isOutdoors && Game1.currentSeason == "summer")
                {
                    if (truckerHatBuff == null)
                    {
                        truckerHatBuff = new Buff(
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
                        Game1.buffsDisplay.addOtherBuff(truckerHatBuff);
                        truckerHatBuff.description = "Season Protection\n+2 Foraging\n+1 Farming\n+1 Fishing";
                        truckerHatBuff.millisecondsDuration = Convert.ToInt32((20f - ((Game1.timeOfDay - 600f) / 100f)) * 43000);
                    }
                }
                else
                {
                    if (truckerHatBuff != null)
                    {
                        truckerHatBuff.millisecondsDuration = 0;
                    }
                }
            };
        }

        public static void Disable()
        {
            Buff truckerHatBuff = Game1.buffsDisplay.otherBuffs.FirstOrDefault(x => x.which == HatService.BuffId);
            if (truckerHatBuff != null)
            {
                truckerHatBuff.millisecondsDuration = 0;
            }
        }
    }
}
