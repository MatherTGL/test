using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections;
using Time_Control;

namespace Player
{
    [CreateAssetMenu(fileName = "DataPlayer", menuName = "Config/Player/Data/Create Config", order = 51)]
    public sealed class ConfigDataPlayerEditor : ScriptableObject, IConfigDataPlayer
    {
        [BoxGroup("Parameters")]
        [BoxGroup("Parameters/Time")]
        private byte _timeCurrentMonth;

        [BoxGroup("Parameters/Time")]
        private short _timeCurrentYear;

        private ITimeControl _ITimeControl;


        public void Initialization()
        {
            Debug.Log("Начало инициализации TimeControl");

            _ITimeControl = new TimeControl();

            Debug.Log("Конец инициализации TimeControl");
        }


        #region TimeControl

        public void RecalculateTime() => _ITimeControl.RecalculateTime(_timeCurrentMonth, _timeCurrentYear);

        public static void AddMonthTime()
        {
            Debug.Log("Added Month");
        }

        public static void AddYearTime()
        {
            Debug.Log("Added Year");
        }

        #endregion
    }
}