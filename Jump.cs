using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public playerMovement character;
    void Start()
    {
        character= GetComponentInParent<playerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("isTouchGround"))
        {
            Debug.Log("cham dat r ne");
            character.animator.SetBool("DuoiDat", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("isTouchGround"))
        {
            character.animator.SetBool("DuoiDat", false);
            Debug.Log("het cham dat r ne");
        }
    }


}
