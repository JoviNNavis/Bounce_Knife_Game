using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animScript : MonoBehaviour
{
    public Animator anim;

    public float waitTime;

    void Start()
    {
        waitTime = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball")||collision.gameObject.CompareTag("AiBall"))
        {
            StartCoroutine(animPlay());
        }
    }

    IEnumerator animPlay()
    {
        anim.SetBool("Bounce", true);
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("Bounce", false);
    }
}
