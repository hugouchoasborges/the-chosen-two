using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSword : Item
{
    public int itemHealth;

    public override void useItem()
    {
        // Destroy the item if its health drops to 0
        if (--itemHealth <= 0)
        {
            Destroy(gameObject, 0.0f);
        }
    }

    public override void dropItem()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
