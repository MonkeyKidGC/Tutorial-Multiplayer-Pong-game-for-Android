using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody= GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movement();
    }

    private void movement()
    {
        foreach (Touch touch in Input.touches)
        {
            Vector3 touchPos =  Camera.main.ScreenToWorldPoint (touch.position);
            Vector2 myPosition = gameObject.GetComponent<Rigidbody2D> ().position;
            if(Mathf.Abs(touchPos.x - myPosition.x) <= 2) 
            {
                myPosition.y = Mathf.Lerp (myPosition.y, touchPos.y, 10);
                myPosition.y = Mathf.Clamp(myPosition.y, -3.7f, 3.7f);
                gameObject.GetComponent<Rigidbody2D> ().position  = myPosition; 
            } 
        }
    }
}
