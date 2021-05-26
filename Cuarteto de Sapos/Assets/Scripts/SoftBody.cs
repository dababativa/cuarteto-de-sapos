using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftBody : MonoBehaviour
{
    public float intensity = 5f;
    public float mass = 1f;
    public float stiffness = 0.5f;
    public float damping = 0.75f;
    private Mesh originalMesh, meshClone;
    private MeshRenderer renderer;
    private SoftVertex[] softVertices;
    private Vector3[] vertexArray;
    // Start is called before the first frame update
    void Start()
    {
        originalMesh = GetComponent<MeshFilter>().sharedMesh;
        meshClone = Instantiate(originalMesh);
        GetComponent<MeshFilter>().sharedMesh = meshClone;
        renderer = GetComponent<MeshRenderer>();
        softVertices = new SoftVertex[meshClone.vertices.Length];
        for(int i = 0; i < meshClone.vertices.Length; i++)
        {
            softVertices[i] = new SoftVertex(i, transform.TransformPoint(meshClone.vertices[i]));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vertexArray = originalMesh.vertices;
        for(int i = 0; i < softVertices.Length; i++)
        {
            Vector3 target = transform.TransformPoint(vertexArray[softVertices[i].id]);
            float intensity = (1 - (renderer.bounds.max.y - target.y) / renderer.bounds.size.y) * this.intensity;
            softVertices[i].Shake(target, mass, stiffness, damping);
            target = transform.InverseTransformPoint(softVertices[i].position);
            vertexArray[softVertices[i].id] = Vector3.Lerp(vertexArray[softVertices[i].id], target, intensity);

        }
        meshClone.vertices = vertexArray;
    }

    public class SoftVertex
    {
        public int id;
        public Vector3 position;
        public Vector3 velocity, force;
        public SoftVertex(int id, Vector3 pos)
        {
            this.id = id;
            this.position = pos;
        }

        public void Shake(Vector3 target, float m, float s, float d)
        {
            force = (target - position) * s;
            velocity = (velocity + force / m) * d;
            position += velocity;
            if((velocity+force + force / m).magnitude < 0.001f)
            {
                position = target;
            }
        }
    }

    

}
