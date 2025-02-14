using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placementsys : MonoBehaviour
{
    public GameObject Builingsys;
    [SerializeField]
    private Money money;

    [SerializeField]
    private GameObject CellIndictor, Belt_1, Belt_3;
    public string currOBJ;

    private GameObject PlaceOBJ;
    [SerializeField]
    private input input;
    [SerializeField]
    private Grid grid;

    Vector3Int GridPos;

    private void Update()
    {
        Vector3 mousePos = input.GetSelectedMapPosition();
        GridPos = grid.WorldToCell(mousePos);
        CellIndictor.transform.position = GridPos;
    }
    
    public void placeObj()
    {
        if (!input.isRotating)
        {
            Instantiate(PlaceOBJ, GridPos, Quaternion.identity);
            input.BuilingOn = false;
            Builingsys.SetActive(false);
        }
    }

    public void DestroyOBJ()
    {
        Destroy(input.GetOBJToRemove());
    }

    public void Belt1()
    {
        if (money.money >= 20)
        {
            PlaceOBJ = Belt_1;
            input.BuilingOn = true;
            money.money -= 20;
            currOBJ = "1";
        }
        else
        {
            Builingsys.SetActive(false);
        }
    }

    public void Belt3()
    {
        if (money.money >= 50)
        {
            PlaceOBJ = Belt_3;
            input.BuilingOn = true;
            money.money -= 50;
            currOBJ = "3";
        }
        else
        {
            Builingsys.SetActive(false);
        }
    }
}
