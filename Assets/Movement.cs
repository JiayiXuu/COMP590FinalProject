using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float translationalSpeed = 1.0f;
    private float rotationalSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void Update()
    {
        this.transform.position += (Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0) * translationalSpeed * new Vector3(this.transform.forward.x, 0, this.transform.forward.z) +
        (Input.GetKey(KeyCode.A) ? -1 : Input.GetKey(KeyCode.D) ? 1 : 0) * translationalSpeed * new Vector3(this.transform.right.x, 0, this.transform.right.z);

        this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y + Input.GetAxis("Mouse X") * rotationalSpeed, 0);
    }
}
