using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBarrier : Item
{

    public override void useItem(GameObject user)
    {
        // Destroy the item if its health drops to 0
        --itemHealth;
        //Debug.Log("Used a barrier item! Its health is now " + itemHealth);
    }

    public override void dropItem ()
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
