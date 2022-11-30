using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionCompleteMaterialCount : MonoBehaviour
{
    public static bool countMaterial = true;
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


    void MaterialSocre()
    {
        countMaterial = false;
        materialScore = surplusMaterial * 10;
        materialScoreText.text = "+" + materialScore.ToString();
    }
}
