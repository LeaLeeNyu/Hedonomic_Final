using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionCompleteMaterialCount : MonoBehaviour
{
    public static int surplusMaterial;
    public int materialScore;
    [SerializeField] private TMP_Text materialScoreText;

    private void OnEnable()
    {
        AncientDreamTrigger.ancientDreamTrigger += MaterialSocre;
    }

    private void OnDisable()
    {
        AncientDreamTrigger.ancientDreamTrigger -= MaterialSocre;
    }

    private void Start()
    {
        surplusMaterial = 0;
    }

    void MaterialSocre()
    {
        materialScore = surplusMaterial * 10;
        materialScoreText.text = "+" + materialScore.ToString();
    }
}
