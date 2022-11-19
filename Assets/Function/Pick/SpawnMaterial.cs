using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * To spawn the material in the picking scene
 */
public class SpawnMaterial:MonoBehaviour
{

    //public GameObject Player;
    public int destroyedCounter;
    public Text displayText;
    private Vector3 velocity;
    public GameObject[] materialList;

    // [SerializeField] private float maxBoundary = 60.0f;
    // [SerializeField] private float minBoundary = -3.0f;
    [SerializeField] private float timePeriod = 80f;

    private bool startSpawn = false;

    private void OnEnable()
    {
        TimeLimitation.startTime += StartSpawnMaterial;
        TimeLimitation.endTime += EndSpawnMaterial;
    }

    private void OnDisable()
    {
        TimeLimitation.startTime -= StartSpawnMaterial;
        TimeLimitation.endTime -= EndSpawnMaterial;
    }


    void Update()
    {
        if (startSpawn)
        {
            // float xPos = Random.Range(minBoundary, maxBoundary); //x
            // float yPos = Random.Range(minBoundary, maxBoundary); //z
            int num1 = Random.Range(-3, 60); //x
            int num2 = Random.Range(-3, 60); //z

            //Spawn the materials
            if (Time.frameCount % timePeriod == 0)
            {
                int randomIndex = Random.Range(0, materialList.Length);
                Instantiate(materialList[randomIndex], new Vector3(num1, 20, num2), Quaternion.identity);
            }
        }
    }

    void StartSpawnMaterial()
    {
        startSpawn = true;
    }

    void EndSpawnMaterial()
    {
        startSpawn = false;
    }
}
