using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int numPlayers;
    public int numStars;

    public int width = 30;
    public int height = 16;

    public float minStarDistance;
    public float minHomeworldDistance;

    public GameObject starPrefab;
    public GameObject planetPrefab;
    public List<Material> playerMaterials;

    private List<GameObject> stars = new List<GameObject>();

    public void Generate()
    {
        List<Vector3> coords = new List<Vector3>();
        for (int i = 0; i < numStars; ++i)
        {
            Vector3 coord = Vector3.zero;

            bool good = false;
            while (!good)
            {
                good = true;

                float randX = Random.Range(0, width * 2) - width;
                float randY = Random.Range(0, height * 2) - height;
                coord = new Vector3(randX, randY, 0);

                for (int j = 0; j < coords.Count; ++j)
                {
                    if (Vector3.Distance(coord, coords[j]) < minStarDistance)
                    {
                        good = false;
                        break;
                    }
                }
            }

            coords.Add(coord);
            GameObject star = Instantiate(starPrefab, coord, Quaternion.identity);
            stars.Add(star);
        }
    }

    public void AssignHomeworlds()
    {
        List<GameObject> playerHomeworlds = new List<GameObject>();
        for (int i = 0; i < numPlayers; ++i)
        {
            int randIndex = -1;

            bool good = false;
            while (!good)
            {
                good = true;

                randIndex = Random.Range(0, numStars);
                for (int j = 0; j < i; ++j)
                {
                    if (Vector3.Distance(stars[randIndex].transform.position, playerHomeworlds[j].transform.position) < minHomeworldDistance)
                    {
                        good = false;
                        break;
                    }
                }
            }

            MeshRenderer meshRenderer = stars[randIndex].GetComponent<MeshRenderer>();
            meshRenderer.material = playerMaterials[i];
            playerHomeworlds.Add(stars[randIndex]);
        }
    }
}
