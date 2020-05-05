using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : MonoBehaviour
{

    int num;
    private GameObject[] crytals;
    private GameObject[] icons;
    public GameObject treasure;
    GameObject crystal;
    public Camera minimap;
    
    public GameObject arrow;
    private Vector3 reference;

    // Start is called before the first frame update
    void Start()
    {
        if (crytals == null){
            crytals = GameObject.FindGameObjectsWithTag("Collectible");
        }
        num = crytals.Length;
        Debug.Log(num);
        reference = minimap.WorldToViewportPoint(arrow.transform.position);

    }

    // Update is called once per frame
    
    void Update()
    {
        for(int i = 0; i<6;i++)
        {
            if (i<=4){
                crystal = crytals[i];
            }else{
                crystal = treasure;
            }
            if(crystal != null){
                Transform icon = crystal.transform.Find("Icon_treasure");
                if (icon != null){
                        Vector3 icon_in_viewport= minimap.WorldToViewportPoint(crystal.transform.position);

                        float distance = Vector2.Distance(new Vector2(icon_in_viewport.x,icon_in_viewport.y),new Vector2(reference.x,reference.y));
                    if(distance>=0.43f){
                        Vector3 direction = new Vector3(icon_in_viewport.x,icon_in_viewport.y,icon_in_viewport.z) - new Vector3(reference.x,reference.y,icon_in_viewport.z);
                        Vector3 clamped = reference + Vector3.Normalize(direction)*0.4f;
                        icon.position = minimap.ViewportToWorldPoint(clamped);
                    }
                    else{
                        icon.position = new Vector3(crystal.transform.position.x,minimap.transform.position.y - 6,crystal.transform.position.z);
                    }


                    icon.eulerAngles = new Vector3(0,this.transform.eulerAngles.y, 0);
                    
                    if (this.transform.position.y - crystal.transform.position.y < -0.2 ){
                        icon.Find("up").gameObject.SetActive(true);
                        icon.Find("down").gameObject.SetActive(false);
                    } else if (this.transform.position.y - crystal.transform.position.y > 0.4){
                        icon.Find("up").gameObject.SetActive(false);
                        icon.Find("down").gameObject.SetActive(true);
                    } else {
                        icon.Find("up").gameObject.SetActive(false);
                        icon.Find("down").gameObject.SetActive(false);
                    }
                }
            }
        }   
    }
}
