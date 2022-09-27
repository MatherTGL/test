using UnityEngine;
using Player;

namespace DataMoneyControl
{
    public interface IMoneyControl
    {
        void Initialization(in IMoneyControl moneyControl, in IConfigDataPlayer configDataPlayer);
        void AddMoney();
        void ReduceMoney();
    }
}