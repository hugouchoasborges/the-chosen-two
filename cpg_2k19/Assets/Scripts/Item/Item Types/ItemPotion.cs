using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPotion : Item
{
    public float healPower;

    public override void useItem(GameObject user)
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource)
        {
            audioSource.gameObject.SetActive(true);
            audioSource.Play();
        }
        //StartCoroutine(DrinkingPotion(user));
        DrinkingPotion(user);
    }

    public void DrinkingPotion(GameObject user)
    {
        user.GetComponent<Player>().animator.SetBool("Potion", true);
        user.GetComponent<Player>().animator.SetBool("Drink", true);
        user.GetComponent<Player>().drinking = true;


        user.GetComponent<Player>().deduceDamage(-healPower);
        // Destroy the item if its health drops to 0
        --itemHealth;
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
