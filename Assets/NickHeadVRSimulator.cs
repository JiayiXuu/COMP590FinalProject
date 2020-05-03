using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickHeadVRSimulator : MonoBehaviour
{
    public float translationalSpeed = 0.1f;
    public float rotationalSpeed = 2.0f;
    public bool shouldLockMouse = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = shouldLockMouse ? CursorLockMode.Locked : CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += (Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0) * translationalSpeed * new Vector3(this.transform.forward.x, 0, this.transform.forward.z) +
        (Input.GetKey(KeyCode.A) ? -1 : Input.GetKey(KeyCode.D) ? 1 : 0) * translationalSpeed * new Vector3(this.transform.right.x, 0, this.transform.right.z);

        if (Input.GetKey(KeyCode.E))
        {
            Cursor.lockState = Cursor.lockState == CursorLockMode.None ? CursorLockMode.Locked : CursorLockMode.None;
        }

        //only yaw should change for aerial view
        //only using mouse x b/c left/right makes more sense for aerial yaw than up/down
        this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y + Input.GetAxis("Mouse X") * rotationalSpeed, 0);
    }
}