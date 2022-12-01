using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDream : MonoBehaviour
{
    [SerializeField] private GameObject dreamPortal;
    [SerializeField] private GameObject otherPanelOne;
    [SerializeField] private GameObject otherPanelTwo;
    [SerializeField] private GameObject otherPanelOneGray;
    [SerializeField] private GameObject otherPanelTwoGray;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Bag")
        {
            dreamPortal.SetActive(true);

            otherPanelOne.SetActive(false);
            otherPanelTwo.SetActive(false);

            otherPanelOneGray.SetActive(true);
            otherPanelTwoGray.SetActive(true);

            Destroy(this.gameObject);
        }
    }
}
