using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public GameObject referenceObject;

    public GameObject player;

    private Vector3 objeraPosition;
    private Vector3 direction;
    private float axisH;
    
    private float axisV;

    private float sensitvity = 150;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey("q")){
            axisH = 1 * sensitvity;
        } else if (Input.GetKey("e")) {
            axisH = -1 * sensitvity;
        } else {
            axisH = 0;
        }
        // if(Input.GetKey("down")){
        //     axisV = -1 * sensitvity;
        // } else if (Input.GetKey("up")) {
        //     axisV = 1 * sensitvity;
        // } else {
        //     axisV = 0;
        // }


        Rotation(referenceObject,axisH);

        this.transform.eulerAngles = new Vector3(0,referenceObject.transform.eulerAngles.y, 0);


        direction = -referenceObject.transform.forward;
        objeraPosition = referenceObject.transform.position + Vector3.Normalize(direction)*130f;
        this.transform.position = objeraPosition;
    }

    void Rotation(GameObject obj, float rotHorizontal){	

        obj.transform.Rotate (0, rotHorizontal * Time.fixedDeltaTime, 0);
        // obj.transform.Rotate (-rotVertical * Time.fixedDeltaTime, 0, 0);



        // if (Mathf.Abs (obj.transform.localRotation.x) > 0.7) {

        //     float clamped = 0.7f * Mathf.Sign (obj.transform.localRotation.x); 

        //     Quaternion adjustedRotation = new Quaternion (clamped, obj.transform.localRotation.y, obj.transform.localRotation.z, obj.transform.localRotation.w);
        //     obj.transform.localRotation = adjustedRotation;
        // }


    }
}
