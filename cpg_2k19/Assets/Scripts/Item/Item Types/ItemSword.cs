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
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            if (audioSource)
            {
                audioSource.Play();
            }

            user.GetComponent<Player>().animator.SetBool("Slash_Horizontal", true);
            user.GetComponent<Player>().animator.SetBool("Slash_Up", true);
            user.GetComponent<Player>().animator.SetBool("Slash_Down", true);
            // SwordSwing(user);
            // Destroy the item if its health drops to 0
            --itemHealth;
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
        foreach (RaycastHit2D target in swordHit)
        {
            Collider2D targetEval = target.collider;
            if (targetEval.name == "Player2" && user.name == "Player")
            {
                targetEval.GetComponent<Player>().deduceDamage(15.0f, userForward);
            }
            else if (targetEval.name == "Player" && user.name == "Player2")
            {
                targetEval.GetComponent<Player>().deduceDamage(15.0f, userForward);
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
