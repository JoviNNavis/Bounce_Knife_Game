using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    public KnifeScript1 playerKnife;

    public KnifeScript knifePlayer2;

    public AiScript ai;

    public GameObject cam, button, playButon;

    public GameObject rewardPanel, levelPanel, chestPanel, ChestlosePanel, countdownPanel;

    public BonusKnifeScript bonusKnife;

    public UpScript up;

    public GameObject newPanel1, newPanel2;

    public GameObject arrow, oldImg, newImg;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameStart1()
    {
        cam.SetActive(false);
        button.gameObject.SetActive(false);
        StartCoroutine(playButton1());
    }

    public void gameStart11()
    {
        cam.SetActive(false);
        button.gameObject.SetActive(false);
        StartCoroutine(playButton11());
    }

    public void gameStart2()
    {
        cam.SetActive(false);
        button.gameObject.SetActive(true);
        StartCoroutine(playButton2());
    }

    public void gameStart3()
    {
        cam.SetActive(false);
        button.gameObject.SetActive(false);
        StartCoroutine(playButton1());
    }

    public void Bonus()
    {
        cam.SetActive(false);
        button.gameObject.SetActive(false);
        StartCoroutine(playButton3());
    }

    public void noThanks()
    {
        rewardPanel.SetActive(false);
        levelPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void BounsLvl()
    {
        levelPanel.SetActive(false);
        chestPanel.SetActive(true);
    }

    public void Ok()
    {
        newPanel1.SetActive(false);
    }

    public void Lose()
    {
        ChestlosePanel.SetActive(false);
        levelPanel.SetActive(true);
    }

    public void newOk()
    {
        newPanel2.SetActive(false);
        newPanel2.transform.DOScale(new Vector3(0, 0, 0), 0.1f);
        arrow.SetActive(true);
        oldImg.SetActive(false);
        newImg.SetActive(true);
    }

    public void ExtraReward()
    {
        rewardPanel.SetActive(false);
        countdownPanel.SetActive(true);
    }

    public void ExtraChest()
    {
        ChestlosePanel.SetActive(false);
        countdownPanel.SetActive(true);
    }

    IEnumerator playButton1()
    {
        yield return new WaitForSeconds(2f);
        playerKnife.enabled = true;
        //playButon.SetActive(true);
    }

    IEnumerator playButton11()
    {
        yield return new WaitForSeconds(2f);
        knifePlayer2.enabled = true;
        ai.enabled = true;
        //playButon.SetActive(true);
    }

    IEnumerator playButton2()
    {
        yield return new WaitForSeconds(5.5f);
        knifePlayer2.enabled = true;
        ai.enabled = true;
        //playButon.SetActive(true);
    }

    IEnumerator playButton3()
    {
        yield return new WaitForSeconds(2.25f);
        bonusKnife.enabled = true;
        up.enabled = true;
        //playButon.SetActive(true);
    }



    public void nextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
