using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed; // Speed of platform movement

    [SerializeField]
    Transform leftBorder;
    [SerializeField]
    Transform rightBorder;

    private bool isFacingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // Get horizontal input

        if(horizontalInput > 0 && !isFacingRight) 
        {
            Flip();
        }
        else if(horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }

        var target = transform.position;
        float platformHalfSize = GetComponent<PolygonCollider2D>().bounds.size.x / 2;
        // Calculate new position of platform
        target.x += horizontalInput;
        //Restrict new position by left and right borders
        target.x = Mathf.Clamp(target.x, leftBorder.position.x + platformHalfSize, rightBorder.position.x - platformHalfSize);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
