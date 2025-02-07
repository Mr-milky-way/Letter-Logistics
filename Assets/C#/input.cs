using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class input : MonoBehaviour
{
    [SerializeField]
    private Camera SceneCam;

    private Vector3 LastPos;

    [SerializeField]
    private LayerMask placementLayerMask, DestroyMask;

    public string targetTag = "Block";

    private GameObject OBJ;

    public GameObject Plane;

    Vector3 planeUp, planeDown;
    [SerializeField]
    Placementsys placementsys;


    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = SceneCam.nearClipPlane;
        Ray ray = SceneCam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, placementLayerMask))
        {
            LastPos = hit.point;
        }
        return LastPos;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            placementsys.placeObj();
        } else if (Input.GetKey(KeyCode.Mouse1))
        {
            placementsys.DestroyOBJ();
        }
        GetOBJToRemove();
        OBJ = null;
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 )
        {
            planeUp.y = Plane.transform.position.y + 1;
            Plane.transform.position = planeUp;
        } else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0 )
        {
            planeDown.y = Plane.transform.position.y - 1;
            Plane.transform.position = planeDown;
        }
        
    }

    public GameObject GetOBJToRemove()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, DestroyMask))
        {
            if (hit.collider.gameObject.tag == targetTag)
            {
                Debug.Log("Hit");
                OBJ = hit.collider.gameObject;
            }
        }
        return OBJ;
    }
}
