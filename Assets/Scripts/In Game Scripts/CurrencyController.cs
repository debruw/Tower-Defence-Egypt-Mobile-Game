using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyController : MonoBehaviour
{
    int currentCurrency;
    public Text currencyText;
    public Text curChange;

    private void Start()
    {
        SetCurrency(200);
    }

    private void Update()
    {
        currencyText.text = "Currency : " + currentCurrency;
    }

    public void ChangeCurrency(int change)
    {
        currentCurrency += change;
        if(change < 0)
        {
            curChange.color = Color.red;
            curChange.text = System.String.Empty + change;
        }
        else
        {
            curChange.color = Color.green;
            curChange.text = "+" + change;
        }
        Invoke("hideCurChangeText", .8f);
    }

    void hideCurChangeText()
    {
        curChange.text = System.String.Empty;
    }

    public int GetCurrency()
    {
        return currentCurrency;
    }

    public void SetCurrency(int value)
    {
        currentCurrency = value;
    }
}
