using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGroundSpawner : MonoBehaviour
{
    public float spawnRate = 3.1f;
    public GameObject BackGround;
    public GameObject BackGround1;
    float nextSpawn = 0f;
    private List<GameObject> spawnedBackGrounds = new List<GameObject>();

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            Vector3 spawnPosition = new Vector3(22.31f, transform.position.y); // Đặt vị trí X = 18
            GameObject background;

            // Sử dụng Random.Range để spawn ngẫu nhiên giữa MatDat và MatDat2.
            if (Random.Range(0, 2) == 0)
            {
                background = Instantiate(BackGround, spawnPosition, Quaternion.identity);
            }
            else
            {
                background = Instantiate(BackGround1, spawnPosition, Quaternion.identity);
            }

            spawnedBackGrounds.Add(background);

            nextSpawn = Time.time + spawnRate;
        }

        // Kiểm tra và hủy đối tượng khi vị trí X của chúng đạt -18.
        for (int i = spawnedBackGrounds.Count - 1; i >= 0; i--)
        {
            GameObject backGround = spawnedBackGrounds[i];
            if (backGround.transform.position.x <= -22.31f)
            {
                spawnedBackGrounds.Remove(backGround);
                Destroy(backGround);
            }
        }
    }
}
