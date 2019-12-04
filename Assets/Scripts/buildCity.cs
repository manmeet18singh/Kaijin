// Manmeet Singh
// DMS 423 Programming Graphics 1 Assignment: KAIJIN

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildCity : MonoBehaviour
{
    public GameObject[] buildings;
    public int mapWidth = 20;
    public int mapHeight = 20;
    public GameObject xStreet;
    public GameObject zStreet;
    public GameObject crossRoad;
    private int[,] mapGrid;
    int footprint = 3;

    // Start is called before the first frame update
    void Start()
    {
        mapGrid = new int[mapWidth, mapHeight];
        // seed will allow us to create a random perlin noise map
        float seed = Random.Range(0, 100);

        // randomly instantiate a building in each grid location from the list given. 
        for (int h = 0; h < mapHeight; h++) {
            for (int w = 0; w < mapWidth; w++) {
                // Use perlin noise to make a more realistic cityscape and save into mapGrid 
                int perlin = (int) (Mathf.PerlinNoise(w/10.0f + seed , h/10.0f + seed) * 10);
                mapGrid[w,h] = perlin;
            }
        }
            // Build Streets
            int x = 0;
            for(int n = 0; n < 50; n++) {
                for(int h = 0; h < mapHeight; h++) {
                    mapGrid[x,h] = -1;
                }
                x += Random.Range(3,3);
                if(x >= mapWidth) break;
            }

            // cross roads 
            int z = 0;
            for(int n = 0; n < 10; n++) {
                for(int w = 0; w < mapWidth; w++) {
                    if(mapGrid[w,z] == -1){
                        // place Cross Road
                        mapGrid[w,z] = -3;
                        }
                    else{
                        mapGrid[w,z] = -2;
                    }
                }
                z += Random.Range(5,20);
                if(z >= mapHeight) break;
            }

            // Generate City
            for (int h = 0; h < mapHeight; h++) {
                for (int w = 0; w < mapWidth; w++) {
                    int result = mapGrid[w,h];
                    Vector3 pos = new Vector3(w * footprint, 0, h * footprint);
                    if(result < -2) {
                        Instantiate(crossRoad, pos, crossRoad.transform.rotation);
                    }
                    else if (result < -1) {
                        Instantiate(xStreet, pos, xStreet.transform.rotation);
                    }
                    else if (result < 0) {
                        Instantiate(zStreet, pos, zStreet.transform.rotation);
                    }
                    else if (result < 1) {
                        Instantiate(buildings[0], pos, Quaternion.identity);
                        }
                    else if (result < 2){
                        Instantiate(buildings[1], pos, Quaternion.identity);
                        }
                    else if (result < 4) {
                        Instantiate(buildings[2], pos, Quaternion.identity);
                        }
                    else if (result < 6) {
                        Instantiate(buildings[3], pos, Quaternion.identity);
                        }
                    else if (result < 7) {
                        Instantiate(buildings[4], pos, Quaternion.identity);
                        }
                    else if (result < 10) {
                        Instantiate(buildings[5], pos, Quaternion.identity);
                        }
            }
        }
    }
        
}