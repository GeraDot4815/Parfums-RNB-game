using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Sprite imageSelect;
    private SpriteRenderer image;

    [SerializeField] private int idTile;

    void Start()
    {
        image = GetComponent<SpriteRenderer>();
        image.sprite = GameControll.Instance.defaultImage;
    }

    public void SetId(int id)
    {
        idTile = id;
    } 
    
    public int GetId()
    {
        return idTile;
    }

    public void ActiveImage()
    {
        image.sprite = imageSelect;
    }
    
    public void DeactiveImage()
    {
        image.sprite = GameControll.Instance.defaultImage;
    }

    public void OnMouseDown()
    {
        GameControll.Instance.SelectUpdate(this);
    }
}
