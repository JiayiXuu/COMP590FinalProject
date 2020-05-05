using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; //<---------------------THIS MIGHT BREAK WHEN BUILDING :) BECAUSE THE EDITOR IS NOT AVALIABLE WHEN BUILDING :) FIND ANOTHER WAY MUH MAN

public class TreasureHunter : MonoBehaviour
{
    //  public TextMesh updateText;
    // public TextMesh itemNumerText; 
    // public TextMesh scoreText; 
    private int numItems = 0;

    private int score = 0;


    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {



    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.CompareTag("Collectible"))
        {
            if (other.GetComponent<Collectible>().available)
            {



                numItems++;

                // itemNumerText.text = "Items Collected: " + numItems;
                // score = score + other.GetComponent<Collectible>().pointVal; 
                // scoreText.text = "Score: " + score; 
                Destroy(other.GetComponent<Collider>().gameObject);
            }
        }

    }



}
