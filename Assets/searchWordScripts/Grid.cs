using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

	public int ROWS = 8;
	public int COLUMNS = 6;

	public GameObject gridTileGO;

	public  float GRID_OFFSET_X = 6.4f;
	public  float GRID_OFFSET_Y = 10f;

	[HideInInspector]
	public List<Tile> tiles;

	[HideInInspector]
	public List<List<Tile>  > gridTiles;

	private string wordSource;

	private int wordSourceIndex;

	private struct Cell
	{
		public int row;
		public int column;
	}

	private List<Cell> gridIndexes;


	void Awake () {
		BuildSuffledIndexes ();
	}

	public void BuildGrid ()
	{
		var wordData = GetComponent<WordData> ();
		wordSource = wordData.GetRandomWord ();
		
		foreach (var index in gridIndexes) 
		{
			gridTiles[index.column][index.row].SetTileData(wordSource[wordSourceIndex]);
			wordSourceIndex++;
			if (wordSourceIndex == wordSource.Length)
			{
				wordSource = wordData.GetRandomWord();
				wordSourceIndex = 0;
			}
		}
	}

	public void CollapseGrid ()
	{
		for (int column = 0; column < COLUMNS; column++) {

			var columnList = gridTiles[column];
			var newColumn = new List<Tile>(ROWS);
			var removedCnt = 0;
			var row = ROWS - 1;
			var removedTiles = columnList.FindAll ( (e)=> {return (!e.gameObject.activeSelf);});
			removedTiles.Reverse();
			var totalRemoved = removedTiles.Count;

			for (var i = columnList.Count - 1; i >= 0; i--)
			{
				if (!columnList[i].gameObject.activeSelf)
				{
					columnList[i].row = removedCnt;
					var p = columnList[i].transform.position;
					p.y = columnList[0].transform.position.y + (totalRemoved - removedCnt) * 2.4f ;
					columnList[i].transform.position = p;
					removedCnt++;
				}
				else
				{
					columnList[i].row = row;
					row--;
					newColumn.Insert(0, columnList[i]);
				}
			}

			//append removed tiles
			newColumn.InsertRange (0, removedTiles);

			//update tiles
			foreach (var tile in newColumn)
			{
				tile.UpdateData();
			}

			gridTiles[column] = newColumn;
		}
	}

	private void BuildSuffledIndexes ()
	{
		tiles = new List<Tile> ();
		gridTiles = new List<List<Tile>> ();
		
		gridIndexes = new List<Cell> ();
		Cell indexer;
		for (int column = 0; column < COLUMNS; column++) {
			
			var columnTiles = new List<Tile>();
			
			for (int row = 0; row < ROWS; row++) {
				indexer = new Cell();
				indexer.column = column;
				indexer.row = row;
				gridIndexes.Add (indexer);
				
				var item = Instantiate (gridTileGO) as GameObject;
				var tile = item.GetComponent<Tile>();
				tile.SetTilePosition(this, column, row);
				tile.transform.parent = gameObject.transform;
				tiles.Add (tile);
				columnTiles.Add (tile);
			}
			gridTiles.Add(columnTiles);
		}

		WordData.ShuffleList (gridIndexes);
	}

}
