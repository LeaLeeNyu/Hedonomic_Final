using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;

public class eliminationRect : MonoBehaviour
{
    // public int a = 0;
    // public int b = 0;
    // public int c = 0;
    //private Vector3 velocity;
    //public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      // Vector3 player_postion = Player.transform.position;
      // float x = player_postion.x;
      // float y = player_postion.y;
      // float z = player_postion.z;
      //
      // if(x > 6 && z > 18){
      //   SceneManager.LoadScene("Shopping");
      // }

    }

    public mainScene mainSceneObject;
    //public mainScene testingPublicVaribale;

    void OnCollisionEnter(Collision other)
    {
      if (mainSceneObject.destroyedCounter >= 0 && mainSceneObject.destroyedCounter < 10)
      {
        if (other.gameObject.name == "Kirby(Clone)")
        {
            Destroy(other.collider.gameObject);
            mainSceneObject.destroyedCounter = mainSceneObject.destroyedCounter+1;
            //FindObjectOfType<AudioManager>().Play("brilliant");
        }
      }
        //Debug.Log("Rect has been hit by " + other.gameObject.name);

        //If you want to specific which type of object
        //You can specify by checking the colliding object's name
        //if (other.gameObject.name == "SphereModel(Clone)")
        if (other.gameObject.name == "Wool")
        {
            //Destroy(other.collider.gameObject);
            // mainSceneObject.destroyedCounter = mainSceneObject.destroyedCounter+100;
            //FindObjectOfType<AudioManager>().Stop("SickoMode01");
            //FindObjectOfType<AudioManager>().Stop("SickoMode03");
            SceneManager.LoadScene("Scene II");
        }

        // if(other.gameObject.name == "wall01")
        // {
        //     if (a % 2 == 0){
        //       FindObjectOfType<AudioManager>().Play("SickoMode01");
        //       a++;
        //     }
        //     else{
        //       //Destroy(other.collider.gameObject);
        //       FindObjectOfType<AudioManager>().Stop("SickoMode01");
        //       a++;
        //     }
            // AudioSource.PlayClipAtPoint(SickoMode02, transform.position, 100F);
            // FindObjectOfType<AudioManager>().Stop("SickoMode03");
            // FindObjectOfType<AudioManager>().Stop("SickoMode02");
            // FindObjectOfType<AudioManager>().Play("SickoMode01");
          // }

          // if(other.gameObject.name == "wall02")
          // {
          //     if (b % 2 == 0){
          //       FindObjectOfType<AudioManager>().Play("SickoMode02");
          //       b++;
          //     }
          //     else{
          //       //Destroy(other.collider.gameObject);
          //       FindObjectOfType<AudioManager>().Stop("SickoMode02");
          //       b++;
          //     }
              // AudioSource.PlayClipAtPoint(SickoMode02, transform.position, 100F);
              // FindObjectOfType<AudioManager>().Stop("SickoMode03");
              // FindObjectOfType<AudioManager>().Stop("SickoMode02");
              // FindObjectOfType<AudioManager>().Play("SickoMode01");
            // }
            //
            // if(other.gameObject.name == "wall03")
            // {
            //     if (c % 2 == 0){
            //       FindObjectOfType<AudioManager>().Play("SickoMode03");
            //       c++;
            //     }
            //     else{
            //       //Destroy(other.collider.gameObject);
            //       FindObjectOfType<AudioManager>().Stop("SickoMode03");
            //       c++;
            //     }
                // AudioSource.PlayClipAtPoint(SickoMode02, transform.position, 100F);
                // FindObjectOfType<AudioManager>().Stop("SickoMode03");
                // FindObjectOfType<AudioManager>().Stop("SickoMode02");
                // FindObjectOfType<AudioManager>().Play("SickoMode01");
              }

        }
