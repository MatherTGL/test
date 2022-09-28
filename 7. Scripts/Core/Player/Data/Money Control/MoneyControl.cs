using Bank;
using Player;
using UnityEngine;

namespace DataMoneyControl
{
    public sealed class MoneyControl : IMoneyControl
    {
        private static IConfigDataPlayer _IConfigDataPlayer;
        public static IBank IBank;


        void IMoneyControl.Initialization(in IMoneyControl moneyControl, in IConfigDataPlayer configDataPlayer)
        {
            Debug.Log("Initialization MoneyControl");
            Debug.Log(moneyControl);
            Debug.Log(configDataPlayer);
            _IConfigDataPlayer = configDataPlayer;

            BankInitialization(moneyControl);
        }

        void IMoneyControl.AddMoney(in double amount)
        {
            Debug.Log("Add Money");
            _IConfigDataPlayer.AddMoney(amount);
        }

        void IMoneyControl.ReduceMoney(in double amount)
        {
            Debug.Log("Reduce Money");
            _IConfigDataPlayer.ReduceMoney(amount);
        }

        private void BankInitialization(in IMoneyControl moneyControl)
        {
            IBank = new BankControl();
            IBank.Initialization(moneyControl);
        }
    }
}