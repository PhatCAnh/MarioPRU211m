using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrap : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRendererToChangeColor;
    
    public float timer = 4.5f;
    private float count = 0;
    private float fade = 0;

    private bool exploded = false;
    private void Awake() {
        spriteRendererToChangeColor = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!exploded){
            countDown();
        }
        selfDestruct();
    }

    void countDown(){
        if(count <= timer){
            count= count + Time.deltaTime;
        }else{
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            spriteRendererToChangeColor.material.color = Color.red;
            Debug.Log("Explode");
            exploded = true;
            count = 0;
        }
    }

    void selfDestruct(){
        if(exploded){            
            fade=fade + Time.deltaTime;
            if(fade > 2){
                Destroy(this.gameObject);
                Debug.Log("Faded");
            } 
        }
    }
}
