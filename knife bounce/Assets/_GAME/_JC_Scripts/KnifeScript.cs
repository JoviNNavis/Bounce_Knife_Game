using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class KnifeScript : MonoBehaviour
{
    private bool isTouch;

    private bool isRelease = false;

    public float fireRate;

    [SerializeField] private float fireTime;
    [SerializeField] private float nextfireRate;

    public GameObject knife;
    public GameObject PlayerRank;

    public Transform newBallPos;

    public Image playerImg;

    public float fillValue;
    public float rankValue;

    public GameObject counterText;

    void Start()
    {

    }


    void Update()
    {
        transform.Rotate(0.5f, 0, 0);
        if(Input.GetMouseButton(1))
        {
            Shooting();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {

                isTouch = true;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                StartCoroutine(txtDisable());
                isTouch = false;
            }

            if (isTouch)
            {         
                Shooting();
            }
        }
    }

    void Shooting()
    {
        counterText.SetActive(true);
        fireTime += Time.deltaTime;
        nextfireRate = 1 / fireRate;

        if (fireTime >= nextfireRate)
        {
            Instantiate(knife, transform.position, Quaternion.identity);
            transform.position += new Vector3(0, 0.7f, 0);
            newBallPos.transform.position += new Vector3(0, 0.7f, 0);
            transform.rotation = Quaternion.Euler(90, -180, 0);
            playerImg.fillAmount += fillValue;
            PlayerRank.transform.position += new Vector3(rankValue, 0, 0);
            fireTime = 0;
        }
    }

    IEnumerator txtDisable()
    {
        yield return new WaitForSeconds(0.5f);
        counterText.SetActive(false);
    }

}
