using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSword : Item
{
    public GameObject swordSwing; 
    public override void useItem(GameObject user)
    {
        // Creates a new sword swing where the user is set as the attacker 
        // so he doesn't suffer damage from his own attack
        GameObject attack = Instantiate(swordSwing, user.transform.position, Quaternion.identity, transform);
        attack.GetComponent<EffectSwordSwing>().setAttacker(GetComponent<Player>());

        Debug.Log("Atacou");
        // SwordSwing(user);
        // Destroy the item if its health drops to 0
        --itemHealth;
        //Debug.Log("Used a sword item! Its health is now " + itemHealth);
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
