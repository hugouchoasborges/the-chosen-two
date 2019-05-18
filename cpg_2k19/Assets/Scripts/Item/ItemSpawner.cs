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
    public float validMapRange, timeBetweenSpawns;

    int currObjectInScene, spawnX, spawnY;

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
        foreach(GameObject item in poolItems)
        {
            if ((item.GetComponent<Item>().GetType() == template.GetComponent<Item>().GetType()) && (!item.activeSelf))
                return item;
        }

        return null;
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
        }
        newlySpawnedItem.tag = "Item";
        ItemOnMap itemTimedown = newlySpawnedItem.AddComponent(typeof(ItemOnMap)) as ItemOnMap;
    }

    GameObject selectItemType ()
    {
        GameObject newItem;
        int typeSelected = (int)Random.Range(0.0f, 3.0f);

        newItem = itemTemplates[typeSelected].gameObject;

        return newItem;
    }

    // Get valid coordinates in map
    void getValidCoordinates()
    {
        spawnX = (int)Random.Range((float)-validMapRange, (float)validMapRange);
        spawnY = (int)Random.Range((float)-validMapRange, (float)validMapRange);
    }

    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.itemSpawner = this;
        currObjectInScene = 0;
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
