using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Starf1 : MonoBehaviour
{
    private MeshCollider meshCol;
    public FailScript1 failS;

    // Start is called before the first frame update
    void Start()
    {
        meshCol = GetComponent<MeshCollider>();
        StartCoroutine(starf());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knife"))
        {
            failS.failed();
            Destroy(this.gameObject, 0.5f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Knife"))
        {
           // DOTween.Kill(transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("KnifePref"))
        {
            this.enabled = false;
            meshCol.enabled = false;
            Destroy(this.gameObject, 0.25f);
        }
    }

    IEnumerator starf()
    {
        transform.DOLocalMoveZ(1.53f, 1f, false).SetEase(Ease.InOutSine);
        yield return new WaitForSeconds(0);
        transform.DOLocalMoveZ(-1.53f, 1f, false).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}
