using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class input : MonoBehaviour
{
    [SerializeField]
    private Camera SceneCam;

    private Vector3 LastPos;

    [SerializeField]
    private LayerMask placementLayerMask, DestroyMask;

    public string targetTag = "Block";

    private GameObject OBJ;

    public GameObject Plane, CameraCenter;

    public Vector3 planeNew, CamNew, CamR;
    [SerializeField]
    Placementsys placementsys;
    
    public bool BuilingOn = false;

    private void Start()
    {
        CamNew = CameraCenter.transform.position;
        planeNew = Plane.transform.position;
    }
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && BuilingOn)
        {
            placementsys.placeObj();
        } else if (Input.GetKeyDown(KeyCode.Mouse1) && BuilingOn)
        {
            BuilingOn = false;
            placementsys.Builingsys.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            placementsys.DestroyOBJ();
        }
        GetOBJToRemove();
        OBJ = null;
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 )
        {
            planeNew.y = Plane.transform.position.y + 1;
            Plane.transform.position = planeNew;
            CamNew.y = CameraCenter.transform.position.y + 1;
            CameraCenter.transform.position = CamNew;
        } else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0 )
        {
            planeNew.y = Plane.transform.position.y - 1;
            Plane.transform.position = planeNew;
            CamNew.y = CameraCenter.transform.position.y - 1;
            CameraCenter.transform.position = CamNew;
        } 
        else if (Input.GetKeyDown(KeyCode.E))
        {
            CameraCenter.transform.Rotate(0, -90, 0);
            CamR.y -= 90;
            if (CamR.y == -360)
            {
                CamR.y = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            CameraCenter.transform.Rotate(0,90,0);
            CamR.y += 90;
            if (CamR.y == 360)
            {
                CamR.y = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (CamR.y == 90 || CamR.y == -270)
            {
                CamNew.x = CameraCenter.transform.position.x + 1;
            }
            else if (CamR.y == -90 || CamR.y == 270)
            {
                CamNew.x = CameraCenter.transform.position.x - 1;
            }
            else if (CamR.y == -180 || CamR.y == 180)
            {
                CamNew.z = CameraCenter.transform.position.z - 1;
            }
            else
            {
                CamNew.z = CameraCenter.transform.position.z + 1;
            }
            CameraCenter.transform.position = CamNew;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (CamR.y == 90 || CamR.y == -270)
            {
                CamNew.x = CameraCenter.transform.position.x - 1;
            }
            else if (CamR.y == -90 || CamR.y == 270)
            {
                CamNew.x = CameraCenter.transform.position.x + 1;
            }
            else if (CamR.y == -180 || CamR.y == 180)
            {
                CamNew.z = CameraCenter.transform.position.z + 1;
            }
            else
            {
                CamNew.z = CameraCenter.transform.position.z - 1;
            }
            CameraCenter.transform.position = CamNew;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (CamR.y == 90 || CamR.y == -270)
            {
                CamNew.z = CameraCenter.transform.position.z + 1;
            }
            else if (CamR.y == -90 || CamR.y == 270)
            {
                CamNew.z = CameraCenter.transform.position.z - 1;
            }
            else if (CamR.y == -180 || CamR.y == 180)
            {
                CamNew.x = CameraCenter.transform.position.x + 1;
            }
            else
            {
                CamNew.x = CameraCenter.transform.position.x - 1;
            }
            CameraCenter.transform.position = CamNew;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (CamR.y == 90 || CamR.y == -270)
            {
                CamNew.z = CameraCenter.transform.position.z - 1;
            }
            else if (CamR.y == -90 || CamR.y == 270)
            {
                CamNew.z = CameraCenter.transform.position.z + 1;
            }
            else if (CamR.y == -180 || CamR.y == 180)
            {
                CamNew.x = CameraCenter.transform.position.x - 1;
            }
            else
            {
                CamNew.x = CameraCenter.transform.position.x + 1;
            }
            CameraCenter.transform.position = CamNew;
        }
    }

    public GameObject GetOBJToRemove()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, DestroyMask))
        {
            if (hit.collider.transform.parent.gameObject.tag == targetTag)
            {
                OBJ = hit.collider.transform.parent.gameObject;
            }
        }
        return OBJ;
    }
}
