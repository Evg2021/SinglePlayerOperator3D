using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public Transform groundCheck;
    public LayerMask groundMask;

    public float speed = 10f;

    public float gravity = -9.8f; //гравитация

    public float jumpHeight = 3f; //высота прыжка

    public float groundDistance = 0.4f;

    Vector3 velocity; // вектор ускорения

    bool isGrounded; // проверка состояния
   
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // проверка касания уровня земли

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

       

        Vector3 move = transform.right * x + transform.forward * y;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); // реализуем срабатываение гравитации
         
        
        // реализация прыжка
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // реализация приседания
        if (Input.GetKey("c"))
        {
            controller.height = 1f;
        }
        else
        {
            controller.height = 2f;
        }

        // реализация ускорения
        if (Input.GetKey("left shift"))
        {
            speed = 20f;
        }
        else
        {
            speed = 10f;
        }


    }
}
