using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    const int maxInventorySize = 3;
    public List<GameObject> playerInventory;

    // Removes the last item from the list when the inventory is full and the player picks up a new item
    public void dumpLastItem ()
    {
        playerInventory.RemoveAt(2);
        Debug.Log("Dumped item!");
    }

    // Adds a item into the queue
    public void acquireItem (GameObject addedItem)
    {
        if (playerInventory.Count >= maxInventorySize)
        {
            dumpLastItem();
        }
        playerInventory.Add(addedItem);
        Debug.Log(playerInventory.Count);
        gameObject.GetComponent<UIInventory>().updateInventory(playerInventory);
    }

    public List<GameObject> getPlayerInventory ()
    {
        return playerInventory;
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
