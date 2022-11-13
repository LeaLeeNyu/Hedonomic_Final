using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

/*
 When player hold the item on the hands, the equipments become smaller
 */

public class XREquipGrabbableHand : XRGrabInteractable
{
    [SerializeField] private float handScale = 0.1f;

    private string rightControllerName = "RightHand";

    [SerializeField]private BoxCollider boxCollider;

    private bool hasbeenSelect = false;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        //

        // get the interactor that select the interactable
        if (args.interactorObject is XRBaseControllerInteractor controllerInteractor && controllerInteractor != null)
        {
            var controller = controllerInteractor.xrController;

            //if the grabbable has been select, the it turn to offset select mode
            if(hasbeenSelect)
                MatchAttachPoint(controllerInteractor);

            if (controller.tag == rightControllerName)
            {
                //if select by hand, change the scale
                gameObject.transform.localScale = new Vector3(handScale * gameObject.transform.localScale.x,
                                                              handScale * gameObject.transform.localScale.y,
                                                              handScale * gameObject.transform.localScale.z);

                if(boxCollider == null)
                {
                    Debug.Log("this grabbable does not have collider");
                }
                else
                {
                    //erase the collision between grabbable and xr origin
                    boxCollider.isTrigger = true;
                }
                
            }

        }

    }
    
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if (args.interactorObject is XRBaseControllerInteractor controllerInteractor && controllerInteractor != null)
        {
            var controller = controllerInteractor.xrController;

            if (controller.tag == rightControllerName)
            {
                gameObject.transform.localScale = new Vector3( gameObject.transform.localScale.x / handScale,
                                                               gameObject.transform.localScale.y / handScale,
                                                               gameObject.transform.localScale.z / handScale);

                boxCollider.isTrigger = false;
            }
        }

        hasbeenSelect = true;
    }

    private void MatchAttachPoint(XRBaseInteractor interactor)
    {
        bool isDirect = interactor is XRDirectInteractor;
        attachTransform.position = isDirect ? interactor.attachTransform.position : attachTransform.position;
        attachTransform.rotation = isDirect ? interactor.attachTransform.rotation : attachTransform.rotation;
    }

}
