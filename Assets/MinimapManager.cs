using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : MonoBehaviour
{

    public GameObject[] crytals;
    private GameObject[] icons;


    
    private Vector3 reference;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        foreach(GameObject crystal in crytals)
        {
            if(crystal != null){
                Transform icon = crystal.transform.Find("Icon_treasure");


                    icon.eulerAngles = new Vector3(0,this.transform.eulerAngles.y, 0);

                    if (this.transform.position.y - crystal.transform.position.y < -0.2 ){
                        icon.Find("Sphere/up").gameObject.SetActive(false);
                        icon.Find("Sphere/down").gameObject.SetActive(true);
                    } else if (this.transform.position.y - icon.position.y > 0.2){
                        icon.Find("Sphere/up").gameObject.SetActive(true);
                        icon.Find("Sphere/down").gameObject.SetActive(false);
                    } else {
                        icon.Find("Sphere/up").gameObject.SetActive(false);
                        icon.Find("Sphere/down").gameObject.SetActive(false);
                    }
                }
        }   
    }


}
