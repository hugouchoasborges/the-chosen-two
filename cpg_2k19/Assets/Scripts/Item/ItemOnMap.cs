using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnMap : MonoBehaviour
{
    public float lifetime = 10.0f;
    Rigidbody2D floating;

    // Start is called before the first frame update
    void Start()
    {
        // Destroy(gameObject, lifetime);
        StartCoroutine(HideAfterSeconds(gameObject, lifetime));
    }

    IEnumerator HideAfterSeconds(GameObject gObject, float lifetime)
    {
        Player player1 = GlobalVariables.player1;
        Player player2 = GlobalVariables.player2;

        yield return new WaitForSeconds(lifetime);

        if ((gObject == player1.inventory.slot1 || gObject == player1.inventory.slot2 || gObject == player1.inventory.slot3) || (gObject == player2.inventory.slot1 || gObject == player2.inventory.slot2 || gObject == player2.inventory.slot3))
        {
            GlobalVariables.itemSpawner.poolItems.Add(gObject);
            gObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
