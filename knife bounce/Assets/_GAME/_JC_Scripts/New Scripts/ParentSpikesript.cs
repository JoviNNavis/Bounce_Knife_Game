using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSpikesript : MonoBehaviour
{

    public MeshRenderer rend;
    public bool spikehit;
    public GameObject beforeonr, afterone;
    public MeshRenderer mesh;
    public Collider meshcol;
    // Start is called before the first frame update
    void Start()
    {

        spikehit = false;
        afterone.SetActive(false);
        mesh = beforeonr.GetComponent<MeshRenderer>();
        meshcol = beforeonr.GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Knife"))
        {

           
            afterone.SetActive(true);
            mesh.enabled = false;
            spikehit = true;
            meshcol.enabled = false;
        }
        }
    void Update()
    {
        
    }
}
