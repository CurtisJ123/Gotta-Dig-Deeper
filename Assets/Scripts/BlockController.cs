using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite dirtSprite;
    public Sprite rockSprite;
    SpriteRenderer spriteRenderer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeSrite(int level){
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log(level);
        if(level < 2)
        {
            spriteRenderer.sprite = dirtSprite;
        }else if(level >= 2)
        {
            spriteRenderer.sprite = rockSprite;
        }
        else
        {
            spriteRenderer.sprite = rockSprite;
        }
        Debug.Log(spriteRenderer.sprite.name);
    }
}
