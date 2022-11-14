using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRMoveGrabbable : XREquipGrabbableHand
{
    [SerializeField] private Vector3 movePos;

    private bool moveForward = true;
    private float moveLerp = 0;

    [SerializeField] private float lerpSpeed = 0.001f;

    private Vector3 startPos;

    private bool lastSelectState;


    private void Update()
    {
        if(lastSelectState && !isSelected)
        {
            startPos = transform.position;
        }

        if (!isSelected)
        {
            if (moveForward)
            {
                moveLerp += lerpSpeed;
                MovePlatform(startPos, startPos + movePos, moveLerp);
            }
            else
            {
                moveLerp += lerpSpeed;
                MovePlatform(startPos + movePos, startPos, moveLerp);
            }
        }

        lastSelectState = isSelected;
    }

    public void MovePlatform(Vector3 startPos, Vector3 endPos, float lerp)
    {
        if (lerp < 1)
        {
            Vector3 movePos = SmoothLerp(startPos, endPos, lerp);

            gameObject.transform.localPosition = movePos;
        }
        //When the locaker get the open position
        else
        {
            moveForward = !moveForward;
            moveLerp = 0;
        }
    }
    private Vector3 SmoothLerp(Vector3 startPos, Vector3 endPos, float lerpPercent)
    {
        return new Vector3(
            Mathf.SmoothStep(startPos.x, endPos.x, lerpPercent),
            Mathf.SmoothStep(startPos.y, endPos.y, lerpPercent),
            Mathf.SmoothStep(startPos.z, endPos.z, lerpPercent));
    }
}
