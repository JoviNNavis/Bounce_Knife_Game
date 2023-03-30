using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class KnifeScript : MonoBehaviour
{
    private bool isTouch;
    public bool level1;
    private bool isRelease = false;
  public  bool ischangecolor;
    public float fireRate;
    public GameObject[] knifemat;
    [SerializeField] private float fireTime;
    [SerializeField] private float nextfireRate;
    public int totalblocks;
    public GameObject knife;
    public GameObject PlayerRank;
    int rand;
    int randcolors;
    public Transform newBallPos;
    private GameObject _knife;
    public Image playerImg;
    public bool playerchangecolor;
    public float fillValue;
    public float rankValue;

    public GameObject counterText;

    void Start()
    {
        fireRate = 7;
    }


    void Update()
    {
       
        ischangecolor = FindObjectOfType<ButtonManager>().changecolor;
        rand = Random.Range(0, knifemat.Length);
        transform.Rotate(0.5f, 0, 0);
        playerchangecolor = FindObjectOfType<ButtonManager>().changecolor;
        if (Input.GetMouseButton(1))
        {
            Shooting();
        }
        else
        {
            StartCoroutine(txtDisable());
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
          
                if (ischangecolor)
                {
                    _knife = Instantiate(knifemat[randcolors], transform.position, Quaternion.identity);
                    FindObjectOfType<FailScript1>().Knifes.Add(_knife.gameObject.transform);
                    randcolors++;
                    transform.position += new Vector3(0, 0.7f, 0);
                    newBallPos.transform.position += new Vector3(0, 0.7f, 0);
                    transform.rotation = Quaternion.Euler(90, -180, 0);
                    playerImg.fillAmount += fillValue;
                    PlayerRank.transform.position += new Vector3(rankValue, 0, 0);
                    fireTime = 0;
                    if (randcolors >= knifemat.Length)
                    {
                        randcolors = 0;
                    }
                }
                else
                {
                    GameObject _knife = Instantiate(knife, transform.position, Quaternion.identity);
                    FindObjectOfType<FailScript1>().Knifes.Add(_knife.gameObject.transform);

                    transform.position += new Vector3(0, 0.7f, 0);
                    newBallPos.transform.position += new Vector3(0, 0.7f, 0);
                    transform.rotation = Quaternion.Euler(90, -180, 0);
                    playerImg.fillAmount += fillValue;
                    PlayerRank.transform.position += new Vector3(rankValue, 0, 0);
                    fireTime = 0;
                }
            
          
        }
    }

    IEnumerator txtDisable()
    {
        yield return new WaitForSeconds(0.5f);
        counterText.SetActive(false);
    }

}