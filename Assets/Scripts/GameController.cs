using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    public GameObject blockPrefab;
    public GameObject orePrefab;
    public GameObject blockBackgroundPrefab;
    
    public int layer = 0;
    GameObject blockClone;
    GameObject oreClone;
    GameObject blockBackgroundClone;
    int NumberofClones = 0;
    
    public int Money;
    public TMP_Text moneyCounter;

    public int Level = 0;
    int blockLevel = 0;

    public List<GameObject> valuables = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        int rnd;
        for(int j = 0; j < 4; j++)
        {
            for(int i = 0; i < 15; i++)
            {
                blockClone = Instantiate(blockPrefab, new Vector3(-8.96f + (i * 1.28f), (j + 1) * -1.28f, 0f), Quaternion.identity);
                blockBackgroundClone = Instantiate(blockBackgroundPrefab, new Vector3(-8.96f + (i * 1.28f), (j + 1) * -1.28f, 1f), Quaternion.identity);
                blockBackgroundClone.name = "BlockBackgroundClone" + NumberofClones;
                NumberofClones += 1;
                blockClone.name = "BlockClone" + NumberofClones;
                blockClone.GetComponent<BlockController>().ChangeSrite(Level);
                rnd = Random.Range(1, 5);
                if(rnd == 2)
                {
                    oreClone = Instantiate(orePrefab, new Vector3(-8.96f + (i * 1.28f), (j + 1) * -1.28f, -1f), Quaternion.identity);
                    oreClone.transform.SetParent(blockClone.transform);
                    oreClone.name = "DiamondOre";
                }
            }
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if((layer - 1) % 10 == 0)
        {
            Level = layer / 10;
        }
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
    public void nextLayer()
    {
        layer += 1;
        int rnd;
        
        for(int i = 0; i < 15; i++)
        {
            if((layer + 4) % 10 == 0)
            {
                blockLevel = (layer + 4) / 10;
            }
            blockClone = Instantiate(blockPrefab, new Vector3(-8.96f + (i * 1.28f), (layer + 4) * -1.28f, 0f), Quaternion.identity);
            blockBackgroundClone = Instantiate(blockBackgroundPrefab, new Vector3(-8.96f + (i * 1.28f), (layer + 4) * -1.28f, 1f), Quaternion.identity);
            blockBackgroundClone.name = "BlockBackgroundClone" + NumberofClones;
            NumberofClones += 1;
            blockClone.name = "BlockClone" + NumberofClones;
            blockClone.GetComponent<BlockController>().ChangeSrite(blockLevel);
            rnd = Random.Range(1, 5);
            if(rnd == 2)
            {
                oreClone = Instantiate(orePrefab, new Vector3(-8.96f + (i * 1.28f), (layer + 4) * -1.28f, -1f), Quaternion.identity);
                oreClone.transform.SetParent(blockClone.transform);
                oreClone.name = "DiamondOre";
            }
        }
    }
}
