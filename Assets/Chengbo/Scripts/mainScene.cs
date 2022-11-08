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

    //public GameObject myPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(destroyedCounter + " gameobjects have been destroyed");
        //Vector3 player_postion = Player.transform.position;
        //float x = player_postion.x;
        //float y = player_postion.y;
        //float z = player_postion.z;

        int num1 = Random.Range(-5, 5); //x
        int num2 = Random.Range(-5, 5); //z

        if (0 <= destroyedCounter && destroyedCounter <= 10)
        {
          //displayText.text = "Lv. " + destroyedCounter;
          //Banana
          // if (Time.frameCount % 95 == 0)
          // {
          //     //Debug.Log("Ding!");
          //     Instantiate(myPrefab1, new Vector3(num1, 20, num2), Quaternion.identity);
          // }
          //Cheese
          if (Time.frameCount % 80 == 0)
          {
              //Debug.Log("Ding!");
              Instantiate(myPrefab1, new Vector3(num1, 20, num2), Quaternion.identity);
          }
          //Hamburger
          // if (Time.frameCount % 100 == 0)
          // {
          //     //Debug.Log("Ding!");
          //     Instantiate(myPrefab3, new Vector3(num1, 20, num2), Quaternion.identity);
          // }
          //Watermelon
          // if (Time.frameCount % 96 == 0)
          // {
          //     //Debug.Log("Ding!");
          //     Instantiate(myPrefab4, new Vector3(num1, 20, num2), Quaternion.identity);
          // }
          //Hotdog
          // if (Time.frameCount % 90 == 0)
          // {
          //     //Debug.Log("Ding!");
          //     Instantiate(myPrefab5, new Vector3(num1, 20, num2), Quaternion.identity);
          // }
        }
        // if(z > 18){
        //   if(x > 3){
        //     FindObjectOfType<AudioManager>().Stop("SickoMode01");
        //     FindObjectOfType<AudioManager>().Stop("SickoMode03");
        //     // AudioSource.PlayClipAtPoint(SickoMode02, transform.position, 100F);
        //     FindObjectOfType<AudioManager>().Play("SickoMode02");
        //   }
        // }
        // if(z > 16 && z < 18){
        //   if(x > 0 && x < 3){
        //     FindObjectOfType<AudioManager>().Stop("SickoMode01");
        //     FindObjectOfType<AudioManager>().Stop("SickoMode02");
        //     // AudioSource.PlayClipAtPoint(SickoMode02, transform.position, 100F);
        //     FindObjectOfType<AudioManager>().Play("SickoMode03");
        //   }
        // }
        //displayText.text = "$ "+destroyedCounter;

        //You can use modulo as a counter when used in conjunction with frameCount
        //Debug.Log(Time.frameCount%120);

        // if (Time.frameCount % 10 == 0)
        // {
        //     Debug.Log("Ding!");
        //     Instantiate(myPrefab, new Vector3(0, 5, 0), Quaternion.identity);
        // }
    }
}
