using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAiscript : MonoBehaviour
{
    private Rigidbody Rb;
    public bool isaicolor;
    public float upForce;
 public   bool level5above;

    void Start()
    {
        isaicolor = false;
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!level5above)
        {
            if (collision.gameObject.CompareTag("AiKnife") || collision.gameObject.CompareTag("DKnife"))
            {
                if (FindObjectOfType<Ballpowerup>().time < 0.3f)

                {
                    FindObjectOfType<ButtonManager>().isaicolor = true;
                    float _newUpforce = upForce + 150;
                    Rb.AddForce(transform.up * _newUpforce, ForceMode.Force);
                    FindObjectOfType<ButtonManager>().water.material.SetColor("_BaseColor", Color.blue);

                }
                else
                {
                    FindObjectOfType<ButtonManager>().water.material.SetColor("_BaseColor", FindObjectOfType<NewBallScript>()._blue);
                    FindObjectOfType<ButtonManager>().isaicolor = false;
                    Rb.AddForce(transform.up * upForce, ForceMode.Force);
                }
            }
        }
        if (level5above)
            {
                if (collision.gameObject.CompareTag("AiKnife") || collision.gameObject.CompareTag("DKnife"))
                {
                    if (FindObjectOfType<Ballpowerup>().time < 0.3f)

                    {
                        FindObjectOfType<ButtonManager>().isaicolor = true;
                        float _newUpforce = upForce + 150;
                        Rb.AddForce(transform.up * _newUpforce, ForceMode.Force);
                        FindObjectOfType<ButtonManager>().water.material.SetColor("_BaseColor", Color.blue);

                    }
                    else
                    {
                      
                        FindObjectOfType<ButtonManager>().isaicolor = false;
                        Rb.AddForce(transform.up * upForce, ForceMode.Force);
                    }
                }
            }


        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("AiKnife") || other.gameObject.CompareTag("DKnife"))
    //    {
    //        Rb.AddForce(transform.up * upForce, ForceMode.Force);
    //    }

        //if (other.gameObject.CompareTag("End"))
        //{
        //    transform.SetParent(other.transform, true);
        //    transform.position = other.transform.localPosition;
        //}
    //}
}
