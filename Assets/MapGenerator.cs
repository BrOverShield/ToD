using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {
    
    public GameObject thuilePrefab;
    public GameObject ChestPrefab;
    public int XSize=10;
    public int YSize = 10;
    public int ProbOfChest = 10;
	void Start ()
    {
        GenerateMap(10,10);
	}
	
	
	void Update ()
    {
		
	}
    void GenerateMap(int mapLongeur, int mapLargeur)
    {
        for (int x = 0; x < mapLargeur; x++)
        {
            for (int y = 0; y < mapLongeur; y++)
            {
                GameObject Thuile = Instantiate(thuilePrefab);
                ThuileInfo TI = Thuile.GetComponent<ThuileInfo>();
                TI.cooX = x;
                TI.cooY = y;
                TI.Hauteur = Random.Range(0f, 1f);
                TI.ChestPrefab = ChestPrefab;
                TI.HasChest = generatingChest(10);
                makeWall(TI);
            }
        }
    }
    void makeWall(ThuileInfo info)
    {
        if(info.cooX==0||info.cooY==0||info.cooX==XSize-1||info.cooY==YSize-1)
        {
            info.Hauteur = 2;
            info.HasChest = false;
        }
    }
    bool generatingChest(int prob)
    {
        int roll = Random.Range(0, 100);
        if (roll <= prob)
        {
            return true;
        }
        if (roll >= prob)
        {
            return false;
        }
        
        else
        {
            print("Probleme Generating Chest roll= " + roll.ToString());
            return false;
        }
    }
}
