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

    [SerializeField]
    private string targetTag = "Block";

    private GameObject OBJ;

    public GameObject Plane, CameraCenter;

    public Vector3 planeNew, CamNew, CamR;
    [SerializeField]
    Placementsys placementsys;
    
    public bool BuilingOn = false;

    public Money money;





    Quaternion targetRotation;
    [SerializeField]
    private float rotationSpeed = 10f;
    public bool isRotating = false;



    private void Start()
    {
        CamNew = CameraCenter.transform.position;
        planeNew = Plane.transform.position;
        targetRotation = CameraCenter.transform.rotation;
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
        if (isRotating)
        {
            Rotate();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && BuilingOn)
        {
            placementsys.placeObj();
        } else if (Input.GetKeyDown(KeyCode.Mouse1) && BuilingOn)
        {
            BuilingOn = false;
            if (placementsys.currOBJ == "1")
            {
                money.money += 20;
            }
            else if (placementsys.currOBJ == "3")
            {
                money.money += 50;
            }
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
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            CamR.y -= 90;
            if (CamR.y == -360)
            {
                CamR.y = 0;
            }

            targetRotation = Quaternion.Euler(0, CamR.y, 0);
            isRotating = true;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CamR.y += 90;
            if (CamR.y == 360)
            {
                CamR.y = 0;
            }
            targetRotation = Quaternion.Euler(0, CamR.y, 0);
            isRotating = true;
        }
        
    }


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (CamR.y == 90 || CamR.y == -270)
            {
                CamNew.x = CameraCenter.transform.position.x + 0.1f;
            }
            else if (CamR.y == -90 || CamR.y == 270)
            {
                CamNew.x = CameraCenter.transform.position.x - 0.1f;
            }
            else if (CamR.y == -180 || CamR.y == 180)
            {
                CamNew.z = CameraCenter.transform.position.z - 0.1f;
            }
            else
            {
                CamNew.z = CameraCenter.transform.position.z + 0.1f;
            }
            CameraCenter.transform.position = CamNew;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (CamR.y == 90 || CamR.y == -270)
            {
                CamNew.x = CameraCenter.transform.position.x - 0.1f;
            }
            else if (CamR.y == -90 || CamR.y == 270)
            {
                CamNew.x = CameraCenter.transform.position.x + 0.1f;
            }
            else if (CamR.y == -180 || CamR.y == 180)
            {
                CamNew.z = CameraCenter.transform.position.z + 0.1f;
            }
            else
            {
                CamNew.z = CameraCenter.transform.position.z - 0.1f;
            }
            CameraCenter.transform.position = CamNew;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (CamR.y == 90 || CamR.y == -270)
            {
                CamNew.z = CameraCenter.transform.position.z + 0.1f;
            }
            else if (CamR.y == -90 || CamR.y == 270)
            {
                CamNew.z = CameraCenter.transform.position.z - 0.1f;
            }
            else if (CamR.y == -180 || CamR.y == 180)
            {
                CamNew.x = CameraCenter.transform.position.x + 0.1f;
            }
            else
            {
                CamNew.x = CameraCenter.transform.position.x - 0.1f;
            }
            CameraCenter.transform.position = CamNew;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (CamR.y == 90 || CamR.y == -270)
            {
                CamNew.z = CameraCenter.transform.position.z - 0.1f;
            }
            else if (CamR.y == -90 || CamR.y == 270)
            {
                CamNew.z = CameraCenter.transform.position.z + 0.1f;
            }
            else if (CamR.y == -180 || CamR.y == 180)
            {
                CamNew.x = CameraCenter.transform.position.x - 0.1f;
            }
            else
            {
                CamNew.x = CameraCenter.transform.position.x + 0.1f;
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



    public void Rotate()
    {
        CameraCenter.transform.rotation = Quaternion.Slerp(CameraCenter.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        if (Quaternion.Angle(CameraCenter.transform.rotation, targetRotation) < 0.1f)
        {
            CameraCenter.transform.rotation = targetRotation;
            isRotating = false;
        }
    }
}
