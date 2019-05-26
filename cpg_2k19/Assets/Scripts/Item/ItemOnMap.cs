using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnMap : MonoBehaviour
{
    public float lifetime = 15.0f;
    Rigidbody2D floating;

    // Start is called before the first frame update
    void Start()
    {
        // Destroy(gameObject, lifetime);
        lifetime = Random.Range(Mathf.Min(lifetime - 5f, 0f), lifetime + 5f);
        StartCoroutine(HideAfterSeconds(gameObject, lifetime));
    }

    IEnumerator HideAfterSeconds(GameObject gObject, float lifetime)
    {
        Player player1 = GlobalVariables.player1;
        Player player2 = GlobalVariables.player2;

        yield return new WaitForSeconds(lifetime);

        GlobalVariables.itemSpawner.poolItems.Add(gObject);
        //gObject.transform.position = new Vector2(20f, 20f);
        gObject.SetActive(false);

        //if ((gObject == player1.inventory.slot1 || gObject == player1.inventory.slot2 || gObject == player1.inventory.slot3) || (gObject == player2.inventory.slot1 || gObject == player2.inventory.slot2 || gObject == player2.inventory.slot3))
        //{
        //    GlobalVariables.itemSpawner.poolItems.Add(gObject);
        //    gObject.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
    }
}
