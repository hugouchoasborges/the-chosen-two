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


    public int maxObjectInScene;
    public float validMapRange, timeBetweenSpawns;

    int currObjectInScene, spawnX, spawnY;

    public List<ItemElement> itemTemplates;

    // Spawn item in a random location of the map
    void spawnItem()
    {
        getValidCoordinates();
        float x_f = (float)spawnX;
        float y_f = (float)spawnY;
        Vector3 spawnPoint = new Vector3(x_f, y_f, -2.0f);
        GameObject itemPreset = selectItemType();
        GameObject newlySpawnedItem = Instantiate(itemPreset, spawnPoint, Quaternion.identity, transform);
        ItemOnMap itemTimedown = newlySpawnedItem.AddComponent(typeof(ItemOnMap)) as ItemOnMap;
        //Debug.Log("Spawning item at " + x_f + ";" + y_f);
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
        currObjectInScene = 0;
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
        //Debug.Log("Checking conditions for Spawn. Current items: " + currObjectInScene);
        if (currObjectInScene < maxObjectInScene)
        {
            spawnItem();
        }
        
    }
}
