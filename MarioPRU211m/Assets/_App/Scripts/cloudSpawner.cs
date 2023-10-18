using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudSpawner : MonoBehaviour
{
    public float spawnRate = 15;
    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;
    public float spawnYRange = 1.66f; // Phạm vi ngẫu nhiên cho vị trí Y
    float nextSpawn = 0f;
    private List<GameObject> spawnedClouds = new List<GameObject>();

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            // Tạo một vị trí spawn với vị trí X không đổi và vị trí Y ngẫu nhiên trong phạm vi spawnYRange.
            Vector3 spawnPosition = new Vector3(15.29f, transform.position.y + Random.Range(4.2f, spawnYRange), 0);
            GameObject clouds;

            // Sử dụng Random.Range để spawn ngẫu nhiên giữa cloud1, cloud2, và cloud3.
            int randomCloud = Random.Range(0, 3);
            if (randomCloud == 0)
            {
                clouds = Instantiate(cloud1, spawnPosition, Quaternion.identity);
            }
            else if (randomCloud == 1)
            {
                clouds = Instantiate(cloud2, spawnPosition, Quaternion.identity);
            }
            else
            {
                clouds = Instantiate(cloud3, spawnPosition, Quaternion.identity);
            }
            spawnedClouds.Add(clouds);
            nextSpawn = Time.time + spawnRate;
        }
        // Kiểm tra và hủy đối tượng khi vị trí X của chúng đạt -24.22.
        for (int i = spawnedClouds.Count - 1; i >= 0; i--)
        {
            GameObject cloudsobj = spawnedClouds[i];
            if (cloudsobj.transform.position.x <= -24.22)
            {
                spawnedClouds.Remove(cloudsobj);
                Destroy(cloudsobj);
            }
        }
    }
}
