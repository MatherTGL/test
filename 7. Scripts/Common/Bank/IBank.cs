using DataMoneyControl;

namespace Bank
{
    public interface IBank
    {
        void Initialization(in IMoneyControl moneyControl);
        void TakeLoan(double amountBorrowedMoney);
        void RepayLoad(double amountMoneyDiscarded);
    }
}