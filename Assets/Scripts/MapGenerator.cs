using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MapGenerator : MonoBehaviour {
    public Light lighte;
    public GameObject DestroyOnStartClic;
    public Slider sliderx;
    public Slider slidery;
    public Slider sliderDiff;
    public GameObject thuilePrefab;
    public GameObject ChestPrefab;
    public GameObject Player;
    public GameObject PickupPrefab;
    public int XSize=10;
    public int YSize = 10;
    public int ProbOfChestatstart = 10;

    bool squarebool=false;
    bool lanscapebool = true;

	void Start ()
    {
      //  GenerateMap(XSize,YSize,ProbOfChestatstart);
	}
	public void square()
    {
        squarebool = true;
        lanscapebool = false;
    }
    public void landscap()
    {
        squarebool = false;
        lanscapebool = true;
    }
	
	void Update ()
    {
       XSize = (int)sliderx.value;
        YSize = (int)slidery.value;
        ProbOfChestatstart = (int)sliderDiff.value;
    }
    public void OnClicStart()
    {

        GenerateMap(XSize, YSize, ProbOfChestatstart);
        Instantiate(lighte);
        GameObject P = Instantiate(Player, new Vector3(2, 2, 2), Quaternion.identity);
        Camera.main.GetComponent<camera>().player = P;
        Camera.main.transform.position = new Vector3(2, 7, -1);
        Camera.main.GetComponent<camera>().offset = new Vector3(2, 7, -1) - P.transform.position;
        Destroy(DestroyOnStartClic);
        
    }
    public void GenerateMap(int mapLongeur, int mapLargeur, int ProbOfChest)
    {
        for (int x = 0; x < mapLargeur; x++)
        {
            for (int y = 0; y < mapLongeur; y++)
            {
                GameObject Thuile = Instantiate(thuilePrefab);
                ThuileInfo TI = Thuile.GetComponent<ThuileInfo>();
                TI.cooX = x;
                TI.cooY = y;
                if(squarebool)
                {
                    TI.Hauteur = Random.Range(0f, 1f);
                    TI.multiplicator = 1f;
                }
                if(lanscapebool)
                {
                    TI.Hauteur = Random.Range(0f, 4f);
                    TI.multiplicator = 0.25f;
                }
                
                TI.ChestPrefab = ChestPrefab;
                TI.HasChest = generatingChest(10);
                TI.pickupPrefab = PickupPrefab;
                TI.hasPickup = generatingPickup(2);
                makeWall(TI);
            }
        }
    }
    public void makeWall(ThuileInfo info)
    {
        if(info.cooX==0||info.cooY==0||info.cooX==XSize-1||info.cooY==YSize-1)
        {
            if(squarebool)
            {
                info.Hauteur = 2;
            }
            if(lanscapebool)
            {
                info.Hauteur = 10;
            }
            
            info.hasPickup = false;
            info.HasChest = false;
        }
    }
   public  bool generatingChest(int prob)
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
    public bool generatingPickup(int prob)
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
