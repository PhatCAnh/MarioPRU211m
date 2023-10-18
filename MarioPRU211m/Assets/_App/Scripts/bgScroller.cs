using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgScroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-5 * Time.deltaTime * Speed, 0);
        if (transform.position.x < -22.14)
        {
            transform.position = new Vector3(15.03f, transform.position.y, 0);
        }
    }
    public float Speed = 0.1f;
}
