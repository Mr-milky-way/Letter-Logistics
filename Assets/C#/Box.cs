using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Money money;
    private void Awake()
    {
        money = GameObject.Find("MoneyMan").GetComponent<Money>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Death")
        {
            Destroy(gameObject);
        }
        if (collision.collider.gameObject.tag == "Endpoint")
        {
            money.money += 5;
            Destroy(gameObject);
        }
    }
}
