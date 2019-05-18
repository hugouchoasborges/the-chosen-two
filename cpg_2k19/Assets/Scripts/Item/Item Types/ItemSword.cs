using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSword : Item
{
    public override void useItem(GameObject user)
    {
        // Creates a new sword swing where the user is set as the attacker 
        // so he doesn't suffer damage from his own attack
        EffectSwordSwing swordSwing = GetComponent<EffectSwordSwing>();
        swordSwing = Instantiate(swordSwing, transform);
        swordSwing.setAttacker(user.GetComponent<Player>());
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
