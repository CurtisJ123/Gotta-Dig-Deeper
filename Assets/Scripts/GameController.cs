using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject dirt;
    public GameObject ore;
    public int level = 0;
    GameObject dirtblockClone;
    GameObject oreClone;
    int NumberofClones = 0;


    // Start is called before the first frame update
    void Start()
    {
        int rnd;
        for(int j = 0; j < 4; j++)
        {
            for(int i = 0; i < 15; i++)
            {
                dirtblockClone = Instantiate(dirt, new Vector3(-8.96f + (i * 1.28f), (j + 1) * -1.28f, 0f), Quaternion.identity);
                NumberofClones += 1;
                dirtblockClone.name = "DirtBlockClone" + NumberofClones;
                rnd = Random.Range(1, 5);
                if(rnd == 2)
                {
                    oreClone = Instantiate(ore, new Vector3(-8.96f + (i * 1.28f), (j + 1) * -1.28f, -1f), Quaternion.identity);
                    oreClone.transform.SetParent(dirtblockClone.transform);
                    oreClone.name = "DiamondOre";
                }
                
            }
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BreakBlock(GameObject block)
    {
        if(block.transform.childCount > 0)
        {
            if(block.gameObject.transform.GetChild(0).name == "DiamondOre")
            {
                Debug.Log("DiamondOre");
            }
        }
        
        
        Destroy(block);
    }
    public void nextLevel()
    {
        level += 1;
        int rnd;
        for(int i = 0; i < 15; i++)
        {
            
            dirtblockClone = Instantiate(dirt, new Vector3(-8.96f + (i * 1.28f), (level + 4) * -1.28f, 0f), Quaternion.identity);
            NumberofClones += 1;
            dirtblockClone.name = "DirtBlockClone" + NumberofClones;
            rnd = Random.Range(1, 5);
            if(rnd == 2)
            {
                oreClone = Instantiate(ore, new Vector3(-8.96f + (i * 1.28f), (level + 4) * -1.28f, -1f), Quaternion.identity);
                oreClone.transform.SetParent(dirtblockClone.transform);
                oreClone.name = "DiamondOre";
            }
        }
    }
}
