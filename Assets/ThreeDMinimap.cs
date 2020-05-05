using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDMinimap : MonoBehaviour
{
    public Collectible[] Collectibles;
    public GameObject[] miniCollectibles;

    public Camera camera;

    GameObject playerRep;

    public float scale = .01f;
    public float forward = 2f;
    public float right = 2f;
    public float up = 2f;
    void Start()
    {
        for (int i = 0; i < Collectibles.Length; i++)
        {
            Collectible c = Collectibles[i];
            GameObject g = c.gameObject;
            //g.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            miniCollectibles[i] = Instantiate(g, new Vector3(1f, 1f, 1f), g.transform.rotation);
            miniCollectibles[i].transform.localScale = new Vector3(scale, scale, scale);
        }
        playerRep = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playerRep.transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Collectibles.Length; i++)
        {
            Collectible c = Collectibles[i];
            if (c != null)
            {
                GameObject g2 = c.gameObject;
                if (g2 == null)
                    break;
                GameObject g = miniCollectibles[i];
                if (g == null)
                    break;
                g.transform.position = camera.transform.position + camera.transform.up * up + camera.transform.forward * forward + camera.transform.right * right + (g2.transform.position - camera.transform.position) * scale;
                g.transform.localScale = new Vector3(scale, scale, scale);
            }
        }
        playerRep.transform.position = camera.transform.position + camera.transform.up * up + camera.transform.forward * forward + camera.transform.right * right;// + camera.transform.position * scale;
        playerRep.transform.localScale = new Vector3(scale, scale, scale);
    }
}
