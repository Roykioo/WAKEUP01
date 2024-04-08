using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QInventory
{
    public class GameObjectData : MonoBehaviour
    {
        public Item item;
        [HideInInspector]
        public bool isEquipped = false;
        //[HideInInspector]
        public int amount = 1;
        private Q_Inventory inv;
        public void Awake()
        {
            amount = 1;
        }
        public void Update()
        {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1000);
            if (hit.collider != null && hit.collider.tag == "Item")
            {
                AddItemSelf();
            }
        }       
        }
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.01f);
            inv = Q_GameMaster.Instance.inventoryManager.playerInventory;
            Vector3 scale = Q_GameMaster.Instance.inventoryManager.player.transform.localScale;
            if (!isEquipped)
            {
                transform.localScale = new Vector3(scale.x * transform.localScale.x, scale.y * transform.localScale.y, scale.z * transform.localScale.z);
            }
        }

        public void AddItemSelf()
        {
            for (int i = 0; i < amount; i++)
            {
                inv.AddItem(item.ID);
            }
            Destroy(gameObject);
        }


    }
}

