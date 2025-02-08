using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRot : MonoBehaviour
{
    public GameObject child, I;
    public input input;

    void Awake()
    {
        I = GameObject.Find("InputMan");
        input = I.GetComponent<input>();
        child.transform.rotation = input.CameraCenter.transform.rotation;
    }

}
