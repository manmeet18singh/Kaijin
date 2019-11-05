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
    int buildingSize = 20;

    // Start is called before the first frame update
    void Start()
    {
        // seed will allow us to create a random perlin noise map
        float seed = Random.Range(0, 100);

        // randomly instantiate a building in each grid location from the list given. 
        for (int h = 0; h < mapHeight; h++) {
            for (int w = 0; w < mapWidth; w++) {
                Vector3 pos = new Vector3(w * buildingSize,0,h * buildingSize);

                // Use perlin noise to make a more realistic cityscape
                int perlin = (int) (Mathf.PerlinNoise(w/10.0f + seed , h/10.0f + seed) * 10);
                if (perlin < 2) {
                    Instantiate(buildings[4], pos, Quaternion.identity);
                }
                else if (perlin < 4) {
                    Instantiate(buildings[3], pos, Quaternion.identity);
                }
                else if (perlin < 6) {
                    Instantiate(buildings[2], pos, Quaternion.identity);
                }
                else if (perlin < 7) {
                    Instantiate(buildings[1], pos, Quaternion.identity);
                }
                else if (perlin < 8) {
                    Instantiate(buildings[0], pos, Quaternion.identity);
                }
                else if (perlin < 10) {
                    Instantiate(buildings[5], pos, Quaternion.identity);
                }
            }
        }
        
    }

}
