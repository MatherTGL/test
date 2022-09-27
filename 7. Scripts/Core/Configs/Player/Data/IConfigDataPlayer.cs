namespace Player
{
    public interface IConfigDataPlayer
    {
        void Initialization(in IConfigDataPlayer configDataPlayer);
        void RecalculateTime();
        void AddMonthTime();
        void AddYearTime();
        void AddMoney(in double amount);
        void ReduceMoney(in double amount);
    }
}