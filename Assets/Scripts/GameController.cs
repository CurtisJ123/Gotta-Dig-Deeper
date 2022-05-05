using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    public GameObject dirt;
    public GameObject ore;
    public int level = 0;
    GameObject dirtblockClone;
    GameObject oreClone;
    int NumberofClones = 0;
    public List<GameObject> valuables = new List<GameObject>();
    public int Money;
    public TMP_Text moneyCounter;

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
        valuables.Add(block);
        block.gameObject.SetActive(false);
        if(block.transform.childCount > 0)
        {
            if(block.gameObject.transform.GetChild(0).name == "DiamondOre")
            {
                Debug.Log("DiamondOre");
                valuables.Add(block.gameObject.transform.GetChild(0).gameObject);
            }
        }
    }
    public void EndDay()
    {
        foreach(GameObject o in valuables)
        {
            if(o.name == "DiamondOre")
            {
                Debug.Log("Sold Diamond Ore");
                Money += 10;
            }
            if(o.name.Contains("DirtBlockClone") == true)
            {
                Debug.Log("Sold Dirt");
                Money += 1;
            }
            Destroy(o);
        }
        valuables.Clear();
        moneyCounter.text = "Money: " + Money;
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
