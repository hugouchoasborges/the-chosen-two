using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIInventory : MonoBehaviour
{

    public CanvasRenderer inventoryUIElement;
    public Sprite defaultSlot;
    public Image[] inventoryItems;

    public void updateInventory (GameObject s1, GameObject s2, GameObject s3, int listSize)
    {
        if (s1 != null)
        {
            inventoryItems[0].sprite = s1.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            inventoryItems[0].sprite = defaultSlot;
        }

        /////////////////////////////////
        if (s2 != null)
        {
            inventoryItems[1].sprite = s2.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            inventoryItems[1].sprite = defaultSlot;

        }

        /////////////////////////////////
        if (s3 != null)
        {
            inventoryItems[2].sprite = s3.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            inventoryItems[2].sprite = defaultSlot;

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
