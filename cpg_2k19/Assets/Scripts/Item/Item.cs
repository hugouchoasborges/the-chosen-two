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
