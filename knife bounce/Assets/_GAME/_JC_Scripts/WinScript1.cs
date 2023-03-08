using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WinScript1 : MonoBehaviour
{
    public GameObject blast, winText;
    public GameObject lvl, retry;

    public KnifeScript1 playerKnife;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Knife"))
        {
            playerKnife.enabled = false;
            lvl.SetActive(false);
            retry.SetActive(false);
            blast.SetActive(true);
            winText.SetActive(true);
        }
    }
}
