using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;

public class FailScript : MonoBehaviour
{
    public List<Transform> Knifes = new List<Transform>();

    public KnifeScript1 knife1;

    public GameObject KnifePlayer;

    public GameObject newBall;
    public Transform newBallPos;

    public Image playerImg;

    void Start()
    {
        //Knifes.Add(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G) && Knifes.Count >= 3)
        {
            //StartCoroutine(knifeRemove());
        }

        //for(int i = 0; i < Knifes.Count; i++)
        //{
        //    var firstKnife = Knifes.
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Knife")
        {
            knifeCounter.knifeCountValue += 1;
            Knifes.Add(collision.transform);
        }
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
        playerImg.fillAmount -= 0.025f;
        KnifePlayer.transform.position -= new Vector3(0, 0.7f, 0);
        newBallPos.transform.position -= new Vector3(0, 0.7f, 0);
        yield return new WaitForSeconds(0.3f);
        Knifes.ElementAt(Knifes.Count - 1).DOMoveX(1, 0.08f, false).OnComplete(knifeRemove);
        playerImg.fillAmount -= 0.025f;
        KnifePlayer.transform.position -= new Vector3(0, 0.7f, 0);
        newBallPos.transform.position -= new Vector3(0, 0.7f, 0);
        yield return new WaitForSeconds(0.4f);
        knife1.enabled = true;
        Instantiate(newBall, newBallPos.position, Quaternion.identity);
    }

    IEnumerator knifeR3()
    {
        yield return new WaitForSeconds(0.5f);
        Knifes.ElementAt(Knifes.Count - 1).DOMoveX(1, 0.08f, false).OnComplete(knifeRemove);
        playerImg.fillAmount -= 0.025f;
        KnifePlayer.transform.position -= new Vector3(0, 0.7f, 0);
        newBallPos.transform.position -= new Vector3(0, 0.7f, 0);
        yield return new WaitForSeconds(0.3f);
        Knifes.ElementAt(Knifes.Count - 1).DOMoveX(1, 0.08f, false).OnComplete(knifeRemove);
        playerImg.fillAmount -= 0.025f;
        KnifePlayer.transform.position -= new Vector3(0, 0.7f, 0);
        newBallPos.transform.position -= new Vector3(0, 0.7f, 0);
        yield return new WaitForSeconds(0.3f);
        Knifes.ElementAt(Knifes.Count - 1).DOMoveX(1, 0.08f, false).OnComplete(knifeRemove);
        playerImg.fillAmount -= 0.025f;
        KnifePlayer.transform.position -= new Vector3(0, 0.7f, 0);
        newBallPos.transform.position -= new Vector3(0, 0.7f, 0);
        yield return new WaitForSeconds(0.4f);
        knife1.enabled = true;
        Instantiate(newBall, newBallPos.position, Quaternion.identity);     
    }

    public void knifeRemove()
    {
        Knifes.ElementAt(Knifes.Count - 1).gameObject.SetActive(false);
        Knifes.RemoveAt(Knifes.Count - 1);
    }
}
