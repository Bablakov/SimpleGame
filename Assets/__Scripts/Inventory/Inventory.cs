using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;       // Отвечает за то что заполнена ячейка или нет
    public GameObject[] slots;  // Объекты в ячейках
}
