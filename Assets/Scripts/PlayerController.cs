using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller; //komponente ekledigimiz karakter controller
    private Vector3 direction; //yon tanimliyoruz
    public float forwardSpeed; //ileri hizi

    private int desiredLane = 1; //0:left 1:middle 2:right //istenen serit
    public float laneDistance = 2.5f; // 2 serit arasi mesafe

    public float jumpForce; //ziplama gucu
    public float Gravity = -20; //yercekimi

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(!PlayerManager.isGameStarted)
            return;
        
        direction.z = forwardSpeed; //z eksenindeki ileri hizimiz

        
        if (controller.isGrounded) //ustuste ziplamasini engeller
        {
            
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }


        if (SwipeManager.swipeRight)
        {
            desiredLane++; //lane'i arttir
            if (desiredLane == 3)
            {
                desiredLane = 2; //sag lane gecer
            }
        }

        if (SwipeManager.swipeLeft)
        {
            desiredLane--; //lane azalt
            if (desiredLane == -1)
            {
                desiredLane = 0; //sol lane gecer
            }
        }

        //hedef pozisyonumuz icin 
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        // transform.position = targetPosition; //hedef pozisyonumuzu, transform pozisyon konumuna atiyoruz.
      /*  transform.position = Vector3.Lerp(transform.position, targetPosition, 400 * Time.deltaTime);
        controller.center = controller.center; //degmeme bug cozumu */
      if (transform.position == targetPosition)
      {
          return;
      }

      Vector3 diff = targetPosition - transform.position;
      Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
      if (moveDir.sqrMagnitude < diff.sqrMagnitude)
      {
          controller.Move(moveDir);
      }
      else
      {
          controller.Move(diff);
      }

    }

    private void FixedUpdate()
    {
        if(!PlayerManager.isGameStarted)
            return;
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce; //y yonunde ziplama gucu kadar ziplar
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }
}