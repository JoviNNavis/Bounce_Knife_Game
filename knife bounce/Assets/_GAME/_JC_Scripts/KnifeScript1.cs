using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class KnifeScript1 : MonoBehaviour
{
    private bool isTouch;

    private bool isRelease = false;

    public float fireRate;

    [SerializeField] private float fireTime;
    [SerializeField] private float nextfireRate;

    public Transform newBallPos;
    public GameObject knife;
    public GameObject PlayerRank;

    public Image playerImg;
    public float rankValue;

    public GameObject countText;

    public FailScript fail;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.5f, 0, 0);
        if (Input.GetMouseButton(0))
        {
            Shooting();
        }
        else
        {
            //StartCoroutine(txtDisable());
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
        countText.SetActive(true);
        fireTime += Time.deltaTime;
        nextfireRate = 1 / fireRate;

        if (fireTime >= nextfireRate)
        {
            Instantiate(knife, transform.position, Quaternion.identity);
            //fail.Knifes.Add(transform);
            newBallPos.transform.position += new Vector3(0, 0.7f, 0);
            transform.position += new Vector3(0, 0.7f, 0);
            transform.rotation = Quaternion.Euler(90, -180, 0);
            playerImg.fillAmount += rankValue;
            fireTime = 0;
        }
    }

    IEnumerator txtDisable()
    {
        yield return new WaitForSeconds(0.5f);
        countText.SetActive(false);
    }
}
