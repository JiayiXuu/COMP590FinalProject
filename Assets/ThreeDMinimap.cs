using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDMinimap : MonoBehaviour
{
    public Collectible[] Collectibles;
    public GameObject[] miniCollectibles;

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
            GameObject g2 = c.gameObject;
            GameObject g = miniCollectibles[i];
            g.transform.position = Camera.main.transform.position + Camera.main.transform.up * up + Camera.main.transform.forward * forward + Camera.main.transform.right * right + g2.transform.position * scale;
        }
        playerRep.transform.position = Camera.main.transform.position + Camera.main.transform.up * up + Camera.main.transform.forward * forward + Camera.main.transform.right * right + Camera.main.transform.position * scale;
    }
}
