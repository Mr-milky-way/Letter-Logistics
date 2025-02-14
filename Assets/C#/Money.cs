using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int money = 100;
    public TMP_Text moneyText;

    private void Update()
    {
        moneyText.text = "$" + money.ToString();
    }

}
