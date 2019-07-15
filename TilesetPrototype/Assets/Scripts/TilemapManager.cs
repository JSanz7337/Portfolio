using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour {


	public Vector2 mapSize;

	public GameObject go_Grid;
	public GameObject go_Tilemap;

	public Tilemap tmap_Tilemap;

	public Tile t_tile;
	public Tile[] t_AllTiles;

	public Sprite[] sp_sprite;

	// Use this for initialization

	void Start () {
		//Debug.Log("A crear el mapa: "+mapSize.x+" de ancho por: "+mapSize.y+" de alto.");

        sp_sprite = Resources.LoadAll<Sprite>("Sprites/Outside_A2");
        t_AllTiles = Resources.LoadAll<Tile>("Sprites/Tiles");

		t_tile = t_AllTiles[0];
		t_tile.sprite = sp_sprite[0];
        //Debug.Log(t_AllTiles[0]);
		//tile.color = Color.black;

        go_Grid = new GameObject("Grid");
        go_Grid.AddComponent<Grid>();

		go_Tilemap = new GameObject("Tilemap");
		go_Tilemap.AddComponent<Tilemap>();
        go_Tilemap.AddComponent<TilemapRenderer>();
		go_Tilemap.transform.SetParent(go_Grid.transform);

		tmap_Tilemap = go_Tilemap.GetComponent<Tilemap>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = go_Grid.GetComponent<Grid>().WorldToCell(mouseWorldPos);
            tmap_Tilemap.SetTile(new Vector3Int(coordinate.x,coordinate.y,0), t_tile);	
		}
	}
}
