using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()   // Перемещение игрока и его поворот в стороны
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
            Flip();
        else if (facingRight == true && moveInput < 0)
            Flip();
    }

    private void Update()        // Прыжок игрока
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            rb.velocity = Vector2.up * jumpForce;
    }

    void Flip()     // Поворот игрока
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
