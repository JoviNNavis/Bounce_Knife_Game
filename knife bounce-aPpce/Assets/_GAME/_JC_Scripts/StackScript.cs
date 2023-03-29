using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackScript : MonoBehaviour
{
    public GameObject blast;
    public GameObject stacks;

    public int stackCount = 50;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0.1f, 0);
        //balls.transform.Rotate(0, -0.5f, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Knife")
        {
            stackCount -= 1;
            Instantiate(blast, transform.position, Quaternion.Euler(-90, 0, 0));
            stacks.transform.position -= new Vector3(0, 0.15f, 0);
            Destroy(other.gameObject);
            Destroy(this.gameObject, 0.1f);
        }
    }
}
