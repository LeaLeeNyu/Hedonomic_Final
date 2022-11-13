using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainScene : MonoBehaviour
{

    // public AudioClip SickoMode01;
    // public AudioClip SickoMode02;
    // public AudioClip SickoMode03;

    //public GameObject Player;
    public int destroyedCounter;
    //"Text" will not be an available data type until you add "using UnityEngine.UI;"
    public Text displayText;
    private Vector3 velocity;
    public GameObject myPrefab1;

    public GameObject[] materialList;

    [SerializeField] private float maxBoundary = 5.0f;
    [SerializeField] private float minBoundary = -5.0f;
    [SerializeField] private float timePeriod = 80f;

    void Update()
    {

        float xPos = Random.Range(minBoundary, maxBoundary); //x
        float yPos = Random.Range(minBoundary, maxBoundary); //z

        if (0 <= destroyedCounter && destroyedCounter <= 10)
        {
            displayText.text = "Lv. " + destroyedCounter;

            //Spawn the materials
            if (Time.frameCount % timePeriod == 0)
            {
                int randomIndex = Random.Range(0, materialList.Length);
                Instantiate(myPrefab1, new Vector3(xPos, 20, yPos), Quaternion.identity);
            }
        }
    }
}
