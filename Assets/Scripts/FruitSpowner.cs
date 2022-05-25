using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//hello world
public class FruitSpowner : MonoBehaviour
{
    public List<GameObject> dropItems;
    public Queue<GameObject> reservedItems;
    public float speed = 1f;
    public float chanceToChangeDirection = 0.1f;
    public float secondsBetweenDrops = 1f;

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

    void NewAdd()
    {
        dropItems.Add(reservedItems.Dequeue());
    }
}
