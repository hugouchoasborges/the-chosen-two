using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnMap : MonoBehaviour
{
    public float lifetime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Destroy(gameObject, lifetime);
        StartCoroutine(HideAfterSeconds(gameObject, lifetime));
    }

    IEnumerator HideAfterSeconds(GameObject gObject, float lifetime)
    {
        Player player = GlobalVariables.player;

        yield return new WaitForSeconds(lifetime);
        if (!player.inventory.playerInventory.Contains(gObject))
        {
            GlobalVariables.itemSpawner.poolItems.Add(gObject.GetComponent<Item>());
            gObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
