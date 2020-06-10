using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator: MonoBehaviour
{
    
    private float gapOnX;
    private float gapOnY;

    [SerializeField] Transform generateTilePoint;
    [SerializeField] GameObject[] tiles;
    public int tileIndex;
    [SerializeField] float xMin;
    [SerializeField] float xMax;
    
    [SerializeField] float yMaxValue;
    [SerializeField] float yMinValue;
    [SerializeField] ObjectSpawner objectSpawnerRef;
    private float tileLength;
    private Vector3 tilePosition;
    private Vector3 spawnPosition;
    private bool isUseable;

    private void Start()
    {
        isUseable = true;
    }

    void Update()
    {
        if (isUseable)
        {
            GenerateTile();
        }
    }

    void GenerateTile()
    {
        if (this.transform.position.x < generateTilePoint.position.x)
        {
            gapOnX = Random.Range(xMin, xMax);
            gapOnY = Random.Range(yMinValue,yMaxValue);
            tileIndex = Random.Range(0, tiles.Length);
            transform.position = new Vector3(transform.position.x + tiles[tileIndex].GetComponent<BoxCollider2D>().size.x + gapOnX, gapOnY, 0);
            Instantiate(tiles[tileIndex],transform.position,transform.rotation);

            //Spawn Engery inside a certain range around spawned tile's location
            tileLength = tiles[tileIndex].GetComponent<BoxCollider2D>().size.x;
            tilePosition = this.transform.position;
            float objectXmin = tilePosition.x - tileLength / 2;
            float objectXmax = tilePosition.x + tileLength / 2;
            float objectXpos = Random.Range(objectXmin, objectXmax);
            float objectYmin = tilePosition.y + 0.8f;
            float objectYmax = tilePosition.y + 2f;
            float objectYpos = Random.Range(objectYmin, objectYmax);
            spawnPosition = new Vector3(objectXpos, objectYpos, tilePosition.z);
            //Spawn random number of engery
            objectSpawnerRef.SpawnEngery(spawnPosition);
            
        }
    }

    public void ToogleIsUsable(bool isUsableInput)
    {
        isUseable = isUsableInput;
    }
   
}
