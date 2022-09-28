using DataMoneyControl;
using UnityEngine;

namespace Bank
{
    public sealed class BankControl : IBank
    {
        private static IMoneyControl _IMoneyControl;


        void IBank.Initialization(in IMoneyControl moneyControl)
        {
            Debug.Log("Initialization Bank");
            Debug.Log(moneyControl);

            _IMoneyControl = moneyControl;
            Debug.Log(_IMoneyControl);
            //Подгрузка сейвов и прочее-прочее
        }

        void IBank.TakeLoan(in double amountBorrowedMoney)
        {
            Debug.Log("Take Loan");

            _IMoneyControl.AddMoney(amountBorrowedMoney);
        }

        void IBank.RepayLoan(in double amountMoneyDiscarded)
        {
            Debug.Log("Repay Loan");
            _IMoneyControl.ReduceMoney(amountMoneyDiscarded);
        }

        private void Test()
        {
            Debug.Log(_IMoneyControl);
        }
    }
}