using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region Variables
    // Components

    public int maxInventorySize;
    public int currInventorySize;
    public GameObject slot1, slot2, slot3;

    public Player player;

    [SerializeField]
    private InventoryItem selectedItem;
    public InventoryItem SelectedItem
    {
        get
        {
            return selectedItem;
        }
        set
        {
            if (selectedItem)
            {
                selectedItem.selectedImage.enabled = false;
            }


            selectedItem = value;

            selectedItem.selectedImage.enabled = true;

        }
    }

    #endregion Variables

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        currInventorySize = 0;
        maxInventorySize = 3;
        slot1 = null;
        slot2 = null;
        slot3 = null;
        SelectedItem = player.uIInventory.inventoryItems[0].GetComponent<InventoryItem>();
    }

    public void NextItem()
    {
        if (SelectedItem == player.uIInventory.inventoryItems[0].GetComponent<InventoryItem>())
        {
            SelectedItem = player.uIInventory.inventoryItems[1].GetComponent<InventoryItem>();
        }
        else if (SelectedItem == player.uIInventory.inventoryItems[1].GetComponent<InventoryItem>())
        {
            SelectedItem = player.uIInventory.inventoryItems[2].GetComponent<InventoryItem>();
        }
        else
        {
            SelectedItem = player.uIInventory.inventoryItems[0].GetComponent<InventoryItem>();
        }
    }

    public void PreviousItem()
    {
        if (SelectedItem == player.uIInventory.inventoryItems[0].GetComponent<InventoryItem>())
        {
            SelectedItem = player.uIInventory.inventoryItems[2].GetComponent<InventoryItem>();
        }
        else if (SelectedItem == player.uIInventory.inventoryItems[1].GetComponent<InventoryItem>())
        {
            SelectedItem = player.uIInventory.inventoryItems[0].GetComponent<InventoryItem>();
        }
        else
        {
            SelectedItem = player.uIInventory.inventoryItems[1].GetComponent<InventoryItem>();
        }
    }

    public void useSelectedItem()
    {
        GameObject selectedItemGameObject = slot1;
        if (SelectedItem == player.uIInventory.inventoryItems[1].GetComponent<InventoryItem>())
        {
            selectedItemGameObject = slot2;
        }
        else if (SelectedItem == player.uIInventory.inventoryItems[2].GetComponent<InventoryItem>())
        {
            selectedItemGameObject = slot3;
        }

        if (selectedItemGameObject == null)
        {
            Debug.Log("There's no Item in this Slot");
            return;
        }
        selectedItemGameObject.GetComponent<Item>().useItem(gameObject);
        // Is health depleted after this usage? If yes, dumps the item from the inventory
        if (isBroken(selectedItemGameObject))
        {
            dumpSelectedItem();
            gameObject.GetComponent<UIInventory>().updateInventory(slot1, slot2, slot3, currInventorySize);
            // Debug.Log("First item broke and was dumped!");
        }
    }

    // Uses the first item in the inventory
    public void useFirstItem()
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

    public bool isBroken(GameObject item)
    {
        return (item.GetComponent<Item>().itemHealth <= 0);
    }

    public void dumpSelectedItem()
    {
        GameObject selectedItemGameObject = slot1;
        if (SelectedItem == player.uIInventory.inventoryItems[1].GetComponent<InventoryItem>())
        {
            selectedItemGameObject = slot2;
        }
        else if (SelectedItem == player.uIInventory.inventoryItems[2].GetComponent<InventoryItem>())
        {
            selectedItemGameObject = slot3;
        }

        if (selectedItemGameObject == slot1)
        {
            slot1 = slot2;
            slot2 = slot3;
            slot3 = null;
        }
        else if (selectedItemGameObject == slot2)
        {
            slot2 = slot3;
            slot3 = null;
        }
        else
        {
            slot3 = null;
        }

        StartCoroutine(discardItem(selectedItemGameObject));
        selectedItemGameObject.SetActive(false);
        currInventorySize -= 1;
    }

    public void dumpFirstItem()
    {
        GameObject discardingItem = slot1;
        slot1 = slot2;
        slot2 = slot3;
        slot3 = null;

        StartCoroutine(discardItem(discardingItem));
        //discardingItem.SetActive(false);
        currInventorySize -= 1;
    }

    public IEnumerator discardItem(GameObject item)
    {
        yield return new WaitForSeconds(3f);
        // TODO: Retirar Gambiarra
        item.SetActive(false);
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
    public void acquireItem(GameObject addedItem)
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
        //GlobalVariables.itemSpawner.poolItems.Add(addedItem);
        //addedItem.SetActive(false);
        addedItem.transform.position = new Vector2(20f, 20f);
    }

    // Update is called once per frame
    void Update()
    {

    }


}
