using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatdatScroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-2 * Time.deltaTime * Speed, 0);
        //if(transform.position.x < -18)
        //{
        //    transform.position = new Vector3(18f, transform.position.y);
        //}
    }
    public float Speed = 2;
}
