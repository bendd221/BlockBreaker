using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Paddle paddle;
    [SerializeField] float pushX = 2f;
    [SerializeField] float pushY = 15f;
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted) 
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        
    }

    private void LockBallToPaddle() {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnMouseClick() {
        if(Input.GetMouseButtonDown(0)) 
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(pushX, pushY);
        }
    }
}
