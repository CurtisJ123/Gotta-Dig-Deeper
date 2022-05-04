using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public bool Shake = false;
    float magnitude = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Shake == true)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            transform.position = new Vector3(0 + (player.position.x / 10) + xOffset, player.position.y + yOffset, -10f);
        }
        else
        {
            transform.position = new Vector3(0 + (player.position.x / 10), player.position.y, -10f);
        }
        
    }
    public void CameraShake()
    {
        //var rnd = Random.Range(100f, -100f);
        //transform.position = new Vector3(0 + (player.position.x / 10) + (rnd/100), player.position.y + (rnd / 100), -10f);
        
        Debug.Log("Shake");
    }
}
