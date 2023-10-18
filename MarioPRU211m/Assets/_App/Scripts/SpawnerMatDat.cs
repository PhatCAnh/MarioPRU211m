using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMatDat : MonoBehaviour
{
    public float spawnRate = 3.1f;
    public GameObject matDat1;
    public GameObject matDat2;
    public GameObject matDat3;
    float nextSpawn = 0f;
    private List<GameObject> spawnedMatDats = new List<GameObject>();

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            Vector3 spawnPosition = new Vector3(15.29f, transform.position.y); // Đặt vị trí X = 18
            GameObject matDat;

            // Sử dụng Random.Range để spawn ngẫu nhiên giữa MatDat và MatDat2.
            if (Random.Range(0, 3) == 0)
            {
                matDat = Instantiate(matDat1, spawnPosition, Quaternion.identity);
            }
            else if (Random.Range(0, 3) == 1)
            {
                matDat = Instantiate(matDat2, spawnPosition, Quaternion.identity);
            }
            else
            {
                matDat = Instantiate(matDat3, spawnPosition, Quaternion.identity);
            }
            spawnedMatDats.Add(matDat);
            nextSpawn = Time.time + spawnRate;
        }
        // Kiểm tra và hủy đối tượng khi vị trí X của chúng đạt -18.
        for (int i = spawnedMatDats.Count - 1; i >= 0; i--)
        {
            GameObject matDat = spawnedMatDats[i];
            if (matDat.transform.position.x <= -24.22)
            {
                spawnedMatDats.Remove(matDat);
                Destroy(matDat);
            }
        }
    }
}
