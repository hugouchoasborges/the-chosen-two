using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSword : Item
{
    public float swordRange;
    public override void useItem(GameObject user)
    {
        checkForCollision(user);
        if (!user.GetComponent<Player>().shieldActive)
        {
            user.GetComponent<Player>().animator.SetBool("Slash_Horizontal", true);
            user.GetComponent<Player>().animator.SetBool("Slash_Up", true);
            user.GetComponent<Player>().animator.SetBool("Slash_Down", true);
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

    public void checkForCollision(GameObject user)
    {
        
        Vector2 userForward = user.GetComponent<Player>().getFront();
        RaycastHit2D[] swordHit = Physics2D.RaycastAll(user.transform.position, userForward, 1.0f);
        Debug.DrawRay(user.transform.position, userForward, Color.green, 3.0f, true);
        Debug.Log(user.name);
        foreach (RaycastHit2D target in swordHit)
        {
            Debug.Log(target);
            Collider2D targetEval = target.collider;
            if (targetEval.name == "Player2" && user.name == "Player")
            {
                // Debug.Log("Blue hits red!");
                targetEval.GetComponent<Player>().deduceDamage(15.0f);
                // Debug.Log("HP REMAINING: " + targetEval.GetComponent<Player>().health);
            }
            else if (targetEval.name == "Player" && user.name == "Player2")
            {
                // Debug.Log("Red hits blue!");
                targetEval.GetComponent<Player>().deduceDamage(15.0f);
                // Debug.Log("HP REMAINING: " + targetEval.GetComponent<Player>().health);
            }
        }
    }

        // Start is called before the first frame update
    void Start()
    {
        swordRange = 1.25f;    
    }

    // Update is called once per frame
    void Update()
    {

    }
}
