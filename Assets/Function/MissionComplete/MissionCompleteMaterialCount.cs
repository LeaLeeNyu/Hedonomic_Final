using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionCompleteMaterialCount : MonoBehaviour
{
    //Material Related
    public static bool countMaterial = true;
    public static int surplusMaterial;
    public int materialScore;
    [SerializeField] private TMP_Text materialScoreText;

    //Time Related
    public float timer;
    private bool timeUp = false;
    [SerializeField] private TMP_Text time;
    [SerializeField] private TMP_Text timeScoreText;
    public int timeScore;

    //Count all the score
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject guide;
    [SerializeField] private GameObject zerostar;
    [SerializeField] private GameObject onestar;
    [SerializeField] private GameObject twostar;
    [SerializeField] private GameObject threestar;

    [SerializeField] private dreamType type; 

    private void OnEnable()
    {
        if (type == dreamType.Ancient)
        {
            AncientDreamTrigger.ancientDreamTrigger += CountScore;
        }
        else if (type == dreamType.Club)
        {
            ClubDreamTrigger.clubDreamTrigger += CountScore;
        }
        else if(type == dreamType.House)
        {
            HouseDreamTrigger.houseDreamTrigger += CountScore;
        }
    }

    private void OnDisable()
    {
        if (type == dreamType.Ancient)
        {
            AncientDreamTrigger.ancientDreamTrigger -= CountScore;
        }
        else if (type == dreamType.Club)
        {
            ClubDreamTrigger.clubDreamTrigger -= CountScore;
        }
        else if (type == dreamType.House)
        {
            HouseDreamTrigger.houseDreamTrigger -= CountScore;
        }
    }

    private void Update()
    {
        if (!timeUp)
            timer += Time.deltaTime;
    }

    void CountScore()
    {
        //Time related
        timeUp = true;

        time.text = (Mathf.Round(timer * 100) / 100).ToString() + "s";

        if (timer < 60f)
        {
            timeScore = 500;
        }
        else if (timer < 600f)
        {
            timeScore = 100;
        }
        else if (timer < 1200f)
        {
            timeScore = 50;
        }
        else
        {
            timeScore = 10;
        }

        timeScoreText.text = timeScore.ToString();

        //Material Related
        countMaterial = false;
        materialScore = surplusMaterial * 10;
        materialScoreText.text = "+" + materialScore.ToString();

        //Count all score
        panel.SetActive(true);
        guide.SetActive(false);

        int finalScore = materialScore + timeScore;

        //Debug.Log("Panel " + materialScore.materialScore);

        if (finalScore <= 10)
        {
            zerostar.SetActive(true);
        }
        else if (finalScore <= 50)
        {
            onestar.SetActive(true);
        }
        else if (finalScore <= 100)
        {
            twostar.SetActive(true);
        }
        else
        {
            threestar.SetActive(true);
        }
    }
}
