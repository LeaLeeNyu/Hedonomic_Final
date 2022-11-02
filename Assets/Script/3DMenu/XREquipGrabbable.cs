using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XREquipGrabbable : XRGrabInteractable
{
    [SerializeField] private EquipController equipController;

    [Obsolete]
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);

        if (interactor.CompareTag("WatchSocket"))
        {
            //Debug.Log("Select by hand!");
            //equipController.ShowWatchInfo();
            //Set the parent for equip, so it could disappare with watch canvas?
            gameObject.transform.parent = interactor.transform;
        }

    }

    //protected override void OnSelectEntered(SelectEnterEventArgs args)
    //{
    //    base.OnSelectEntered(args);

    //    if (args.interactorObject is XRBaseControllerInteractor controllerInteractor && controllerInteractor != null)
    //    {
    //        var controller = controllerInteractor.xrController;

    //        if (controller.CompareTag("Hand"))
    //        {
    //            //Debug.Log("Select by hand!");
    //            equipController.ShowWatchInfo();
    //        }
    //    }


    //}

    [Obsolete]
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        if (interactor.CompareTag("WatchSocket"))
        {
            //Debug.Log("Select by hand!");
            //equipController.HideWatchInfo();
            gameObject.transform.parent = null;
        }
    }
}
