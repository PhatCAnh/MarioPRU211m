using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuiScroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-3 * Time.deltaTime * Speed, 0);
        if (transform.position.x < -23.9)
        {
            transform.position = new Vector3(23.47f, transform.position.y);
        }
    }
    public float Speed = 3;
}

