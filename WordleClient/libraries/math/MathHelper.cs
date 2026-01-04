using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordleClient.libraries.lowlevel;
namespace WordleClient.libraries.math
{
    public static class MathHelper
    {
        public static SinglePlayAnalytic AnalyseSingleResult(List<SingleplayerPlayLog> singlePlayLogs)
        {
            SinglePlayAnalytic analytic = new SinglePlayAnalytic();
            foreach (var log in singlePlayLogs)
            {
                analytic.playCount++;
                if (log.IsSolved)
                {
                    analytic.winCount++;
                    analytic.currentStreak++;
                    if (analytic.currentStreak > analytic.maxStreak)
                    {
                        analytic.maxStreak = analytic.currentStreak;
                    }
                    analytic.averageAttempts = ((analytic.averageAttempts * (analytic.winCount - 1)) + log.UsedAttempts) / analytic.winCount;
                }
                else
                {
                    analytic.currentStreak = 0;
                }
            }
            analytic.winRate = (double)analytic.winCount / analytic.playCount;
            return analytic;
        }
    }
}