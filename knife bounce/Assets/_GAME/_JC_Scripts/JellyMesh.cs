using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMesh : MonoBehaviour
{
    public float Intensity;
    public float mass;
    public float stiffness;
    public float damping;

    private Mesh originalMesh, meshClone;
    private MeshRenderer renderr;
    private JellyVertices[] jellyVertices;
    private Vector3[] vertexArray;

    void Start()
    {
        originalMesh = GetComponent<MeshFilter>().sharedMesh;
        meshClone = Instantiate(originalMesh);
        GetComponent<MeshFilter>().sharedMesh = meshClone;
        renderr = GetComponent<MeshRenderer>();
        jellyVertices = new JellyVertices[meshClone.vertices.Length];
        for (int i = 0; i < meshClone.vertices.Length; i++)
            jellyVertices[i] = new JellyVertices(i, transform.TransformPoint(meshClone.vertices[i]));
    }

    private void FixedUpdate()
    {
        vertexArray = originalMesh.vertices;
        for(int i = 0; i < jellyVertices.Length; i++)
        {
            Vector3 target = transform.TransformPoint(vertexArray[jellyVertices[i].Id]);
            float intensity = (1 - (renderr.bounds.max.y - target.y) / renderr.bounds.size.y) * Intensity;
            jellyVertices[i].shake(target, mass, stiffness, damping);
            target = transform.InverseTransformPoint(jellyVertices[i].Pos);
            vertexArray[jellyVertices[i].Id] = Vector3.Lerp(vertexArray[jellyVertices[i].Id], target ,intensity);
        }
        meshClone.vertices = vertexArray;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public class JellyVertices
    {
        public int Id;
        public Vector3 Pos;
        public Vector3 velocity, Force;

        public JellyVertices(int _id, Vector3 _pos)
        {
            Id = _id;
            Pos = _pos;
        }
        public void shake(Vector3 target, float m, float s, float d)
        {
            Force = (target - Pos) * s;
            velocity = (velocity + Force / m) * d;
            Pos += velocity;
            if ((velocity + Force + Force / m).magnitude < 0.001f)
                Pos = target;
        }
    }
}
