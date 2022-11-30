using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSpawnInteractable : XRSimpleInteractable
{ 
    public int equipAmount;
    public int equipCurrentCount = 0;
    [SerializeField] private BuildingMaterialSO buildingMaterial;
    [SerializeField] private GameObject equipP;
    [SerializeField] private Transform spawnPos;

    //private XRInteractionManager _interactionManager;
    private string rightControllerName = "RightHand";

    //Canvas Interface
    [SerializeField] protected TMP_Text equipAmountText;

    protected virtual void Start()
    {
        equipAmount = buildingMaterial.amount;
        equipAmountText.text = (equipAmount - equipCurrentCount).ToString();

        //_interactionManager = GameObject.Find("XR Interaction Manager").GetComponent<XRInteractionManager>();
    }

    public GameObject SpawnEqip()
    {
        GameObject spawnObject = SpawnObject(equipP);
        return spawnObject;
    }

    private GameObject SpawnObject(GameObject equip)
    {
        if (equipCurrentCount < equipAmount)
        {
            GameObject spawnObject = Instantiate(equip, spawnPos.position, equip.transform.rotation);

            //change eqip amount
            equipCurrentCount += 1;
            equipAmountText.text = (equipAmount - equipCurrentCount).ToString();

            return spawnObject;
        }
        else
        {
            return null;
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (args.interactorObject is XRBaseControllerInteractor controllerInteractor && controllerInteractor != null)
        {
            var controller = controllerInteractor.xrController;

            if (controller.tag == rightControllerName)
            { 
                GameObject spawnObject = SpawnEqip();

                if(spawnObject != null)
                {
                    IXRSelectInteractable spawnInteractable = spawnObject.GetComponent<IXRSelectInteractable>();
                    IXRSelectInteractor interactor = controller.GetComponent<IXRSelectInteractor>();

                    interactionManager.SelectEnter(interactor, spawnInteractable);
                }
            }

        }
    }
}
