using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    const int maxInventorySize = 3;
    public List<Item> playerInventory;

    // Removes the last item from the list when the inventory is full and the player picks up a new item
    void dumpLastItem ()
    {
        if (playerInventory.Count >= maxInventorySize)
        {
            playerInventory.RemoveAt(maxInventorySize - 1);
        }
    }

    // Adds a item into the queue
    void acquireItem (Item addedItem)
    {
        playerInventory.Add(addedItem);
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
