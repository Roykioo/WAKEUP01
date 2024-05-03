using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemContainer : MonoBehaviour
{
    public Image image;
    public SpriteRenderer sprr;
    protected virtual void refreshView()
    {
        if (this.item)
        {

            if (this.image)
                this.image.sprite = this.item.itemImage;
            if (this.sprr)
                this.sprr.sprite = this.item.itemImage;

        }
        else
        {
            if (this.image)
                this.image.sprite = null;
            if (this.sprr)
                this.sprr.sprite = null;

        }

    }
    [SerializeField]
    private Item _item;
    public Item item
    {
        get
        {
            return _item;
        }
        set
        {
            _item = value;

            this.refreshView();
        }
    }
}
