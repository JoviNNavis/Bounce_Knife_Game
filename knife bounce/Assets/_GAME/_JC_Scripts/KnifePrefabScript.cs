using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class KnifePrefabScript : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public Transform tower;
    public ParticleSystem drops;
    public JellyMesh jelly;

    public MeshRenderer knife;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
     

        transform.position -= new Vector3(0.7f, 0, 0) * speed * Time.deltaTime;
    }
  

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Block") || other.gameObject.CompareTag("Finish"))
        {
            Instantiate(drops, new Vector3(0.8f, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
            transform.position = new Vector3(-0.581f, transform.localPosition.y, transform.localPosition.z);
            StartCoroutine(disable());
            this.enabled = false;
        }

        if (other.gameObject.CompareTag("AfterBall"))
        {
            other.transform.SetParent(this.transform, true);
            transform.DOJump(new Vector3(10, 10, 10), 5, 1, 0.25f);
            Destroy(this.gameObject, 0.5f);
            Destroy(other.gameObject, 0.3f);
        }
    }

    IEnumerator disable()
    {
        yield return new WaitForSeconds(1f);
        jelly.enabled = false;
    }
}
