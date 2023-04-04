using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToInventory : MonoBehaviour
{

    [SerializeField] InventoryData inventoryContent;
    [SerializeField] GameObject inventoryCanva;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) inventoryCanva.SetActive(!inventoryCanva.activeSelf);       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag("Item"))
        {
            inventoryContent.GetComponent<InventoryData>().AddNewItem(other.GetComponent<ItemDesc>().item);     //Ajoute l'itemData dans la liste InventoryData
            Destroy(other.gameObject);
        }
    }
}
