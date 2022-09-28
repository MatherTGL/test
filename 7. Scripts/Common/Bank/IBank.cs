using DataMoneyControl;

namespace Bank
{
    public interface IBank
    {
        void Initialization(in IMoneyControl moneyControl);
        void TakeLoan(in double amountBorrowedMoney);
        void RepayLoan(in double amountMoneyDiscarded);
    }
}