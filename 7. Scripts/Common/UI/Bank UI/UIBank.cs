using Bank;
using UnityEngine;
using Sirenix.OdinInspector;
using DataMoneyControl;

public sealed class UIBank : MonoBehaviour
{
    private static IBank _IBank;


    private void Awake() => _IBank = new BankControl();


    [Button("Take Loan")]
    public void TakeLoan()
    {
        Debug.Log("Take Loan");
        _IBank.TakeLoan(50000);
    }

    [Button("Repay Loan")]
    public void RepayLoan()
    {
        Debug.Log("Repay Loan");
        _IBank.RepayLoan(10000);
    }
}
