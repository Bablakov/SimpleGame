using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;      // Объект для спавна
    private Transform player;    // Позиция игрока

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()  // Создние элемента
    {
        Vector2 playerPos = new Vector2(player.position.x + 1, player.position.y - 0.5f);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
