using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

//[RequireComponent(typeof(Rigidbody2D))]
public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    public float speed;
    public bool isTouchGround;
    //public Transform groundPoint;
    //public LayerMask mask;
    //public float upForce;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if(Input.GetMouseButton(0)||Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * speed);
        }
        //animator.SetBool("DuoiDat", Physics2D.OverlapCircle(groundPoint.position, 0.1f, mask));
    }
//--- Set Mask ---
    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.DrawWireSphere(groundPoint.position, 0.1f);
    //}

    //void forceUp()
    // {
    //    if (transform.position.y > 3.5f)
    //        transform.position = new Vector2(transform.position.x, 3.5f);
    //    if (Input.GetMouseButton(0)|| Input.GetKey(KeyCode.Space))
    //    {
    //        rb.AddForce(Vector2.up * upForce);  
    //    }
    // }
}
