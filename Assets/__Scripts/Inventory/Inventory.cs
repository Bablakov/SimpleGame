using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;       // ќтвечает за то что заполнена €чейка или нет
    public GameObject[] slots;  // ќбъекты в €чейках
    public GameObject inventory;// »гровой объект инвентарь
    private bool inventoryOn;   // ¬ключен/выключен инвентарь

    private void Start()
    {
        inventoryOn = false;
    }

    public void Chest()    // ќткрытые/закрытие элемента
    {
        if (!inventoryOn)
        {
            inventoryOn = true;
            inventory.SetActive(true);
        }
        else if (inventoryOn)
        {
            inventoryOn = false;
            inventory.SetActive(false);
        }
    }
}
