using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placementsys : MonoBehaviour
{
    
    public GameObject Builingsys;

    [SerializeField]
    private GameObject CellIndictor, Belt_1, Belt_3;

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
        Instantiate(PlaceOBJ, GridPos, Quaternion.identity);
        input.BuilingOn = false;
        Builingsys.SetActive(false);
    }

    public void DestroyOBJ()
    {
        Destroy(input.GetOBJToRemove());
    }

    public void Belt1 ()
    {
        PlaceOBJ = Belt_1;
        input.BuilingOn = true;
    }

    public void Belt3()
    {
        PlaceOBJ = Belt_3;
        input.BuilingOn = true;
    }
}
