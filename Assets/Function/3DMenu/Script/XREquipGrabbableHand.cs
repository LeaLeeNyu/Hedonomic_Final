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

    private string controllerName = "RightHand";

    private BoxCollider boxCollider;

    private XRInteractionManager _interactionManager;

    private void Start()
    {
        _interactionManager = GameObject.FindObjectOfType<XRInteractionManager>();
        boxCollider = GetComponent<BoxCollider>();
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
                gameObject.transform.localScale = new Vector3(handScale * gameObject.transform.localScale.x,
                                                              handScale * gameObject.transform.localScale.y,
                                                              handScale * gameObject.transform.localScale.z);

                _interactionManager.SelectEnter(args.interactorObject, args.interactableObject);

                //Set the collider to trigger, therefore it doesn't have collision with player's collider
                boxCollider.isTrigger = true;
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
                gameObject.transform.localScale = new Vector3( gameObject.transform.localScale.x / handScale,
                                                               gameObject.transform.localScale.y / handScale,
                                                               gameObject.transform.localScale.z / handScale);

                boxCollider.isTrigger = false;
            }
        }
    }
    
}
