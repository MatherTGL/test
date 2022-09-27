using Bank;
using Player;
using UnityEngine;

namespace DataMoneyControl
{
    public sealed class MoneyControl : IMoneyControl
    {
        private IConfigDataPlayer _IConfigDataPlayer;
        private IBank _IBank;


        void IMoneyControl.Initialization(in IMoneyControl moneyControl, in IConfigDataPlayer configDataPlayer)
        {
            Debug.Log("Initialization MoneyControl");
            _IConfigDataPlayer = configDataPlayer;
            BankInitialization(moneyControl);
        }

        void IMoneyControl.AddMoney()
        {
            Debug.Log("Add Money");
            //_IConfigDataPlayer.AddMoney();
        }

        void IMoneyControl.ReduceMoney()
        {
            Debug.Log("Reduce Money");
            //_IConfigDataPlayer.ReduceMoney();
        }

        private void BankInitialization(in IMoneyControl moneyControl)
        {
            _IBank = new BankControl();
            _IBank.Initialization(moneyControl);
        }
    }
}