using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarParticulas : MonoBehaviour
{
    string ubicacionPrefabs = "Prefabs/";

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject objetoColision = collision.gameObject;
        print(objetoColision.tag);
        if (!objetoColision.CompareTag("splashParticleSystem"))
        {
            Vector3 pos = objetoColision.transform.position;
            GameObject particles = Resources.Load<GameObject>(ubicacionPrefabs + "Splash Particle System");
            particles.transform.position = pos;
            Instantiate(particles);
        }
        
    }

}
