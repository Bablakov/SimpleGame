using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour // �������� �� ����������� ������
{
    public float speed;              // �������� ������
    public float normalSpeed;

    public float jumpForce;          // ���� ������
    /*private float moveInput;  */       // �������� �� �����������

    /*public Joystick joystick;*/        // �������

    private Rigidbody2D rb;          // ������ ������

    /*private bool facingRight = true;*/ // �������� �� ������� ������

    private bool isGrounded;         // �� ����� �� �����
    public Transform feetPos;        // ���� ������
    public float checkRadius;        // �� ������� ������ ����� ������ ���������� � �����
    public LayerMask whatIsGround;   // ��� �� ������� �� ������

    private Animator anim;           // �������� �� ��������

    private void Start()
    {
        speed = 0f;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()   // ����������� ������ � ��� ������� � �������
    {
        /*moveInput = joystick.Horizontal;*/   // �������� ����� ����������� �� ��������
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if(speed != 0f)
        {
            anim.SetBool("IsRunning", true);
        }

       /*if (facingRight == false && moveInput > 0)   // ���� ���� ���������� �� ������� ������
            Flip();
        else if (facingRight == true && moveInput < 0)
            Flip();

        if (moveInput == 0)    // ���� ���� ���������� �� �������� ����� � ����
            anim.SetBool("IsRunning", false);
        else
            anim.SetBool("IsRunning", true);*/
    }

    private void Update()        // ������ � �������� ������
    {
        /*float verticalMove = joystick.Vertical;*/
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        /*if (isGrounded && verticalMove >= 0.5f*//*Input.GetKeyDown(KeyCode.Space)*//*) // ���� ���� �������� �� ������
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("TakeOf");
        }*/
        if (isGrounded == true)             // ���� ���� �������� �� �������� ������
            anim.SetBool("IsJumping", false);
        else
            anim.SetBool("IsJumping", true);
    }

    public void OnJumpButtonDown() // ������ �� ������
    {
        if (isGrounded) // ���� ���� �������� �� ������
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("TakeOf");
        }
    }

    public void OnLeftButtonDown()
    {
        if (speed >= 0f)
        {
            speed = -normalSpeed;
            transform.eulerAngles = new Vector3(0, 180, 0);
           /* transform.position = transform.position + new Vector3(0.65f, 0, 0);*/
        }
    }

    public void OnRightButtonDown()
    {
        if (speed <= 0f)
        {
            speed = normalSpeed;
            transform.eulerAngles = new Vector3(0, 0, 0);
            /*transform.position = transform.position - new Vector3(0.65f, 0, 0);*/
        }
    }

    public void OnButtonUp()
    {
        speed = 0f;
        anim.SetBool("IsRunning", false);
    }

    /*void Flip()     // ������� ������
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
    }*/
}
