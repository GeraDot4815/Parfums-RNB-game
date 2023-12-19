using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private SpriteRenderer image;

    [SerializeField] private int idTile;
    public SpriteRenderer childImage;

    void Start()
    {
        image = GetComponent<SpriteRenderer>();
        image.sprite = GameControll.Instance.defaultImage;
        childImage.enabled = false;
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
        image.enabled = false;
        childImage.enabled = true;
    }
    
    public void DeactiveImage()
    {
        image.sprite = GameControll.Instance.defaultImage;
        image.enabled = true;    
        childImage.enabled = false;
    }

    public void OnMouseDown()
    {
        GameControll.Instance.SelectUpdate(this);
    }
}
