using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [System.Serializable]
    public class ItemElement{
        public string name;
        public GameObject gameObject;
    }

    public List<GameObject> poolItems;

    public int maxObjectInScene;
    public float validMapRangeX, validMapRangeY, timeBetweenSpawns;

    float spawnX, spawnY;

    public List<ItemElement> itemTemplates;

    private void BuildPool ()
    {
        
        for (int i = 0; i < maxObjectInScene; ++i)
        {
            GameObject newItem = selectItemType();
            newItem.SetActive(false);
            poolItems.Add(Instantiate(newItem, transform));
        }
    }

    private GameObject GetItemFromPool(GameObject template)
    {

        int indexFromPool = System.Array.FindIndex<GameObject>(poolItems.ToArray(), o => o.GetComponent<Item>().GetType() == template.GetComponent<Item>().GetType());

        //foreach (GameObject item in poolItems)
        //{
        //    if ((item.GetComponent<Item>().GetType() == template.GetComponent<Item>().GetType()) && (!item.gameObject.activeSelf))
        //    {
        //        poolItems.Remove(item);
        //        return item;
        //    }
        //}

        if(indexFromPool > -1)
        {
            GameObject item = poolItems[indexFromPool];
            poolItems.RemoveAt(indexFromPool);

            return item;
        }

        GameObject newItem = Instantiate(template, transform);

        return newItem;
    }

    // Spawn item in a random location of the map
    void spawnItem()
    {
        getValidCoordinates();
        float x_f = (float)spawnX;
        float y_f = (float)spawnY;
        Vector3 spawnPoint = new Vector3(x_f, y_f, -2.0f);
        GameObject itemPreset = selectItemType();
        GameObject newlySpawnedItem = GetItemFromPool(itemPreset);
        if(!newlySpawnedItem)
        {
            newlySpawnedItem = Instantiate(itemPreset, spawnPoint, Quaternion.identity, transform);
        }
        else
        {
            newlySpawnedItem.transform.position = spawnPoint;
            newlySpawnedItem.transform.parent = transform;
            newlySpawnedItem.SetActive(true);
            newlySpawnedItem.GetComponent<SpriteRenderer>().enabled = true;
        }
        newlySpawnedItem.tag = "Item";
        ItemOnMap itemTimedown = newlySpawnedItem.AddComponent(typeof(ItemOnMap)) as ItemOnMap;
    }

    GameObject selectItemType ()
    {
        GameObject newItem;
        int typeSelected = (int)Random.Range(0.0f, 6.0f);

        newItem = itemTemplates[typeSelected].gameObject;

        return newItem;
    }

    // Get valid coordinates in map
    void getValidCoordinates()
    {
        float playersDelta = Mathf.Abs(GlobalVariables.player2.transform.position.x - GlobalVariables.player1.transform.position.x) + Mathf.Abs(GlobalVariables.player2.transform.position.y - GlobalVariables.player1.transform.position.y); ;

        spawnX = Mathf.Clamp(Random.Range((float)-validMapRangeX, (float)validMapRangeX) * playersDelta % validMapRangeX, (float)-validMapRangeX, (float)validMapRangeX);
        spawnY = Mathf.Clamp(Random.Range((float)-validMapRangeY, (float)validMapRangeY) * playersDelta % validMapRangeY, (float)-validMapRangeY, (float)validMapRangeY);

    }

    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.itemSpawner = this;
        BuildPool();
        InvokeRepeating("canSpawnItem", 0.0f, timeBetweenSpawns);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Every [timeBetweenSpawns] seconds check if can spawn item, if it can, spawn a new one
    void canSpawnItem()
    {
        int currObjectInScene = FindObjectsOfType<ItemOnMap>().Length;
        if (currObjectInScene < maxObjectInScene)
        {
            spawnItem();
        }
        
    }
}
