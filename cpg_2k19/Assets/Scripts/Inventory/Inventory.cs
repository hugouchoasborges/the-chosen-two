using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxInventorySize;
    public int currInventorySize;
    public GameObject slot1, slot2, slot3;
    //public List<GameObject> playerInventory;

    // Uses the first item in the inventory
    public void useFirstItem ()
    {
        GameObject firstItem = slot1;
        firstItem.GetComponent<Item>().useItem(gameObject);
        // Is health depleted after this usage? If yes, dumps the item from the inventory
        if (isBroken(firstItem))
        {
            dumpFirstItem();
            gameObject.GetComponent<UIInventory>().updateInventory(slot1, slot2, slot3, currInventorySize);
            // Debug.Log("First item broke and was dumped!");
        }
    }
    
    public bool isBroken(GameObject firstItem)
    {
        return (firstItem.GetComponent<Item>().itemHealth <= 0);
    }

    public void dumpFirstItem()
    {
        GameObject discardingItem = slot1;
        slot1 = slot2;
        slot2 = slot3;
        slot3 = null;
        discardingItem.SetActive(false);
        currInventorySize -= 1;
    }

    public void dumpLastItem()
    {
        GameObject discardingItem = slot3;
        discardingItem.SetActive(false);
        slot3 = null;
        currInventorySize -= 1;
    }

    // Removes the last item from the list when the inventory is full and the player picks up a new item
    //void dumpItem (int index)
    //{
    //    playerInventory[index].SetActive(false);
    //}

    // Adds a item into the queue
    public void acquireItem (GameObject addedItem)
    {
        if (currInventorySize >= maxInventorySize)
        {
            dumpLastItem();
        }
        int addSlot = currInventorySize + 1;
        if (addSlot == 1)
        {
            slot1 = addedItem;
        }
        else if (addSlot == 2)
        {
            slot2 = addedItem;
        }
        else if (addSlot == 3)
        {
            slot3 = addedItem;
        }
        currInventorySize += 1;
        gameObject.GetComponent<UIInventory>().updateInventory(slot1, slot2, slot3, currInventorySize);
    }
        
    // Start is called before the first frame update
    void Start()
    {
        currInventorySize = 0;
        maxInventorySize = 3;
        slot1 = null;
        slot2 = null;
        slot3 = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
