using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    string ubicacionPrefabs = "Prefabs/";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 posMouse = Input.mousePosition;
        //    Vector3 nuevaPos = Camera.main.ScreenToWorldPoint(posMouse);
        //    GameObject ball = Resources.Load<GameObject>(ubicacionPrefabs + "DefKitSoftbody");

        //    ball.transform.position = nuevaPos;
        //    Instantiate(ball);
        //}
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(r, out rayHit))
            {
                GameObject ball = Resources.Load<GameObject>(ubicacionPrefabs + "Bola");
                
                
                Vector3 hitpoint = rayHit.point;
                hitpoint.y += 2;
                hitpoint.z -= 0.5f;
                Instantiate(ball);
                ball.transform.position = hitpoint;
                
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(r, out rayHit))
            {
                GameObject ball = Resources.Load<GameObject>(ubicacionPrefabs + "Cubo");


                Vector3 hitpoint = rayHit.point;
                hitpoint.y += 2;
                hitpoint.z -= 0.5f;
                Instantiate(ball);
                ball.transform.position = hitpoint;

            }
        }
    }
}
