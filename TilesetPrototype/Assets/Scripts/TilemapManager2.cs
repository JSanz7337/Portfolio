using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEditor.Events;

public class TilemapManager : MonoBehaviour
{


    public Vector2 mapSize; //Tamaño del mapa

    public GameObject go_Grid; //Grid del mapa
    public GameObject go_Tilemap; //Objeto Tilemap
    public GameObject go_Menu_Grid;

    public Tilemap tmap_Tilemap; //Tilemap

    public Tile t_tile; //Tile Individual
    public Tile[] t_AllTiles; //Lista de tiles

    public Sprite[] sp_sprite; //Lista de sprites

    // Use this for initialization

    void Start()
    {
        //Debug.Log("A crear el mapa: "+mapSize.x+" de ancho por: "+mapSize.y+" de alto.");

        Create_Tilemap();
        Create_SpriteSet();
        Set_Sprites();
        Select_Tile(0);
        Create_Menu();

        //Debug.Log(t_AllTiles[0]);
        //tile.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Place_Tile();
        }
        if (Input.GetMouseButton(1))
        {
            Delete_Tile();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Select_Tile(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Select_Tile(1);
        }
    }

    void Create_Tilemap()
    {
        //PRIMERO CREAMOS EL GRID
        go_Grid = new GameObject("Grid");
        go_Grid.AddComponent<Grid>();

        //AÑADIMOS EL TILEMAP AL GRID
        go_Tilemap = new GameObject("Tilemap");
        go_Tilemap.AddComponent<Tilemap>();
        go_Tilemap.AddComponent<TilemapRenderer>();
        go_Tilemap.transform.SetParent(go_Grid.transform);

        //CREAMOS UN GAMEOBJECT DEL TILEMAP
        tmap_Tilemap = go_Tilemap.GetComponent<Tilemap>();

    }

    void Create_SpriteSet()
    {
        //CREAMOS EL SPRITE
        sp_sprite = Resources.LoadAll<Sprite>("Sprites/Outside_A2");
        //CREAMOS LOS TILES QUE PERTENECEN AL SPRITE
        t_AllTiles = Resources.LoadAll<Tile>("Sprites/Tiles");
    }

    void Place_Tile()
    {
        Mouse_Pos();
        tmap_Tilemap.SetTile(new Vector3Int(Mouse_Pos().x, Mouse_Pos().y, 0), t_tile);
    }
    void Delete_Tile()
    {
        Mouse_Pos();
        tmap_Tilemap.SetTile(new Vector3Int(Mouse_Pos().x, Mouse_Pos().y, 0), null);
    }

    void Check_Tiles()
    {

    }

    void Select_Tile(int Tile)
    {
        t_tile = t_AllTiles[Tile];
        //t_tile.sprite = sp_sprite[2];
    }

    void Set_Sprites()
    {
        for (int i = 0; i < t_AllTiles.Length; i++)
        {
            t_AllTiles[i].sprite = sp_sprite[i];
        }
    }

    void Create_Menu()
    {
        GameObject T;
        Debug.Log(go_Menu_Grid.name);
        go_Menu_Grid = GameObject.Find("Menu_Grid_Tiles");
        Debug.Log(go_Menu_Grid.name);

        for (int i = 0; i < t_AllTiles.Length; i++)
        {
            T = new GameObject(t_AllTiles[i].name);
            T.AddComponent<RectTransform>();
            T.AddComponent<CanvasRenderer>();
            T.AddComponent<Image>();
            T.GetComponent<Image>().sprite = t_AllTiles[i].sprite;
            T.transform.SetParent(go_Menu_Grid.transform);
            T.GetComponent<RectTransform>().transform.localScale = new Vector3(1, 1, 1);
            T.AddComponent<Button>();
        }
    }

    Vector3Int Mouse_Pos()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int coordinate = go_Grid.GetComponent<Grid>().WorldToCell(mouseWorldPos);
        return coordinate;
    }

}