using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamActive : MonoBehaviour
{
    [SerializeField] private GameObject ancientMenuOn;
    [SerializeField] private GameObject ancientMenuOff;
    [SerializeField] private GameObject clubMenuOn;
    [SerializeField] private GameObject clubMenuOff;
    [SerializeField] private GameObject houseMenuOn;
    [SerializeField] private GameObject houseMenuOff;

    [SerializeField] private GameObject ancientPortal;
    [SerializeField] private GameObject housePortal;
    [SerializeField] private GameObject clubPortal;

    private void OnEnable()
    {
        ChooseLevel.chooseAncient += AncientActive;
        ChooseLevel.chooseClub += ClubActive;
        ChooseLevel.chooseHouse += HouseActive;
    }

    private void OnDisable()
    {
        ChooseLevel.chooseAncient -= AncientActive;
        ChooseLevel.chooseClub -= ClubActive;
        ChooseLevel.chooseHouse -= HouseActive;
    }

    void AncientActive()
    {
        clubMenuOn.SetActive(false);
        clubMenuOff.SetActive(true);
        houseMenuOn.SetActive(false);
        houseMenuOff.SetActive(true);

        ancientPortal.SetActive(true);
    }

    void ClubActive()
    {
        ancientMenuOn.SetActive(false);
        ancientMenuOff.SetActive(true);
        houseMenuOn.SetActive(false);
        houseMenuOff.SetActive(true);

        clubPortal.SetActive(true);
    }

    void HouseActive()
    {
        clubMenuOn.SetActive(false);
        clubMenuOff.SetActive(true);
        ancientMenuOn.SetActive(false);
        ancientMenuOff.SetActive(true);

        housePortal.SetActive(true);
    }
}
