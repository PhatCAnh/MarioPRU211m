using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTrapScript : MonoBehaviour
{
    public float RotatingSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotating();
    }

    void Rotating(){
        transform.Rotate(new Vector3(0, 0, RotatingSpeed) * Time.deltaTime);
    }


}
