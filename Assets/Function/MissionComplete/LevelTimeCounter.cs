using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTimeCounter : MonoBehaviour
{
    public float timer;
    private bool timeUp = false;

    [SerializeField] private TMP_Text time;
    [SerializeField] private TMP_Text timeScore;
    public int score;

    [SerializeField] private dreamType type;

    private void OnEnable()
    {
        if(type == dreamType.Ancient)
        {
            AncientDreamTrigger.ancientDreamTrigger += TimeUp;
        }
        else if(type == dreamType.Club)
        {
            ClubDreamTrigger.clubDreamTrigger += TimeUp;
        }
        
    }

    private void OnDisable()
    {
        if (type == dreamType.Ancient)
        {
            AncientDreamTrigger.ancientDreamTrigger -= TimeUp;
        }
        else if (type == dreamType.Club)
        {
            ClubDreamTrigger.clubDreamTrigger -= TimeUp;
        }
    }

    private void Update()
    {
        if(!timeUp)
            timer += Time.deltaTime;
    }

    void TimeUp()
    {
        timeUp = true;

        time.text = (Mathf.Round(timer * 100) / 100).ToString() + "s";

        if (timer < 60f)
        {
            score = 500;
        }else if (timer < 600f)
        {
            score = 100;
        }
        else if (timer < 1200f)
        {
            score = 50;
        }
        else
        {
            score = 10;
        }

        timeScore.text = score.ToString();
    }
}
