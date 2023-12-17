using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour // Отвечает за перемещение игрока
{
    public float speed;              // Скорость игрока
    public float jumpForce;          // Сила прыжка
    private float moveInput;         // Отвечает за перемещение

    private Rigidbody2D rb;          // Физика игрока

    private bool facingRight = true; // Отвечает за поворот игрока

    private bool isGrounded;         // На земле ли игрок
    public Transform feetPos;        // Ноги игрока
    public float checkRadius;        // На сколько близко игрок должен находиться к земле
    public LayerMask whatIsGround;   // Что мы считаем за земллю

    private Animator anim;           // Отвечает за анимации

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()   // Перемещение игрока и его поворот в стороны
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
       
        if (facingRight == false && moveInput > 0)   // Блок кода отвечающий за поворот игрока
            Flip();
        else if (facingRight == true && moveInput < 0)
            Flip();

        if (moveInput == 0)    // Блок кода отвечающий за анимации покоя и бега
            anim.SetBool("IsRunning", false);
        else
            anim.SetBool("IsRunning", true);
    }

    private void Update()        // Прыжок игрока
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) // Блок кода отвечает за прыжок
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("TakeOf");
        }
        if (isGrounded == true)             // Блок кода отвечает за анимацию прыжка
            anim.SetBool("IsJumping", false);
        else
            anim.SetBool("IsJumping", true);
    }

    void Flip()     // Поворот игрока
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.position = transform.position + new Vector3(0.65f, 0, 0);
        }
            
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position = transform.position - new Vector3(0.65f, 0, 0);
        }
    }
}
