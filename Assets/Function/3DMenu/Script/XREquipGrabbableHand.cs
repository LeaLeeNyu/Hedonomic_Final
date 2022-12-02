using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class XREquipGrabbableHand : XRGrabInteractable
{
    [SerializeField] private float handScale = 1f;

    private string rightControllerName = "RightHand";
    private string leftControllerName = "Hand";

    [SerializeField]private Collider objectCollider;

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

            if (controller.tag == rightControllerName || controller.tag == leftControllerName)
            {
                //if select by hand, change the scale
                gameObject.transform.localScale = new Vector3(handScale * gameObject.transform.localScale.x,
                                                              handScale * gameObject.transform.localScale.y,
                                                              handScale * gameObject.transform.localScale.z);

                if(objectCollider == null)
                {
                    Debug.Log("this grabbable does not have collider");
                }
                else
                {
                    //erase the collision between grabbable and xr origin
                    objectCollider.isTrigger = true;
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

            if (controller.tag == rightControllerName || controller.tag == leftControllerName)
            {
                gameObject.transform.localScale = new Vector3( gameObject.transform.localScale.x / handScale,
                                                               gameObject.transform.localScale.y / handScale,
                                                               gameObject.transform.localScale.z / handScale);
                if(objectCollider!= null)
                    objectCollider.isTrigger = false;
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
