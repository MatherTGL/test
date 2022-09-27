using UnityEngine;

namespace Time_Control
{
    public sealed class TimeControl : ITimeControl
    {
        void ITimeControl.RecalculateTime(in byte month, in short Year)
        {
            Debug.Log("Recalculate Start");
            AddMonthTime();
            AddYearTime();
        }

        private void AddMonthTime()
        {
            Player.ConfigDataPlayerEditor.AddMonthTime();
        }

        private void AddYearTime()
        {
            Player.ConfigDataPlayerEditor.AddYearTime();
        }
    }
}