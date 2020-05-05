using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDMinimap : MonoBehaviour
{
    public Collectible[] Collectibles;
    public GameObject[] miniCollectibles;

    public Camera camera;

    public GameObject player;

    GameObject playerRep;

    public float scale = .01f;
    public float scaleSize = .01f;
    public float forward = 2f;
    public float right = 2f;
    public float up = 2f;
    void Start()
    {
        for (int i = 0; i < Collectibles.Length - 1; i++)
        {
            Collectible c = Collectibles[i];
            GameObject g = c.gameObject;
            //g.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            miniCollectibles[i] = Instantiate(g, new Vector3(1f, 1f, 1f), g.transform.rotation);
            miniCollectibles[i].transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
            miniCollectibles[i].GetComponent<Collectible>().available = false;
            Destroy(miniCollectibles[i].GetComponent<Collider>());
        }
        playerRep = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playerRep.transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
        Destroy(playerRep.GetComponent<Collider>());
    }
    float angleBetweenVectors(Vector3 A, Vector3 B)
    {
        Vector3 a = new Vector3(A.x, 0, A.z);
        Vector3 b = new Vector3(B.x, 0, B.z);
        return Mathf.Acos(Vector3.Dot(a.normalized, b.normalized)) / Mathf.Deg2Rad;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 offset = camera.transform.position + (camera.transform.up * up) + ((camera.transform.forward) * forward) + (camera.transform.right * right);
        for (int i = 0; i < Collectibles.Length - 1; i++)
        {
            Collectible c = Collectibles[i];
            if (c != null)
            {
                GameObject g2 = c.gameObject;
                if (g2 != null)
                {
                    GameObject g = miniCollectibles[i];
                    if (g != null)
                    {
                        g.transform.position = offset + (g2.transform.position - player.transform.position) * scale;
                        g.transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
                    }
                }
            }
        }
        playerRep.transform.position = offset; //+ camera.transform.position * scale;
        playerRep.transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
    }
}
