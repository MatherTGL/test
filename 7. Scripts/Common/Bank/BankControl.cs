using DataMoneyControl;
using UnityEngine;

namespace Bank
{
    public sealed class BankControl : IBank
    {
        private IMoneyControl _IMoneyControl;


        void IBank.Initialization(in IMoneyControl moneyControl)
        {
            Debug.Log("Initialization Bank");
            Debug.Log(moneyControl);
            //Подгрузка сейвов и прочее-прочее
        }

        void IBank.TakeLoan(double amountBorrowedMoney)
        {
            Debug.Log("Take Loan");
            _IMoneyControl.AddMoney();
        }

        void IBank.RepayLoad(double amountMoneyDiscarded)
        {
            Debug.Log("Repay Loan");
            _IMoneyControl.ReduceMoney();
        }
    }
}