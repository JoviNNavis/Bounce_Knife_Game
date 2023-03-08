using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpinScript : MonoBehaviour
{
    public newKnifeScript knife;
    public bool isOver= false;

    public GameObject losePanel;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, -0.5f, 0);

        if(isOver == true && knife.knifeCount == 0)
        {
            StartCoroutine(lose());
        }
    }

    IEnumerator lose()
    {
        yield return new WaitForSeconds(1f);
        losePanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        this.enabled = false;
    }
}
