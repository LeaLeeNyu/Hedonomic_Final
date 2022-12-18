using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpReference;
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private GameObject checkGround;
    [SerializeField] private float yDistance;

    private Rigidbody _rigidbody;

    //private bool _isGrounded =>
    //    Physics.Raycast(new Vector2(checkGround.transform.position.x, checkGround.transform.position.y + 2f), Vector3.down, 2.1f);


    private bool isGrounded()
    {
        bool onGround = false;
        Collider[] colliders = Physics.OverlapSphere(checkGround.transform.position, 0.1f);
        foreach (Collider collider in colliders)
        {
            //building material layer index 7, ground layer index 8
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
        //Debug.Log(canJump);
        if (canJump)
            _rigidbody.AddForce(Vector3.up * jumpForce);
    }

    private void Update()
    {
        //if player falling down, they will come back to platform
        if (transform.position.y <= yDistance && _rigidbody.velocity.y< 0f)
        {
            PlayerPositionData positionData = SaveSystem.LoadPosData();

            Vector3 pos = new Vector3(positionData.position[0], positionData.position[1], positionData.position[2]);
            transform.position = pos;
        }
    }

    //Portal 
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Warp_Sphere")
        {
            SceneManager.LoadScene("Chengbo-PickUp-Final");
        }

        if (other.gameObject.name == "Warp_Sphere2")
        {
            SceneManager.LoadScene("Chengbo-Base");
        }

        //Night scene
        if (other.gameObject.name == "Ancient_Sphere")
        {
            SceneManager.LoadScene("Yuan-Ancient");
        }
        if (other.gameObject.name == "House_Sphere")
        {
            SceneManager.LoadScene("Chengbo-HorrorMansion");
        }
        if (other.gameObject.name == "Club_Sphere")
        {
            SceneManager.LoadScene("Chengbo-DanceClub");
        }

        //pickup to night
        if (other.gameObject.name == "Warp_Sphere_Night")
        {
            SceneManager.LoadScene("Chengbo-Base-Night");
        }

    }

    public void LoadLevels(string levelName)
    {
        StartCoroutine(LoadAsyn(levelName));
    }

    IEnumerator LoadAsyn(string levelName)
    {       
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/ 0.9f);
            yield return null;
        }
    }
}
