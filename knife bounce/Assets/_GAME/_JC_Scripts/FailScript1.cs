using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;

public class FailScript1 : MonoBehaviour
{
    public List<Transform> Knifes = new List<Transform>();

    public KnifeScript knife1;

    public GameObject KnifePlayer;

    public GameObject newBall;
    public Transform newBallPos;

    public GameObject playerUiPos;
    public Image playerImg;

    void Start()
    {
        //Knifes.Add(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && Knifes.Count == 1)
        {
            //knifeRemove();
            StartCoroutine(knifeR1());
        }

        if (Input.GetKeyDown(KeyCode.G) && Knifes.Count == 2)
        {
            //knifeRemove();
            StartCoroutine(knifeR2());
        }


        if (Input.GetKeyDown(KeyCode.G) && Knifes.Count <= 3)
        {
            //knifeRemove();
           StartCoroutine(knifeR3());
        }

        //for(int i = 0; i < Knifes.Count; i++)
        //{
        //    var firstKnife = Knifes.
        //}
    }
    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.tag == "Knife")
    //    {
    //        knifeCounter.knifeCountValue += 1;
    //        Knifes.Add(collision.transform);
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Knife")
        {
            knifeCounter.knifeCountValue += 1;
            Knifes.Add(other.transform);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Knife")
        //{
        //    knifeCounter.knifeCountValue += 1;
        //    Knifes.Add(collision.transform);
        //}

        if (collision.gameObject.tag == "Ball" && Knifes.Count == 1)
        {
            Destroy(collision.gameObject, 0.1f);
            knife1.enabled = false;
            StartCoroutine(knifeR1());
        }

        if (collision.gameObject.tag == "Ball" && Knifes.Count == 2)
        {
            Destroy(collision.gameObject, 0.1f);
            knife1.enabled = false;
            StartCoroutine(knifeR2());
        }

        if (collision.gameObject.tag == "Ball" && Knifes.Count >= 3)
        {
            Destroy(collision.gameObject, 0.1f);
            knife1.enabled = false;
            StartCoroutine(knifeR3());
        }
    }
    IEnumerator knifeR1()
    {
        yield return new WaitForSeconds(0.5f);
        Knifes.ElementAt(Knifes.Count - 1).DOMoveX(1, 0.08f, false).OnComplete(knifeRemove);
        yield return new WaitForSeconds(0.4f);
        knife1.enabled = true;
        Instantiate(newBall, newBallPos.position, Quaternion.identity);
    }

    IEnumerator knifeR2()
    {
        yield return new WaitForSeconds(0.5f);
        Knifes.ElementAt(Knifes.Count - 1).DOMoveX(1, 0.08f, false).OnComplete(knifeRemove);
        playerImg.fillAmount -= 0.01335f;
        playerUiPos.transform.position -= new Vector3(5.5f, 0, 0);
        KnifePlayer.transform.position -= new Vector3(0, 0.7f, 0);
        newBallPos.transform.position -= new Vector3(0, 0.7f, 0);
        yield return new WaitForSeconds(0.3f);
        Knifes.ElementAt(Knifes.Count - 1).DOMoveX(1, 0.08f, false).OnComplete(knifeRemove);
        playerImg.fillAmount -= 0.01335f;
        playerUiPos.transform.position -= new Vector3(5.5f, 0, 0);
        KnifePlayer.transform.position -= new Vector3(0, 0.7f, 0);
        newBallPos.transform.position -= new Vector3(0, 0.7f, 0);
        yield return new WaitForSeconds(0.4f);
        knife1.enabled = true;
        Instantiate(newBall, newBallPos.position, Quaternion.identity);
    }

    IEnumerator knifeR3()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("1");
        Knifes.ElementAt(Knifes.Count - 1).DOMoveX(1, 0.03f, false).OnComplete(knifeRemove);
        playerImg.fillAmount -= 0.01335f;
        playerUiPos.transform.position -= new Vector3(5.5f, 0, 0);
        KnifePlayer.transform.position -= new Vector3(0, 0.7f, 0);
        newBallPos.transform.position -= new Vector3(0, 0.7f, 0);
        yield return new WaitForSeconds(0.45f);
        Debug.Log("2");
        Knifes.ElementAt(Knifes.Count - 1).DOMoveX(1, 0.03f, false).OnComplete(knifeRemove);
        playerImg.fillAmount -= 0.01335f;
        playerUiPos.transform.position -= new Vector3(5.5f, 0, 0);
        KnifePlayer.transform.position -= new Vector3(0, 0.7f, 0);
        newBallPos.transform.position -= new Vector3(0, 0.7f, 0);
        yield return new WaitForSeconds(0.45f);
        Knifes.ElementAt(Knifes.Count - 1).DOMoveX(1, 0.01f, false);
        Knifes.ElementAt(Knifes.Count - 1).gameObject.SetActive(false);
        Knifes.RemoveAt(Knifes.Count - 1);
        Debug.Log("3");
        playerImg.fillAmount -= 0.01335f;
        playerUiPos.transform.position -= new Vector3(5.5f, 0, 0);
        KnifePlayer.transform.position -= new Vector3(0, 0.7f, 0);
        newBallPos.transform.position -= new Vector3(0, 0.7f, 0);
        yield return new WaitForSeconds(0.4f);
        knife1.enabled = true;
        Instantiate(newBall, newBallPos.position, Quaternion.identity);      
    }

    IEnumerator knifeR4()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("1");
        Knifes.ElementAt(Knifes.Count - 1).DOMoveX(1, 0.03f, false).OnComplete(knifeRemove);
        playerImg.fillAmount -= 0.01335f;
        playerUiPos.transform.position -= new Vector3(5.5f, 0, 0);
        KnifePlayer.transform.position -= new Vector3(0, 0.7f, 0);
        yield return new WaitForSeconds(0.45f);
        Debug.Log("2");
        Knifes.ElementAt(Knifes.Count - 1).DOMoveX(1, 0.03f, false).OnComplete(knifeRemove);
        playerImg.fillAmount -= 0.01335f;
        playerUiPos.transform.position -= new Vector3(5.5f, 0, 0);
        KnifePlayer.transform.position -= new Vector3(0, 0.7f, 0);
        yield return new WaitForSeconds(0.45f);
        Knifes.ElementAt(Knifes.Count - 1).DOMoveX(1, 0.01f, false);
        Knifes.ElementAt(Knifes.Count - 1).gameObject.SetActive(false);
        Knifes.RemoveAt(Knifes.Count - 1);
        Debug.Log("3");
        playerImg.fillAmount -= 0.01335f;
        playerUiPos.transform.position -= new Vector3(5.5f, 0, 0);
        KnifePlayer.transform.position -= new Vector3(0, 0.7f, 0);
        yield return new WaitForSeconds(0.4f);
        knife1.enabled = true;
    }

    public void knifeRemove()
    {
        Knifes.ElementAt(Knifes.Count - 1).gameObject.SetActive(false);
        Knifes.RemoveAt(Knifes.Count - 1);
    }

    public void failed()
    {
        StartCoroutine(knifeR4());
    }
}
