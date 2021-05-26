using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Transform map;
    [SerializeField]
    private Texture2D[] mapData;
    [SerializeField]
    private MapElement[] mapElements;
    [SerializeField]
    private Sprite defaultTile;

    //Initializes the world start position to the lower left corner of the camera
    private Vector3 WorldStartPos
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(0,0));
        }
    }

    //Generate the map before the first frame update
    void Start()
    {
        GenerateMap();
    }


    //TODO: What does this do?
    private void GenerateMap()
    {
        int height = mapData[0].height;
        int width = mapData[0].width;
        for (int i = 0; i < mapData.Length; i++)
        {
            for (int x = 0; x < mapData[i].width; x++)
            {
                for (int y = 0; y < mapData[i].height; y++)
                {
                    Color c = mapData[i].GetPixel(x,y);


                    MapElement newElement = Array.Find(mapElements, e => e.MyColor == c);
                    if (newElement != null)
                    {
                        float xPos = WorldStartPos.x + (defaultTile.bounds.size.x * x);
                        float yPos = WorldStartPos.y + (defaultTile.bounds.size.y* y);
                        GameObject go = Instantiate(newElement.MyElementPrefab);
                        go.transform.position = new Vector2(xPos,yPos);
                        if (newElement.MyTileTag == "Tree01" || newElement.MyTileTag == "Tree06" || newElement.MyTileTag == "Tree12"|| newElement.MyTileTag == "Bush01"|| newElement.MyTileTag == "Bush02"|| newElement.MyTileTag == "Flower03"|| newElement.MyTileTag == "Flower08"|| newElement.MyTileTag == "Flower44")
                        {
                            go.GetComponent<SpriteRenderer>().sortingOrder = height*2 - y*2;
                        }
                        go.transform.parent = map;
                    }
                }
            }
        }
    }
}

//TODO: Please explain this class and its methods
[Serializable]
public class MapElement
{
    [SerializeField]
    private string tileTag;
    [SerializeField]
    private Color color;
    [SerializeField]
    private GameObject elementPrefab;
    public GameObject MyElementPrefab
    {
        get
        {
            return elementPrefab;
        }
    }
    public Color MyColor
    {
        get
        {
            return color;
        }
    }
    public string MyTileTag
    {
        get
        {
            return tileTag;
        }
    }
}
