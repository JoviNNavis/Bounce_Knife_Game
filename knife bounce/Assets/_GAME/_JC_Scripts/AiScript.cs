using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiScript : MonoBehaviour
{
    public float fireRate1;

    [SerializeField]private float fireTime1;
    [SerializeField]private float nextfireRate1;

    public Transform newBallPos;

    public GameObject AiPalce;

    public float rankValue;

    public GameObject Knife;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
       StartCoroutine(shoot());
    }

    private void LateUpdate()
    {
        //StartCoroutine(shoot());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.5f, 0, 0);
    }

    IEnumerator shoot()
    {
        yield return new WaitForSeconds(1f);
        Shooting1();
    }

    void Shooting1()
    {
        fireTime1 += Time.deltaTime;
        nextfireRate1 = 2 / fireRate1;

        //nextfireRate1 = fireRate;

        if (fireTime1 >= nextfireRate1)
        {
            Instantiate(Knife, transform.position, Quaternion.Euler(0, 180, 0));
            transform.position += new Vector3(0, 0.7f, 0);
            newBallPos.transform.position += new Vector3(0, 0.7f, 0);
            transform.rotation = Quaternion.Euler(90, 0, 0);
            AiPalce.transform.position += new Vector3(rankValue, 0, 0);
            fireTime1 = 0;
        }
    }
}
