using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    [SerializeField]
    Transform upperLeftPosition;
    [SerializeField]
    Transform upperRightPosition;
    [SerializeField]
    Transform lowLeftPosition;
    [SerializeField]
    Transform lowRightPosition;
    [SerializeField]
    Transform chebuPerson;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            transform.position = new Vector2(upperLeftPosition.position.x, upperLeftPosition.position.y);
            Flip(0);
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.position = new Vector2(upperRightPosition.position.x, upperRightPosition.position.y);
            Flip(180);
            return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector2(lowLeftPosition.position.x, lowLeftPosition.position.y);
            Flip(0);
            return;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector2(lowRightPosition.position.x, lowRightPosition.position.y);
            Flip(180);
            return;
        }

        //if(horizontalInput > 0 && !isFacingRight) 
        //{
        //    Flip();
        //}
        //else if(horizontalInput < 0 && isFacingRight)
        //{
        //    Flip();
        //}

        //var target = transform.position;
        //float platformHalfSize = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        //// Calculate new position of platform
        //target.x += horizontalInput;
        ////Restrict new position by left and right borders
        //target.x = Mathf.Clamp(target.x, leftBorder.position.x + platformHalfSize, rightBorder.position.x - platformHalfSize);
        //transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void Flip(int rotationDegree)
    {
        Vector3 rotate = transform.eulerAngles;
        rotate.y = rotationDegree;
        chebuPerson.transform.rotation = Quaternion.Euler(rotate);
    }
}
