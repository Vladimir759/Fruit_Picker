using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpowner : MonoBehaviour
{
    [SerializeField] private List<GameObject> dropItems;
    [SerializeField] private List<GameObject> reservedItems;
    private Queue<GameObject> itemsQueue;

    public float speed = 1f;
    public float chanceToChangeDirection = 0.1f;
    public float secondsBetweenDrops = 1f;

    private void Awake()
    {
        itemsQueue = new Queue<GameObject>(reservedItems);
    }


    private void Start()
    {
        Invoke("FruitDrop", 2.5f);
    }
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if(pos.x > 18 || pos.x < -18)
        {
            speed *= -1;
        }       
    }

    private void FixedUpdate()
    {      
        if (Random.value < chanceToChangeDirection)
        {
            speed *= -1;
            Debug.Log("Direction Inverted");
        }
    }

    private void FruitDrop()
    {
        GameObject fruit = Instantiate<GameObject>(dropItems[Random.Range(0, dropItems.Count)]);
        Vector3 pos = transform.position;
        pos.y = transform.position.y + 0.5f;
        fruit.transform.position = pos;
        Invoke("FruitDrop", secondsBetweenDrops);
    }

    public void AddNewDropItem()
    {
        dropItems.Add(itemsQueue.Dequeue());
    }
}
