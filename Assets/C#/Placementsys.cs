using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placementsys : MonoBehaviour
{
    [SerializeField]
    private GameObject CellIndictor, PlaceOBJ;

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
    }

    public void DestroyOBJ()
    {
        Destroy(input.GetOBJToRemove());
        Debug.Log("Destroyed");
    }
}
