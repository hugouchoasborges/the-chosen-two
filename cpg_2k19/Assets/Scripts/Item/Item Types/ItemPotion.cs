using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPotion : Item
{
    public float healPower;

    public override void useItem(GameObject user)
    {
        //StartCoroutine(DrinkingPotion(user));
        DrinkingPotion(user);
    }

    public void DrinkingPotion(GameObject user)
    {
        Debug.Log("HORA DE BEBER");
        user.GetComponent<Player>().animator.SetBool("Potion", true);
        user.GetComponent<Player>().animator.SetBool("Drink", true);
        user.GetComponent<Player>().drinking = true;

        //yield return new WaitForSeconds(1.5f);

        //Debug.Log("HORA DE PARAR DE BEBER");
        //user.GetComponent<Player>().animator.SetBool("Potion", false);
        //user.GetComponent<Player>().animator.SetBool("Drink", false);
        //user.GetComponent<Player>().drinking = false;

        user.GetComponent<Player>().deduceDamage(-healPower);
        // Destroy the item if its health drops to 0
        --itemHealth;
        //Debug.Log("Used a potion item! Its health is now " + itemHealth);
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
