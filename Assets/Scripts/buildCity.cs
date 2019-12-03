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
                x += Random.Range(3,5);
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
                z += Random.Range(2,20);
                if(z >= mapHeight) break;
            }



            // Generate City
            for (int h = 0; h < mapHeight; h++) {
                for (int w = 0; w < mapWidth; w++) {
                    int result = mapGrid[w,h];
                    if(result < -2) {
                        Vector3 size = crossRoad.GetComponentInChildren<Renderer>().bounds.size;
                        Vector3 streetPos = new Vector3(w * 20, 0, h* 20);
                        Instantiate(crossRoad, streetPos, crossRoad.transform.rotation);
                    }
                    else if (result < -1) {
                        Vector3 size = xStreet.GetComponentInChildren<Renderer>().bounds.size;
                        Vector3 streetPos = new Vector3(w* 20, 0, h* 20);
                        Instantiate(xStreet, streetPos, xStreet.transform.rotation);
                    }
                    else if (result < 0) {
                        Vector3 size = zStreet.GetComponentInChildren<Renderer>().bounds.size;
                        Vector3 streetPos = new Vector3(w* 20,0,h* 20);
                        Instantiate(zStreet, streetPos, zStreet.transform.rotation);
                    }
                    if (result < 1) {
                        Vector3 size = buildings[4].GetComponentInChildren<Renderer>().bounds.size;
                        Vector3 buildingPos = new Vector3(w* size.z,0,h* size.z);
                        Instantiate(buildings[4], buildingPos, Quaternion.identity);
                        }
                    else if (result < 2) {
                        Vector3 size = buildings[3].GetComponentInChildren<Renderer>().bounds.size;
                        Vector3 buildingPos = new Vector3(w * size.x + 5 ,0,h * size.x + 5);
                        Instantiate(buildings[3], buildingPos, Quaternion.identity);
                        }
                    else if (result < 4) {
                        Vector3 size = buildings[2].GetComponentInChildren<Renderer>().bounds.size;
                        Vector3 buildingPos = new Vector3(w * 20,0,h * 20);
                        Instantiate(buildings[2], buildingPos, Quaternion.identity);
                        }
                    else if (result < 6) {
                        Vector3 size = buildings[1].GetComponentInChildren<Renderer>().bounds.size;
                        Vector3 buildingPos = new Vector3(w * 20,0,h * 20);
                        Instantiate(buildings[1], buildingPos, Quaternion.identity);
                        }
                    else if (result < 7) {
                        Vector3 size = buildings[0].GetComponentInChildren<Renderer>().bounds.size;
                        Vector3 buildingPos = new Vector3(w * 20,0,h * 20);
                        Instantiate(buildings[0], buildingPos, Quaternion.identity);
                        }
                    else if (result < 10) {
                        Vector3 size = buildings[5].GetComponentInChildren<Renderer>().bounds.size;
                        Vector3 buildingPos = new Vector3(w * 20,0,h * 20);
                        Instantiate(buildings[5], buildingPos, Quaternion.identity);
                        }
            }
        }
    }
        
}