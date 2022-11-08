using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

/*
Test: When player hold the item on the hands, the equipments become smaller
 */

public class XREquipGrabbableHand : XRGrabInteractable
{
    [SerializeField] private float handScale;
    private Vector3 normalScale;

    private void Start()
    {
        normalScale = gameObject.transform.localScale;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (args.interactorObject is XRBaseControllerInteractor controllerInteractor && controllerInteractor != null)
        {
            var controller = controllerInteractor.xrController;

            if(controller.tag == "Hand")
            {
                gameObject.transform.localScale = new Vector3(handScale, handScale, handScale);
            }
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if (args.interactorObject is XRBaseControllerInteractor controllerInteractor && controllerInteractor != null)
        {
            var controller = controllerInteractor.xrController;

            if (controller.tag == "Hand")
            {
                gameObject.transform.localScale = normalScale;
            }
        }
    }
    
}
