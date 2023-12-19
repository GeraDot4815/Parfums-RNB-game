using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour
{
    public static GameControll Instance;
    public Sprite defaultImage;

    [SerializeField] private GameObject[] images;
    [SerializeField] private Transform startPosition;

    [SerializeField] private GameObject prefabTile;
    [SerializeField] private int columns = 4;
    [SerializeField] private int rows = 2;

    [SerializeField] private float Xspace = 4f;
    [SerializeField] private float Yspace = -5f;
    [SerializeField] private int score = 0;

    private Tile select;
    private Tile openNow;
    private bool wait = false;

    private void Awake()
    {
        if (Instance == null) { 
            Instance = this; 
        }
    }

    private void Start()
    {
        GameStart();
    }

    private void GameStart()
    {
        int[] boardPosition = new int[images.Length * 2];
        for (int i = 0; i < images.Length; i++)
        {
            boardPosition[i * 2] = i;
            boardPosition[i * 2 + 1] = i;
        }
        boardPosition = Shuffle(boardPosition);

        Vector3 position = startPosition.position;

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                GameObject gameObject = Instantiate(prefabTile);
                Tile tileInstant = gameObject.GetComponent<Tile>();
                int index = j * columns + i;
                int id = boardPosition[index];
                GameObject nowImage = Instantiate(images[id]);
                tileInstant.childImage = nowImage.transform.GetComponent<SpriteRenderer>();
                tileInstant.childImage.enabled = false;
                tileInstant.SetId(id);
                
                float positionX = (Xspace * i) + position.x;
                float positionY = (Yspace * j) + position.y;

                nowImage.transform.position = new Vector3(positionX, positionY, position.z);
                gameObject.transform.position = new Vector3(positionX, positionY, position.z);
            }
        }
    }

    public void SelectUpdate(Tile tile)
    {
        if (wait) { return; }
        if (tile == select) { return; }


        if (select != null)
        {
            openNow = tile;
            tile.ActiveImage();
            StartCoroutine(CheckEqual());
        } else
        {
            select = tile;
            tile.ActiveImage();
        }
    }
   


    private int[] Shuffle(int[] position)
    {
        int[] array = position.Clone() as int[];
        for (int i = 0; i < array.Length; i++)
        {
            int newIndex = array[i];
            int j = UnityEngine.Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newIndex;
        }
        return array;
    }

    public IEnumerator CheckEqual()
    {
        if (select.GetId() == openNow.GetId())
        {
            score++;
        }
        else
        {
            wait = true;
            yield return new WaitForSeconds(0.5f);

            select.DeactiveImage();
            openNow.DeactiveImage();
        }

        wait = false;
        select = null;
        openNow = null;
    }
}
