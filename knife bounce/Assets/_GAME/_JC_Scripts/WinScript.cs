using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WinScript : MonoBehaviour
{
    public GameObject blast, winText;
    public GameObject lvl, retry;

    public GameObject newBall;
    public Transform jumpPos;

    public KnifeScript playerKnife;
    public AiScript aiKnife;
    public GameObject text;
    public GameObject lostPanel;

    public bool isLost = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isLost == false && other.CompareTag("Knife"))
        {
            playerKnife.enabled = false;
            aiKnife.enabled = false;
            lvl.SetActive(false);
            blast.SetActive(true);
            winText.SetActive(true);
            StartCoroutine(winJump());
            Destroy(text);
        }

        if (other.CompareTag("AiKnife"))
        {
            isLost = true;
            aiKnife.enabled = false;
        }

        if (isLost == true && other.CompareTag("Knife"))
        {
            playerKnife.enabled = false;
            aiKnife.enabled = false;
            lvl.SetActive(false);
            retry.SetActive(false);
            StartCoroutine(gameLost());        
        }
    }

    IEnumerator winJump()
    { 
        yield return new WaitForSeconds(3.5f);
        newBall.SetActive(true);
        newBall.transform.DOJump(jumpPos.position, 2, 1, 1, false);
        newBall.transform.SetParent(jumpPos.transform, true);
    }

    IEnumerator gameLost()
    {
        yield return new WaitForSeconds(1f);
        lostPanel.SetActive(true);
    }
}
