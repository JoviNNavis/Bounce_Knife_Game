using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAiscript : MonoBehaviour
{
    private Rigidbody Rb;

    public float upForce;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AiKnife") || collision.gameObject.CompareTag("DKnife"))
        {
            Rb.AddForce(transform.up * upForce, ForceMode.Force);
        }

        //if (collision.gameObject.CompareTag("End"))
        //{
        //    transform.SetParent(collision.transform, true);
        //    transform.position = collision.transform.localPosition;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AiKnife") || other.gameObject.CompareTag("DKnife"))
        {
            Rb.AddForce(transform.up * upForce, ForceMode.Force);
        }

        //if (other.gameObject.CompareTag("End"))
        //{
        //    transform.SetParent(other.transform, true);
        //    transform.position = other.transform.localPosition;
        //}
    }
}
