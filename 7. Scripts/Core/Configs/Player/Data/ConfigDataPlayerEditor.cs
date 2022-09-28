using UnityEngine;
using Sirenix.OdinInspector;
using Time_Control;
using DataMoneyControl;

namespace Player
{
    [CreateAssetMenu(fileName = "DataPlayer", menuName = "Config/Player/Data/Create Config", order = 51)]
    public sealed class ConfigDataPlayerEditor : ScriptableObject, IConfigDataPlayer
    {
        #region Time
        [BoxGroup("Parameters")]
        [BoxGroup("Parameters/Time")]
        private byte _timeCurrentMonth;

        [BoxGroup("Parameters/Time")]
        private short _timeCurrentYear;

        private static ITimeControl _ITimeControl;
        #endregion

        #region Money
        [BoxGroup("Parameters/Resources")]
        private double _currentMoneyPlayer;

        private static IMoneyControl _IMoneyControl;
        #endregion


        void IConfigDataPlayer.Initialization(in IConfigDataPlayer configDataPlayer)
        {
            Debug.Log("Начало инициализации TimeControl");
            
            _ITimeControl = new TimeControl();
            _IMoneyControl = new MoneyControl();

            Debug.Log(_ITimeControl);
            Debug.Log(_IMoneyControl);

            _ITimeControl.Initialization(configDataPlayer);
            _IMoneyControl.Initialization(_IMoneyControl, configDataPlayer);

            Debug.Log("Конец инициализации TimeControl");
        }


        #region TimeControl

        void IConfigDataPlayer.RecalculateTime() => _ITimeControl.RecalculateTime(_timeCurrentMonth, _timeCurrentYear);

        void IConfigDataPlayer.AddMonthTime()
        {
            Debug.Log("Added Month");
        }

        void IConfigDataPlayer.AddYearTime()
        {
            Debug.Log("Added Year");
        }

        #endregion

        #region Money

        void IConfigDataPlayer.AddMoney(in double amount)
        {
            _currentMoneyPlayer += amount;
            Debug.Log(_currentMoneyPlayer);
        }

        void IConfigDataPlayer.ReduceMoney(in double amount)
        {
            _currentMoneyPlayer -= amount;
            Debug.Log(_currentMoneyPlayer);
        }

        #endregion
    }
}