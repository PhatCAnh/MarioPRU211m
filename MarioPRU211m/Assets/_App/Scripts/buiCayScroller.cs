using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buiCayScroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-3 * Time.deltaTime * Speed, 0);
        if(transform.position.x < -28.9)
        {
            transform.position = new Vector3(16.83f, transform.position.y);
        }
    }
    public float Speed = 1;
}
