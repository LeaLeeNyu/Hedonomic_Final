using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum dreamType
{
    Ancient,
    House,
    Club,
}

public class MissionCompleteScore : MonoBehaviour
{
    [SerializeField] private MissionCompleteMaterialCount materialScore;
    [SerializeField] private LevelTimeCounter timeScore;

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject guide;
    [SerializeField] private GameObject zerostar;
    [SerializeField] private GameObject onestar;
    [SerializeField] private GameObject twostar;
    [SerializeField] private GameObject threestar;

    public dreamType type;


    private void OnEnable()
    {
        if (type == dreamType.Ancient)
        {
            AncientDreamTrigger.ancientDreamTrigger += DreamIsTriggered;
        }
        else if (type == dreamType.Club)
        {
            ClubDreamTrigger.clubDreamTrigger += DreamIsTriggered;
        }
    }

    private void OnDisable()
    {
        if (type == dreamType.Ancient)
        {
            AncientDreamTrigger.ancientDreamTrigger -= DreamIsTriggered;
        }
        else if (type == dreamType.Club)
        {
            ClubDreamTrigger.clubDreamTrigger -= DreamIsTriggered;
        }
    }

    void DreamIsTriggered()
    {
        panel.SetActive(true);
        guide.SetActive(false);

        int finalScore = materialScore.materialScore + timeScore.score;

        //Debug.Log("Panel " + materialScore.materialScore);

        if(finalScore <= 10)
        {
            zerostar.SetActive(true);
        }else if(finalScore <= 50)
        {
            onestar.SetActive(true);
        }else if(finalScore <= 100)
        {
            twostar.SetActive(true);
        }
        else
        {
            threestar.SetActive(true);
        }
    }
}
