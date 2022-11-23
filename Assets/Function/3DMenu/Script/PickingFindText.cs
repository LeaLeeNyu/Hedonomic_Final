using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickingFindText : MonoBehaviour
{
    [SerializeField] private TMP_Text timeLimitationText;
    private void OnEnable()
    {
        TimeLimitation.timeLimitationText = timeLimitationText;
    }
}
