using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    const int maxInventorySize = 3;
    public List<GameObject> playerInventory;

    // Uses the first item in the inventory
    public void useFirstItem ()
    {
        Debug.Log("TESTE");
        GameObject firstItem = playerInventory[0];
        firstItem.GetComponent<Item>().useItem();
        // Is health depleted after this usage? If yes, dumps the item from the inventory
        if (isBroken(firstItem))
        {
            dumpFirstItem();
            Debug.Log("First item broke and was dumped!");
        }
    }
    
    public bool isBroken(GameObject firstItem)
    {
        return (firstItem.GetComponent<Item>().itemHealth > 0);
    }
    
    public void dumpFirstItem ()
    {
        dumpLastItem(); 
    }
    // Removes the last item from the list when the inventory is full and the player picks up a new item
    public void dumpLastItem ()
    {
        playerInventory.RemoveAt(2);
    }

    // Adds a item into the queue
    public void acquireItem (GameObject addedItem)
    {
        if (playerInventory.Count >= maxInventorySize)
        {
            dumpLastItem();
        }
        playerInventory.Add(addedItem);
        // Debug.Log(playerInventory.Count);
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
