using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

    public class ContinousMovement : MonoBehaviour
{
    [SerializeField] private ActionBasedContinuousMoveProvider _continuousMoveProviderLeft;
    [SerializeField] private GameObject continuousMoveProviderLeft;

    protected void OnEnable()
    {
        XRHandController.watchOn += WatchTurnOn;
        XRHandController.watchOff += WatchTurnOff;
    }

    protected void OnDisable()
    {
        XRHandController.watchOn -= WatchTurnOn;
        XRHandController.watchOff -= WatchTurnOff;
    }



    void WatchTurnOn()
    {
        //_continuousMoveProviderLeft.enabled = false;
        continuousMoveProviderLeft.SetActive(false);
    }

    void WatchTurnOff()
    {
        // _continuousMoveProviderLeft.enabled = true;
        continuousMoveProviderLeft.SetActive(true);
    }

}





