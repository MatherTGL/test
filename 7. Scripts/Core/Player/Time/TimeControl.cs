using UnityEngine;

namespace Time_Control
{
    public sealed class TimeControl : ITimeControl
    {
        void ITimeControl.Initialization()
        {
            Debug.Log("Initialization TimeControl");
        }

        void ITimeControl.RecalculateTime(in byte month, in short year)
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