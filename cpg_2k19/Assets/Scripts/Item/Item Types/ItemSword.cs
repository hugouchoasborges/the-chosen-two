using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSword : Item
{
    public override void useItem(GameObject user)
    {
        if (!user.GetComponent<Player>().shieldActive)
        {
            user.GetComponent<Player>().animator.SetBool("Slash_Horizontal", true);
            user.GetComponent<Player>().animator.SetBool("Slash_Up", true);
            user.GetComponent<Player>().animator.SetBool("Slash_Down", true);
            Debug.Log("Atacou");
            // SwordSwing(user);
            // Destroy the item if its health drops to 0
            --itemHealth;
            //Debug.Log("Used a sword item! Its health is now " + itemHealth);
        }
        else
            return; 
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
