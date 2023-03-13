using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class KnifePrefabScript : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    public JellyMesh jelly;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(1, 0, 0) * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Block") || other.gameObject.CompareTag("Finish"))
        {
            transform.position = new Vector3(-0.581f, transform.localPosition.y, transform.localPosition.z);
            StartCoroutine(disable());
            this.enabled = false;
        }

        if (other.gameObject.CompareTag("AfterBall"))
        {
            transform.position -= new Vector3(0, 0, 0) * 0 * Time.deltaTime;
            other.transform.SetParent(this.transform, true);
            transform.DOJump(new Vector3(10, 10, 10), 5, 1, 4);
            Destroy(this.gameObject, 0.5f);
            Destroy(other.gameObject, 0.3f);
        }
    }

    IEnumerator disable()
    {
        yield return new WaitForSeconds(3f);
        jelly.enabled = false;
    }
}
