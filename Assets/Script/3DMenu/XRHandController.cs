using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;


public enum HandType
{
    Left,
    Right,
}

public class XRHandController : MonoBehaviour
{
    #region HandInitialParameter
    public HandType handType;
    //Stores what kind of characteristics we¡¯re looking for with our Input Device when we search for it later
    [HideInInspector] public InputDeviceCharacteristics inputDeviceCharacteristics;
    //Stores the InputDevice that we¡¯re Targeting once we find it in InitializeHand()
    private InputDevice _targetDevice;
    private Animator _handAnimator;
    //Hand Model Name String
    [SerializeField] private string leftHandName;
    [SerializeField] private string rightHandName;
    #endregion

    //Watch UI 
    private bool watchState = false;
    [SerializeField] private GameObject watchCanvas;


    private void InitializeHand()
    {
        GameObject spawnedHand;

        if (handType == HandType.Left)
        {
            inputDeviceCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
            spawnedHand = GameObject.Find(leftHandName + "(Clone)");
        }
        else
        {
            inputDeviceCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
            spawnedHand = GameObject.Find(rightHandName+ "(Clone)");
        }


        List<InputDevice> devices = new List<InputDevice>();
        //Call InputDevices to see if it can find any devices with the characteristics we¡¯re looking for
        InputDevices.GetDevicesWithCharacteristics(inputDeviceCharacteristics, devices);

        //Our hands might not be active and so they will not be generated from the search.
        //We check if any devices are found here to avoid errors.
        if (devices.Count > 0)
        {

            _targetDevice = devices[0];
            _handAnimator = spawnedHand.GetComponent<Animator>();
        }
    }

    private void Start()
    {
        InitializeHand();
    }

    private void Update()
    {
        if (!_targetDevice.isValid)
        {
            InitializeHand();
        }
        else
        {
            JoystickPressed();
        }
    }

    //Watch State
    void JoystickPressed()
    {
        _targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool isPressed);
        if (isPressed)
        {
            watchState = true;
        }
        else
        {
            watchState = false;
        }
        watchCanvas.SetActive(watchState);
    }

    void JoyStickValue()
    {
        _targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 JoystickValue);
        _targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool trigger);
    }

}
