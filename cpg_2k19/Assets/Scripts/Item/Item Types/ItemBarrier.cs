﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBarrier : Item
{

    public override void useItem(GameObject user)
    {
        user.GetComponent<Player>().activateBarrier();
        // Destroy the item if its health drops to 0
        --itemHealth;
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
