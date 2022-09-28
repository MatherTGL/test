using UnityEngine;
using Player;

namespace DataMoneyControl
{
    public interface IMoneyControl
    {
        void Initialization(in IMoneyControl moneyControl, in IConfigDataPlayer configDataPlayer);
        void AddMoney(in double amount);
        void ReduceMoney(in double amount);
    }
}