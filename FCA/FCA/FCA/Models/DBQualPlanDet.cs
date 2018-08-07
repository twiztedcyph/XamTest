using SQLite.Net.Attributes;
using System;

namespace FCA.Models
{
    public class DBQualPlanDet
    {
        [PrimaryKey]
        public string RecGUID { get; set; }
        public string PlanCode { get; set; }
        public string QualType { get; set; }
        public string QualCode { get; set; }
        public string Title { get; set; }

        public string AwardingBody { get; set; }

        public string Level { get; set; }

        public string StartUnit { get; set; }

        public int StartTime { get; set; }

        public string AchievementUnit { get; set; }

        public int AchievementTime { get; set; }

        public void CalcPlanDate(DateTime EpisodeStart, ref DateTime AimStart, ref DateTime AimExpEnd)
        {
            AimStart = DateTime.MinValue;
            AimExpEnd = DateTime.MinValue;

            if (EpisodeStart != DateTime.MinValue)
            {
                if (!string.IsNullOrEmpty(StartUnit) && (StartTime > 0))
                {
                    if (StartUnit == "D")
                        AimStart = EpisodeStart.AddDays(StartTime);
                    else if (StartUnit == "W")
                        AimStart = EpisodeStart.AddDays(StartTime * 7);
                    else if (StartUnit == "M")
                        AimStart = EpisodeStart.AddMonths(StartTime);
                }
                else if (!string.IsNullOrEmpty(AchievementUnit) && (AchievementTime > 0))
                {
                    AimStart = EpisodeStart;
                }
                if ((AimStart != DateTime.MinValue)
                        && !string.IsNullOrEmpty(AchievementUnit)
                        && (AchievementTime > 0))
                {
                    if (AchievementUnit == "D")
                        AimExpEnd = AimStart.AddDays(AchievementTime - 1);
                    else if (AchievementUnit == "W")
                        AimExpEnd = AimStart.AddDays((AchievementTime * 7) - 1);
                    else if (AchievementUnit == "M")
                    {
                        int nNASExtraDays = 0;
                        if ((StartTime == 0) && (AchievementTime == 12))
                        {
                            //not handling progtype 25 as prog type is never used in the equivalent function in WinFCA. 

                            if (DateTime.IsLeapYear(AimStart.Year))
                                nNASExtraDays = 2;
                            else
                                nNASExtraDays = 1;
                        }
                        AimExpEnd = AimStart.AddMonths(AchievementTime).AddDays(nNASExtraDays - 1);
                    }
                }
            }
        }
        [Ignore]
        public int TypeOrdering
        {
            get
            {
                switch (QualType)
                {
                    case "M":
                        return 1;
                    case "T":
                        return 2;
                    case "K":
                        return 3;
                    case "S":
                        return 4;
                    case "O":
                        return 5;
                    default:
                        return 9;
                }
            }
        }
    }
}
