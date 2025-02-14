using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private List<GameObject> OnBelt;
    private input input;


    private void Start()
    {
        input = GameObject.Find("InputMan").GetComponent<input>();
        if (input.CamR.y == 90 || input.CamR.y == -270)
        {
            direction = Vector3.back;
        }
        else if (input.CamR.y == -90 || input.CamR.y == 270)
        {
            direction = Vector3.forward;
        }
        else if (input.CamR.y == -180 || input. CamR.y == 180)
        {
            direction = Vector3.left;
        }
        else
        {
            direction = Vector3.right;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnBelt.Add(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        OnBelt.Remove(collision.gameObject);
    }

    private void FixedUpdate()
    {
        for (int i = 0; i <= OnBelt.Count - 1; i++)
        {
            OnBelt[i].GetComponent<Rigidbody>().AddForce(speed * direction);
        }
    }
}
