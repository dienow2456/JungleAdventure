using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MapGenerator : MonoBehaviour
{
	
	[Header("Generation")]

	[Tooltip("The parent object for each rendered tile")]
	public Transform parentObject;

	[Tooltip("Proximity for each RBG value for a match")]
	[Range(0.001f, 0.1f)]
	public float colorMatchThreshold = 0.01f;

	[Tooltip("The alpha threshold to ignore a pixel")]
	[Range(0f, 1f)]
	public float ignorePixelAlphaThreshold = 0f;
    public int height=20;
    public int weight=100;
    public int numbermap=7;
    [Header("Render")]

	[Tooltip("Layer to apply to all tiles")]
	[Layer]
	public int tileLayer;
	[Tooltip("Prefab to render if a pixel has no tile mapping")]
	public GameObject missingTilePrefab;
	[Space]
	public TileInfo[] tileInfo;

    int demsao ;
	
	void Awake()
	{
		
		GenerateMap();
         demsao = 0;
    }

	public void GenerateMap()
	{
		// loop through each xy coordinate in texture and generate a tile for each pixel
		Color[,] colors = new Color[weight, height];	
		colors[4, 0] = new Color32(109, 109, 109, 0);   //Wall co dinh
		AddObject(4, 0, colors[4, 0]);
		colors[4, 2] = new Color32(0, 255, 0, 0);   //Glass co dinh
		AddObject(4, 2, colors[4, 2]);
		
		colors[weight - 4, 0] = new Color32(109, 109, 109, 0);   //Glass co dinh
		AddObject(weight - 4, 0 ,colors[weight - 4, 0]);
		colors[weight - 4, 2] = new Color32(0, 255, 0, 0);   //Glass co dinh
		AddObject(weight - 4, 2, colors[weight - 4, 2]);

		colors[weight - 6, 0] = new Color32(109,109,109,0);   // Wall co dinh
		AddObject(weight - 6, 0, colors[weight - 6, 0]);
		colors[weight - 6, 2] = new Color32(0, 255, 0, 0);   // Glass co dinh
		AddObject(weight - 6, 2, colors[weight - 6, 2]);
		colors[weight - 6, 4] = new Color32(255, 0, 255, 0); //Cot co co dinh
		AddObject(weight - 6, 5.5f, colors[weight - 6, 4]);
        int start = 0;
        
        AddNenCodinh(colors);
        
        int[] check= new int[numbermap];
        for (int i = 0; i < numbermap-1; i++)
        {
            int rd = RandomBatKy(4);
            check[i] = rd;
            AddMapMini(colors, check[i], start + 18);
            start += 18;
        }
        check[numbermap-1] = 10;
        for (int i = 0; i < numbermap-1; i++)        
        {    
            if(check[i+1]- check[i]==1)
            {
                if (RandomBatKy(2) == 0)
                {
                    colors[18 * (i + 2), check[i] * 2 + 2] = new Color32(0, 255, 170, 0);                        // goc nghien 30 di len
                    AddObject(18 * (i + 2) - 2.56f, check[i] * 2 + 2.37f, colors[18 * (i + 2), check[i] * 2 + 2]);
                } 
                else 
                {
                    colors[18 * (i + 2), check[i] * 2 + 2] = new Color32(101, 255, 54, 0);                        // goc nghien 45 di len
                    AddObject(18 * (i + 2) - 2.04f, check[i] * 2 + 1.98f, colors[18 * (i + 2), check[i] * 2 + 2]);
                }
            }
            else if(check[i]- check[i+1]==1)
            {
                if (RandomBatKy(2) == 0)
                {
                    colors[18 * (i + 2), check[i]] = new Color32(0, 145, 255, 0);                          // goc nghieng 30 di xuong
                    AddObject(18 * (i + 2) + 6.15f, check[i] * 2 + 10.66f, colors[18 * (i + 2), check[i]]);
                }
                else 
                {
                    colors[18 * (i + 2), check[i]] = new Color32(45, 123, 0, 0);                          // goc nghieng 45 di xuong
                    AddObject(18 * (i + 2) -0.044f, check[i] * 2 , colors[18 * (i + 2), check[i]]);
                }
            }
            else if(check[i + 1] - check[i] == 3)
            {
                colors[18 * (i + 2), check[i]] = new Color32(54, 84, 11, 0);                            // lo xo 
                AddObject(18 * (i + 2)-17.59f , check[i] * 2+3.68f , colors[18 * (i + 2), check[i]]);
            }
            int _check = RandomBatKy(5);
            if (_check==2||_check==1||_check==3)
            {
                if (RandomBatKy(2)==0)
                {
                    colors[18 * (i + 2) -4, check[i] * 2 + 2] = new Color32(0, 34, 255, 0);    // Rua
                    AddObject(18 * (i + 2)-6.5f , check[i] * 2 + 1f, colors[18 * (i + 2)-4 , check[i] * 2 + 2]);

                    colors[18 * (i + 2) , check[i] * 2 + 2] = new Color32(255, 116, 0, 0);   //	Them rao chan 2 dau	
                    AddObject(18 * (i + 2) - 5f, check[i] * 2 + 1.5f, colors[18 * (i + 2)  , check[i] * 2+ 2]);   
                    
                    colors[18 * (i + 2) - 8, check[i] * 2 + 2] = new Color32(255, 116, 0, 0);   //										
                    AddObject(18 * (i + 2) - 12.96f, check[i] * 2 + 1.5f, colors[18 * (i + 2) - 8, check[i] * 2 + 2]);
                }
                else 
                {
                    colors[18 * (i + 2) - 4, check[i] * 2 + 2] = new Color32(0, 255, 255, 0);    // Sau
                    AddObject(18 * (i + 2) - 6.5f, check[i] * 2 + 1f, colors[18 * (i + 2) - 4, check[i] * 2 + 2]);

                    colors[18 * (i + 2) , check[i] * 2 + 2] = new Color32(255, 116, 0, 0);   //	Them rao chan 2 dau	
                    AddObject(18 * (i + 2) - 5.16f, check[i] * 2 + 1.5f, colors[18 * (i + 2), check[i] * 2 +2]);   
                    
                    colors[18 * (i + 2) - 10, check[i] * 2 +2] = new Color32(255, 116, 0, 0);  //										
                    AddObject(18 * (i + 2) - 13.46f, check[i] * 2 + 1.5f, colors[18 * (i + 2) - 10, check[i] * 2 +2]);
                }

            }
            int x = check[i];
           
            if (x== RandomBatKy(check[i])+1)
            {
                for( int j=0; j <= RandomBatKy(x); j++)
                {
                colors[18 * (i + 1) +2*(j+1), 2 * (x + 2)] = new Color32(255, 255, 0, 0);       // Coin khi Glass cao
                AddObject(18 * (i + 1) + 2 * (j + 1)+0.7f, 2 *( x+2), colors[18 * (i + 1) + 2 * (j + 1), 2 * (x + 2)]);
                    if (RandomBatKy(2) == 1)
                    {
                        colors[18 * (i + 1) + 2 * (j + 1), 2 * (x + 2)] = new Color32(255, 255, 0, 0);       // Coin khi Glass cao
                        AddObject(18 * (i + 1) + 2 * (j + 1) + 0.7f, 2 * (x + 3), colors[18 * (i + 1) + 2 * (j + 1), 2 * (x + 2)]);
                    }
                    else
                    {
                        if (demsao < 3&&RandomBatKy(10)==5)
                        {
                            colors[18 * (i + 1) + 2 * (j + 1), 2 * (x + 2)] = new Color32(236, 164, 17, 0);       // sao khi Glass cao
                            AddObject(18 * (i + 1) + 2 * (j + 1) + 0.7f, 2 * (x + 3), colors[18 * (i + 1) + 2 * (j + 1), 2 * (x + 2)]);
                            demsao += 1;
                        }
                    }

                }
                
            }

        }
        AddDat(colors);
        AddDatVo(colors);
    }
    
    void AddNenCodinh(Color[,] colors)        // them thanh phan co dinh
    {
        for (int y = 0; y < 20; y += 2)
        {
            colors[0, y] = new Color32(109, 109, 109, 0); 
            colors[weight-2, y] = new Color32(109, 109, 109, 0); 
            AddObject(0, y, colors[0, y]);
            AddObject(weight-2, y, colors[weight - 2, y]);
        }
        for (int x = 2; x < 18; x += 2)
        {
            colors[x, 0] = new Color32(109, 109, 109, 0);
            colors[x, 2] = new Color32(0, 255, 0, 0);
            AddObject(x, 0, colors[x, 0]);
            AddObject(x, 2, colors[x, 2]);
        }
    }
    void AddMapMini(Color[,] colors, int docao, int vt)
    {
        if (UnityEngine.Random.Range(0, 2) == 1)
        {
            for (int x = vt; x < vt + 18; x += 2)
            {
                for (int i = 0; i < docao * 2; i += 2)
                {
                    colors[x, i] = new Color32(109, 109, 109, 0);

                    AddObject(x, i, colors[x, i]);
                }
                colors[x, docao * 2] = new Color32(0, 255, 0, 0);
                AddObject(x, docao * 2, colors[x, docao * 2]);
            }
        }
        else
        {
            for (int x = vt; x < vt + 18; x += 2)
            {
                if (x == vt || x == vt + 16)
                {
                    for (int i = 0; i < docao * 2 ; i += 2)
                    {
                        colors[x, i] = new Color32(109, 109, 109, 0);

                        AddObject(x, i, colors[x, i]);
                    }
                    colors[x, docao * 2+2] = new Color32(0, 255, 0, 0);
                    AddObject(x, docao * 2, colors[x, docao * 2+2]);
                }
                else
                {
                    colors[x, docao * 2] = new Color32(45, 255, 160, 0);
                    AddObject(x, docao * 2 + 0.53f, colors[x, docao * 2]);
                }
           
            }
        }
       
    }
    
        
  void AddDat(Color[,] colors)
    {
        for (int x = 0; x < weight-8; x += 4)
        {
            int rand = UnityEngine.Random.Range(x / 2, 2 * x);
            if (rand == x)
            {

                for (int y = 0; y < height-2; y += 2)
                {
                    int ran = UnityEngine.Random.Range(0, 2);
                    if( colors[x,y]==new Color32(0, 255, 0, 0))
                    {
                        if (ran == 0)

                        {
                            colors[x, y + 8] = new Color32(255, 83, 0, 0);          // heart
                            AddObject(x - 12.6f, y + 30.02f, colors[x, y + 8]);
                            break;
                        }else if (ran == 1)
                        {
                            if (demsao < 3)
                            {
                                colors[x, y + 8] = new Color32(202, 160, 0, 0);          // sao
                                AddObject(x - 12.6f, y + 30.02f, colors[x, y + 8]);
                                demsao += 1;
                                break;
                            }
                        }
                    }
                }
                
            }
        } 
    }
    void AddDatVo(Color[,] colors)
    {
        for (int x = 2; x < weight-8; x += 4)
        {
            int rand = UnityEngine.Random.Range(x / 2, x+1);
            if (rand == x||rand==(x/2+1)||rand==(x/2+3))
            {

                for (int y = 0; y < height-2; y += 2)
                {
                    if( colors[x,y]==new Color32(0, 255, 0, 0))
                    {
                       
                        colors[x, y + 8] = new Color32(160, 82, 45, 0);     // dat nau
                        AddObject(x+1, y + 4, colors[x, y + 8]);
                        if(RandomBatKy(2) == 1)
                        {
                            colors[x, y + 8] = new Color32(202, 214, 31, 0);     // dat chua coin
                            AddObject(x+2, y + 4, colors[x, y + 8]);
                        }else
                        {
                            if (demsao < 3)
                            {
                                colors[x, y + 8] = new Color32(202, 160, 0, 0);     // dat chua sao
                                AddObject(x + 2, y + 4, colors[x, y + 8]);
                                demsao += 1;
                            }else
                            {
                                colors[x, y + 8] = new Color32(202, 214, 31, 0);     // dat chua coin
                                AddObject(x + 2, y + 4, colors[x, y + 8]);
                            }
                        }
                        colors[x+4, y + 8] = new Color32(160, 82, 45, 0);     // dat nau
                        AddObject(x+1, y + 4, colors[x+4, y + 8]);
                        break;
                    }
                }
                
            }
        }

        if (demsao < 3 )
        {
            colors[weight-4,12 ] = new Color32(236, 164, 17, 0);       // sao khi Glass cao
            AddObject(weight-9, 8, colors[weight-4,12 ]);
            
        }
        

    }
    
    private int RandomBatKy(int random)
    {
        return UnityEngine.Random.Range(0, random);
    }
    void AddObject(float x, float y, Color color)
    {
		var mapping = Array.Find(tileInfo, m => ColorsAreEqual(m.pixelColor, color));
		if (mapping == null)
		{
			Debug.LogWarning("No tile mapping found at x" + x + "y" + y + " for color " + color);
			return;
		}
		var tile = mapping.tilePrefab == null
				? missingTilePrefab
				: mapping.tilePrefab;
		RenderTile(tile, new Vector2(x - 11f, y - 5f));
	}
	
	
	void RenderTile(GameObject tilePrefab, Vector3 position)
	{
		if (tilePrefab == null)
		{
			Debug.LogWarning("No tile prefab found for position " + position);
			return;
		}

		// render at xy position without rotation
		// and add a child to the parent transform
		var tile = Instantiate(tilePrefab, position, Quaternion.identity, parentObject);
		tile.layer = tileLayer;
	}

	bool ColorsAreEqual(Color a, Color b)
	{

		// if no threshold, must be exact
		if (colorMatchThreshold == 0f)
		{
			return a.Equals(b);
		}

		// compare each RGB color based on a threshold
		// because I've found that some colors tend to be very slightly
		// differnt on occassion
		return Math.Abs(a.r - b.r) <= colorMatchThreshold
			&& Math.Abs(a.g - b.g) <= colorMatchThreshold
			&& Math.Abs(a.b - b.b) <= colorMatchThreshold;
	}
}

