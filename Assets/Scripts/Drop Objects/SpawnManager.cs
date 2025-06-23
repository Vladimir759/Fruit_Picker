using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnObjects
{
    Bomb = 0,
    Pineapple = 1,
    GreenWormApple = 2,
    RedWormApple = 3,
    Watermelon = 4,
    Melon = 5
}

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<GameObject> dropItemsList = new List<GameObject>();
    [SerializeField] private List<GameObject> objectsInSceneList = new List<GameObject>();
    [SerializeField] private GameObject [] reservedItems;
    private float secondsBetweenDrops = 1f;

    public float SecondsBetweenDrops
    {
        get { return secondsBetweenDrops; }
        set { secondsBetweenDrops = Mathf.Abs(value); }
    }

    private void Start()
    {
        StartCoroutine(SpawnRandomObject());
    }

    public void AddNewDropItem(int id)
    {
        GameObject newItem = Instantiate(reservedItems[id]);
        dropItemsList.Add(newItem);
    }

    public void DisableAllDropedObjects()
    {
        StopCoroutine(SpawnRandomObject());
        foreach (var item in objectsInSceneList)
        {                   
            item.SetActive(false);
            dropItemsList.Add(item);
        }
        foreach (var item in dropItemsList)
        {
            objectsInSceneList.Remove(item);
        }
    }

    public void ReturnToDropList(GameObject obj)
    {
        objectsInSceneList.Remove(obj);
        obj.SetActive(false);
        dropItemsList.Add(obj);
    }

    private IEnumerator SpawnRandomObject()
    {
        yield return new WaitForSeconds(1f);
        while(true)
        {
            yield return new WaitForSeconds(secondsBetweenDrops);
            GameObject obj = dropItemsList[Random.Range(0, dropItemsList.Count)];
            obj.SetActive(true);
            dropItemsList.Remove(obj);
            obj.transform.position = spawnPoint.position;
            objectsInSceneList.Add(obj);
        }
    }
}
