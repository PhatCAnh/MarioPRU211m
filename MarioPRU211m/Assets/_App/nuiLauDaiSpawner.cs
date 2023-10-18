using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuiLauDaiSpawner : MonoBehaviour
{
    public float spawnRate = 15;
    public GameObject nuiTo;
    public GameObject nuiNho;
    public GameObject lauDai1;
    public GameObject lauDai2;
    float nextSpawn = 0f;
    private List<GameObject> spawnedNuiLauDai = new List<GameObject>();

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            // Tạo một vị trí spawn với vị trí X không đổi và vị trí Y ngẫu nhiên trong phạm vi spawnYRange.
            Vector3 spawnPosition = new Vector3(10.29f, transform.position.y, 0);
            GameObject nuiLauDai;

            // Sử dụng Random.Range để spawn ngẫu nhiên giữa cloud1, cloud2, và cloud3.
            int randomNuiLauDDai = Random.Range(0, 3);
            if (randomNuiLauDDai == 0)
            {
                nuiLauDai = Instantiate(nuiTo, spawnPosition, Quaternion.identity);
            }
            else if (randomNuiLauDDai == 1)
            {
                nuiLauDai = Instantiate(nuiNho, spawnPosition, Quaternion.identity);
            }
            else if (randomNuiLauDDai == 2)
            {
                nuiLauDai = Instantiate(lauDai1, spawnPosition, Quaternion.identity);
            }
            else
            {
                nuiLauDai = Instantiate(lauDai2, spawnPosition, Quaternion.identity);
            }
            spawnedNuiLauDai.Add(nuiLauDai);
            nextSpawn = Time.time + spawnRate;
        }
        // Kiểm tra và hủy đối tượng khi vị trí X của chúng đạt -24.22.
        for (int i = spawnedNuiLauDai.Count - 1; i >= 0; i--)
        {
            GameObject nuiLauDaiobj = spawnedNuiLauDai[i];
            if (nuiLauDaiobj.transform.position.x <= -20.22)
            {
                spawnedNuiLauDai.Remove(nuiLauDaiobj);
                Destroy(nuiLauDaiobj);
            }
        }
    }
}