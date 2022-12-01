using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformParentTrigger : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject XROrigin;
    [SerializeField] private dreamType type;

    private void OnEnable()
    {
        if (type == dreamType.Ancient)
        {
            AncientDreamTrigger.ancientDreamTrigger += ChangeTransformParent;
        }
        else if (type == dreamType.Club)
        {
            ClubDreamTrigger.clubDreamTrigger += ChangeTransformParent;
        }

    }

    private void OnDisable()
    {
        if (type == dreamType.Ancient)
        {
            AncientDreamTrigger.ancientDreamTrigger -= ChangeTransformParent;
        }
        else if (type == dreamType.Club)
        {
            ClubDreamTrigger.clubDreamTrigger -= ChangeTransformParent;
        }
    }

    private void ChangeTransformParent()
    {
        XROrigin.transform.parent = parent;
    }
}
