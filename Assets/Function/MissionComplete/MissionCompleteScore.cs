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
    [SerializeField] private GameObject zerostar;
    [SerializeField] private GameObject onestar;
    [SerializeField] private GameObject twostar;
    [SerializeField] private GameObject threestar;

    public dreamType dreamtype;


    private void OnEnable()
    {
        AncientDreamTrigger.ancientDreamTrigger += DreamIsTriggered;
    }

    private void OnDisable()
    {
        AncientDreamTrigger.ancientDreamTrigger -= DreamIsTriggered;
    }

    void DreamIsTriggered()
    {
        panel.SetActive(true);

        int finalScore = materialScore.materialScore + timeScore.score;
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
