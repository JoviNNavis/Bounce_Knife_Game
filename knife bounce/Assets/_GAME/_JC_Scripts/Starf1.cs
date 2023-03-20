using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Starf1 : MonoBehaviour
{
    private MeshCollider meshCol;
    public MeshRenderer spike;
    public FailScript1 failS;
    public Starf1 sript;
    public bool inpowermode;
   public bool touched;
    void Start()
    {
        sript = this;
        touched = false;
        meshCol = GetComponent<MeshCollider>();
        spike = GetComponent<MeshRenderer>();
      touched =  false;
        StartCoroutine(starf());

    }

  
    void Update()
    {

        touched = FindObjectOfType<ParentSpikesript>().spikehit;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        
            if (other.CompareTag("Knife")&& !inpowermode)
            {
                   failS.failed();
                 meshCol.enabled = false;
                        spike.enabled = false;

        }
        

            if (other.CompareTag("Knife") && inpowermode)
            {
            meshCol.enabled = false;
            spike.enabled = false;
          //  Destroy(this.gameObject, 0.5f);
            }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Knife"))
        {
           
         
        
           
            touched = true;
        }
    }

    public void kill()
    {
        
    }
    IEnumerator starf()
    {
        
            transform.DOLocalMoveY(0.002f, 1.5f, false).SetEase(Ease.InOutSine);
            yield return new WaitForSeconds(0);
            transform.DOLocalMoveY(-0.013F, 1.5f, false).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
       
    }
}
