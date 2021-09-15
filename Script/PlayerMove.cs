using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public Transform groundCheck;
    public float gravity = -10f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpPow = 3f;
    Vector3 velocity;
    bool isGrounded;
    public int health = 100;
    public GameObject panelLowHealth;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpPow * -4f * gravity);
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movedir = transform.right * x + transform.forward * z;
        controller.Move(movedir*speed*Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
        if (health <= 20)
        {
            panelLowHealth.SetActive(true);
            speed = 7f;
        }
        else
        {
            panelLowHealth.SetActive(false);
            speed = 12f;
        }
        if (health <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GetDamaged(int dame)
    {
        health -= dame;
    }
}
