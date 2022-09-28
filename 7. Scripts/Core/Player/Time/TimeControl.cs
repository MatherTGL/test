using Player;
using UnityEngine;

namespace Time_Control
{
    public sealed class TimeControl : ITimeControl
    {
        private static IConfigDataPlayer _IConfigDataPlayer;


        void ITimeControl.Initialization(in IConfigDataPlayer configDataPlayer)
        {
            Debug.Log("Initialization TimeControl");
            _IConfigDataPlayer = configDataPlayer;
        }

        void ITimeControl.RecalculateTime(in byte month, in short year)
        {
            Debug.Log("Recalculate Start");
            _IConfigDataPlayer.AddYearTime();
            //Будут вызываться от условий
            // AddMonthTime();
            // AddYearTime();
        }

        private void AddMonthTime()
        {
            _IConfigDataPlayer.AddMonthTime();
        }

        private void AddYearTime()
        {
            _IConfigDataPlayer.AddYearTime();
        }
    }
}