using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class TreasureHunterWithUI : MonoBehaviour
{
    public GameObject progress;
    public GameObject score;
    public GameObject youwin;
    public GameObject time;

    //public GameObject opening;
    //public Button yourButton;

    private float timeElapsed;

    private TextMeshProUGUI pText;
    private TextMeshProUGUI sText;
    private TextMeshProUGUI wText;
    private TextMeshProUGUI tText;
    private int numItems = 0;



    public GameObject treasure;
    private int totalScore = 0;


    void Start()
    {

        youwin.SetActive(false);
        time.SetActive(false);

        pText = progress.GetComponent<TextMeshProUGUI>();
        sText = score.GetComponent<TextMeshProUGUI>();
        wText = youwin.GetComponent<TextMeshProUGUI>();
        tText = time.GetComponent<TextMeshProUGUI>();


        progress.SetActive(true);
        score.SetActive(true);
        pText.text = "Find the five treasures indicated on the map!";
        sText.text = "Your score: " + totalScore;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        numItems = 0;
        treasure.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (numItems >= 5)
        {
            treasure.SetActive(true);
            pText.text = "The hidden treasure has appeared! Find it to win the game!";
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.CompareTag("Collectible"))
        {
            if (other.GetComponent<Collectible>().available)
            {



                numItems++;
                totalScore += 15;
                sText.text = "Your score: " + totalScore;

                if (other.name == "treasure")
                {
                    time.SetActive(true);
                    timeElapsed = Time.time;
                    youwin.SetActive(true);
                    tText.text = "Total time: " + timeElapsed + "s";

                }
                Destroy(other.GetComponent<Collider>().gameObject);
            }



        }

    }


}
