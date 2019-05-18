using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemHealth;

    public virtual void useItem ()
    {
        
    }

    public virtual void dropItem ()
    {

    }

    public void getAbsorbed()
    {
        // Destroys the countdown for the item's disappearance
        Destroy(GetComponent<ItemOnMap>());
        Destroy(GetComponent<BoxCollider2D>());
        // Disables the sprite renderer for while the item remains in the inventory and it's not dropped again
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject collisor = other.gameObject;
        if (collisor.tag == "Player")
        {
            Debug.Log("Item.cs trigger");
        }
    }

    //void OnTriggerEnter2D (Collision2D collision)
    //{
        
    //    if (collision.gameObject.tag == "Item")
    //    {
    //        // Adds this item to the inventory (made to preserve the item health, so the player can't drop and grab repeatedely
    //        // to get an infinite uses of that item
    //        collidedPlayer = collision.gameObject;
    //        gameObject.GetComponent<Inventory>().acquireItem(collidedPlayer);
    //        collidedPlayer.GetComponent<Item>().getAbsorbed();
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
