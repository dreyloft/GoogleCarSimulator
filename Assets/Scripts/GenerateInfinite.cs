using UnityEngine;
using System.Collections;

class Tile
{
	public GameObject theTile;
	public float creationTime;

	public Tile(GameObject t, float ct)
	{
		theTile = t;
		creationTime = ct;
	}
}


public class GenerateInfinite : MonoBehaviour {

	public GameObject plane;
	public GameObject player;

	public float positionCorrectionX;
	public float positionCorrectionY;
	public float positionCorrectionZ;
	public float planeSize;

	public int sizeX = 7;
	public int sizeZ = 7;

	public bool onlyXdimension;
	public bool onlyZdimension;

	public bool takeXSize;
	public bool takeZSize;

	Vector3 startPos;

	Hashtable tiles = new Hashtable();

	// Use this for initialization
	void Start () 
	{
		this.gameObject.transform.position = Vector3.zero;
		startPos = Vector3.zero;

		float updateTime = Time.realtimeSinceStartup;

		int playerX = (int)(Mathf.Floor(player.transform.position.x/planeSize)*planeSize);
		int playerZ = (int)(Mathf.Floor(player.transform.position.z/planeSize)*planeSize);


		for(int x = -sizeX; x < sizeX; x++)
		{
			if (onlyXdimension) {
				x = sizeX + 1;
			}
		
			for(int z = -sizeZ ; z < sizeZ ; z++)
			{
				if (onlyZdimension) {
					z = sizeZ + 1;
				}

				Vector3 pos = new Vector3((x * planeSize + playerX + positionCorrectionX),
				                          positionCorrectionY,
				                          (z * planeSize + playerZ + positionCorrectionZ));


				/*Vector3 pos = new Vector3((x * planeSize+startPos.x + positionCorrectionX),
				                          positionCorrectionY,
				                          (z * planeSize+startPos.z + positionCorrectionZ));
				*/GameObject t = (GameObject) Instantiate(plane, pos, 
					               Quaternion.identity);

				string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
				t.name = tilename;
				Tile tile = new Tile(t, updateTime);
				tiles.Add(tilename, tile);
			}
		}
	}

		// Update is called once per frame
	void Update () 
	{
		//determine how far the player has moved since last terrain update
		int xMove = (int)(player.transform.position.x - startPos.x);
		int zMove = (int)(player.transform.position.z - startPos.z);
		
		if(Mathf.Abs(xMove) >= planeSize || Mathf.Abs(zMove) >= planeSize)
		{
			float updateTime = Time.realtimeSinceStartup;
			
			//force integer position and round to nearest tilesize
			int playerX = (int)(Mathf.Floor(player.transform.position.x/planeSize)*planeSize);
			int playerZ = (int)(Mathf.Floor(player.transform.position.z/planeSize)*planeSize);

			for(int x = -sizeX; x < sizeX; x++)
			{
				if (onlyXdimension) {
					x = sizeX + 1;
				}
				
				for(int z = -sizeZ ; z < sizeZ ; z++)
				{
					if (onlyZdimension) {
						z = sizeZ + 1;
					}
				
					Vector3 pos = new Vector3((x * planeSize + playerX + positionCorrectionX),
												positionCorrectionY,
					                          (z * planeSize + playerZ + positionCorrectionZ));
					
					string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
					
					if(!tiles.ContainsKey(tilename))
					{
						GameObject t = (GameObject) Instantiate(plane, pos, 
						               Quaternion.identity);
						t.name = tilename;
						Tile tile = new Tile(t, updateTime);
						tiles.Add(tilename, tile);
					}
					else
					{
						(tiles[tilename] as Tile).creationTime = updateTime;
					}
				}
			}

			//destroy all tiles not just created or with time updated
			//and put new tiles and tiles to be kepts in a new hashtable
			Hashtable newTerrain = new Hashtable();
			foreach(Tile tls in tiles.Values)
			{
				if(tls.creationTime != updateTime)
				{
					//delete gameobject
					Destroy(tls.theTile);
				}
				else
				{
					newTerrain.Add(tls.theTile.name, tls);
				}
			}
			//copy new hashtable contents to the working hashtable
			tiles = newTerrain;

			startPos = player.transform.position;
		}

	}
}
