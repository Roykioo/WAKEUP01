using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class Add_Item : ItemContainer
{
    public GameObject enlarged;
    public float duration;
    public GameObject player;
    public SpriteRenderer bg => this.GetComponent<SpriteRenderer>();
    public int itemId = 0;
    public bool inspace;
    private void Start()
    {
        this.item = Inventory.Ins.NewItem(itemId);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inspace = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inspace = false;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inspace)
        {
            
            if (Inventory.Ins.isFull)
            {
                Debug.Log("背包满了");
            }
            else
            {
                Inventory.Ins.AddItem(item);
                this.Send(EC.E_RefreshItem);
                this.Pickuped();
            }
            SceneController.instance.checkdoor = true;
            enlarged.SetActive(true);
            enlarged.transform.position=new Vector3(Camera.main.transform.position.x,Camera.main.transform.position.y,-2);
            player.gameObject.GetComponent<PlayerMovement>().enabled = false;
        }
    }
    //被拿走
    public void Pickuped()
    {
        this.gameObject.SetActive(false);
    }
}
