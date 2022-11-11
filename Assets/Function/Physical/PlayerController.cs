using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpReference;
    [SerializeField] private float jumpForce = 100f;

    private Rigidbody _rigidbody;

    private bool _isGrounded =>
        Physics.Raycast(new Vector2(transform.position.x, transform.position.y + 0.5f), Vector3.down, 0.5f);



    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        jumpReference.action.performed += OnJump;
        Debug.Log(_isGrounded);
    }

    private void OnDisable()
    {
        jumpReference.action.performed -= OnJump;
    }



    void OnJump(InputAction.CallbackContext context)
    {
        _rigidbody.AddForce(Vector3.up * jumpForce);

    }

    private void Update()
    {
        if (transform.position.y <= -5)
        {
            PlayerPositionData positionData = SaveSystem.LoadPosData();

            Vector3 pos = new Vector3(positionData.position[0], positionData.position[1], positionData.position[2]);
            transform.position = pos;
        }
    }
}
