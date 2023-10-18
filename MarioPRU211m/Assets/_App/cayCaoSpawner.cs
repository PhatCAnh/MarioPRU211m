using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cayCaoSpawner : MonoBehaviour
{
    public float spawnRate = 15;
    public GameObject cayCao1;
    public GameObject cayCao2;
    public GameObject cayCaoTrang1;
    public GameObject cayCaoTrang2;
    float nextSpawn = 0f;
    private List<GameObject> spawnedcayCao = new List<GameObject>();

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            // Tạo một vị trí spawn với vị trí X không đổi và vị trí Y ngẫu nhiên trong phạm vi spawnYRange.
            Vector3 spawnPosition = new Vector3(15.29f, transform.position.y , 0);
            GameObject cayCao;

            // Sử dụng Random.Range để spawn ngẫu nhiên giữa cloud1, cloud2, và cloud3.
            int randomcayCao = Random.Range(0, 3);
            if (randomcayCao == 0)
            {
                cayCao = Instantiate(cayCao1, spawnPosition, Quaternion.identity);
            }
            else if (randomcayCao == 1)
            {
                cayCao = Instantiate(cayCao2, spawnPosition, Quaternion.identity);
            }
            else if (randomcayCao == 2) 
            {
                cayCao = Instantiate(cayCaoTrang1, spawnPosition, Quaternion.identity);
            }
            else
            {
                cayCao = Instantiate(cayCaoTrang2, spawnPosition, Quaternion.identity);
            }
            spawnedcayCao.Add(cayCao);
            nextSpawn = Time.time + spawnRate;
        }
        // Kiểm tra và hủy đối tượng khi vị trí X của chúng đạt -24.22.
        for (int i = spawnedcayCao.Count - 1; i >= 0; i--)
        {
            GameObject cayCaoobj = spawnedcayCao[i];
            if (cayCaoobj.transform.position.x <= -24.22)
            {
                spawnedcayCao.Remove(cayCaoobj);
                Destroy(cayCaoobj);
            }
        }
    }
}