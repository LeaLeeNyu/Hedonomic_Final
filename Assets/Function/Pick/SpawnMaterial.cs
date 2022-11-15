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
public class SpawnMaterial : MonoBehaviour
{

    //public GameObject Player;
    public int destroyedCounter;
    public Text displayText;
    private Vector3 velocity;
    public GameObject myPrefab1;

    public GameObject[] materialList;

    [SerializeField] private float maxBoundary = 5.0f;
    [SerializeField] private float minBoundary = -5.0f;
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
            float xPos = Random.Range(minBoundary, maxBoundary); //x
            float yPos = Random.Range(minBoundary, maxBoundary); //z

            //Spawn the materials
            if (Time.frameCount % timePeriod == 0)
            {
                int randomIndex = Random.Range(0, materialList.Length);
                Instantiate(materialList[randomIndex], new Vector3(xPos, 20, yPos), Quaternion.identity);
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
