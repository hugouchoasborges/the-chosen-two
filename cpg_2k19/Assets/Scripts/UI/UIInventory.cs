using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIInventory : MonoBehaviour
{

    public CanvasRenderer inventoryUIElement;
    public Image[] inventoryItems;

    public void updateInventory (List<GameObject> list)
    {
        for (int i = 0; (i < list.Count); ++i)
        {
            GameObject listItem = list[i];
            inventoryItems[i].sprite = listItem.GetComponent<SpriteRenderer>().sprite;
        }
        
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
