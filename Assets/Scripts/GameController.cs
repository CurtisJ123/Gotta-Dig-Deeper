using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject dirt;
    public int level = 0;
    GameObject dirtblockClone;
    int NumberofClones = 0;


    // Start is called before the first frame update
    void Start()
    {
        
        for(int j = 0; j < 3; j++)
        {
            for(int i = 0; i < 15; i++)
            {
                dirtblockClone = Instantiate(dirt, new Vector3(-8.96f + (i * 1.28f), (j + 1) * -1.28f, 0f), Quaternion.identity);
                NumberofClones += 1;
                dirtblockClone.name = "DirtBlockClone" + NumberofClones;
            }
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BreakBlock(GameObject block)
    {
        Destroy(block);
    }
    public void nextLevel()
    {
        level += 1;
        for(int i = 0; i < 15; i++)
        {
            
            dirtblockClone = Instantiate(dirt, new Vector3(-8.96f + (i * 1.28f), (level + 3) * -1.28f, 0f), Quaternion.identity);
            NumberofClones += 1;
            dirtblockClone.name = "DirtBlockClone" + NumberofClones;
        }
    }
}
