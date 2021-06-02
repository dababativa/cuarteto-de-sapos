using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theSun : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.RotateAround(Vector3.zero, Vector3.forward, 10f*Time.deltaTime);
        gameObject.transform.LookAt(Vector3.zero);
    }
}
