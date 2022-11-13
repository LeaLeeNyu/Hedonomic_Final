using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpReference;
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private GameObject checkGround;

    private Rigidbody _rigidbody;

    //private bool _isGrounded =>
    //    Physics.Raycast(new Vector2(checkGround.transform.position.x, checkGround.transform.position.y + 2f), Vector3.down, 2.1f);


    private bool isGrounded()
    {
        bool onGround = false;
        Collider[] colliders = Physics.OverlapSphere(checkGround.transform.position, 0.1f);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Ground" || collider.tag == "Material")
            {
                onGround = true;
            }
        }
        return onGround;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        jumpReference.action.performed += OnJump;
    }

    private void OnDisable()
    {
        jumpReference.action.performed -= OnJump;
    }



    void OnJump(InputAction.CallbackContext context)
    {
        bool canJump = isGrounded();
        Debug.Log(canJump);
        if (canJump)
            _rigidbody.AddForce(Vector3.up * jumpForce);
    }

    private void Update()
    {
        //if player falling down, they will come back to platform
        if (transform.position.y <= -5)
        {
            PlayerPositionData positionData = SaveSystem.LoadPosData();

            Vector3 pos = new Vector3(positionData.position[0], positionData.position[1], positionData.position[2]);
            transform.position = pos;
        }
    }

}
