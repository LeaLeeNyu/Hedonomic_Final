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
    [SerializeField] private float handScale = 0.1f;
    [SerializeField] private float normalScale = 0.5f;
    [SerializeField] private float socketScale = 1;
    private string controllerName = "RightHand";
    private string socketName = "Socket";

    private XRInteractionManager _interactionManager;

    private void Start()
    {
        _interactionManager = GameObject.FindObjectOfType<XRInteractionManager>();
    }


    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        // get the interactor that select the interactable
        if (args.interactorObject is XRBaseControllerInteractor controllerInteractor && controllerInteractor != null)
        {
            var controller = controllerInteractor.xrController;

            if(controller.tag == controllerName)
            {
                gameObject.transform.localScale = new Vector3(handScale, handScale, handScale);

                _interactionManager.SelectEnter(args.interactorObject, args.interactableObject);
            }

        }


    }
    
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if (args.interactorObject is XRBaseControllerInteractor controllerInteractor && controllerInteractor != null)
        {
            var controller = controllerInteractor.xrController;

            if (controller.tag == controllerName)
            {
                gameObject.transform.localScale = new Vector3(normalScale, normalScale, normalScale);
            }
            else if (controller.tag == socketName)
            {
                gameObject.transform.localScale = new Vector3(normalScale, normalScale, normalScale);
            }
        }
    }
    
}
