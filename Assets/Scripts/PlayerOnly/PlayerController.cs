using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float dashTime;
    [SerializeField] float startDashTime;
    [SerializeField] Texture2D gameCursor;
    [SerializeField] GameObject dashParticles;
    [SerializeField] AudioClip playerDash;
    [SerializeField] [Range(0f, 1f)] float playerDashVolume = 0.6f;
    [SerializeField] float shootingMoveSpeedMultiplier = 0.8f;
    //[SerializeField] float dashRefreshTime = 3f;

    //float timeSinceDash = Mathf.Infinity;

    [SerializeField] float projectileSpeed = 8f;
    [SerializeField] float xMin = -10.6f;
    [SerializeField] float xMax = 10.6f;
    [SerializeField] float yMin = -5.85f;
    [SerializeField] float yMax = 5.85f;

    Rigidbody2D rb;
    PlayerStats stats;

    Vector2 movement;
    Vector2 mousePos;
    Vector2 pos;
    Vector2 dashPos;

    bool isDashing = false;

    Color alpha;
    Color normal;


    void Start()
    {
        stats = GetComponent<PlayerStats>();
        alpha = GetComponent<SpriteRenderer>().color;
        alpha.a = 0.35f;
        normal = GetComponent<SpriteRenderer>().color;
        normal.a = 1f;
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        Cursor.SetCursor(gameCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    void Update()
    {
        GetMovement();
        GetMousePosition();
        Rotate();
        HandleDash();
        if (!isDashing) { Move(); }
        //timeSinceDash += Time.deltaTime;
    }

    private void GetMousePosition()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void GetMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (GetComponent<Shooting>().CheckShooting())
        {
            pos = rb.position + movement.normalized * stats.GetMoveSpeed() * shootingMoveSpeedMultiplier * Time.deltaTime;
        }
        else
        {
            pos = rb.position + movement.normalized * stats.GetMoveSpeed() * Time.deltaTime;
        }
        pos.x = Mathf.Clamp(pos.x, xMin, xMax);
        pos.y = Mathf.Clamp(pos.y, yMin, yMax);
    }

    private void Rotate()
    {
        Vector2 lookDirection = (mousePos - rb.position);
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void Move()
    {
        rb.MovePosition(pos);
    }

    private void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //&& timeSinceDash >= dashRefreshTime)
        {
            isDashing = true;
            dashTime = startDashTime;
            dashParticles.SetActive(true);
            AudioSource.PlayClipAtPoint(playerDash, transform.position, playerDashVolume);
        }

        if (isDashing)
        {
            dashPos = rb.position + movement.normalized * stats.GetDashSpeed() * Time.deltaTime;
            dashPos.x = Mathf.Clamp(dashPos.x, xMin, xMax);
            dashPos.y = Mathf.Clamp(dashPos.y, yMin, yMax);
            rb.MovePosition(dashPos);
            dashTime -= Time.deltaTime;
            GetComponent<SpriteRenderer>().color = alpha;
            GetComponent<TrailRenderer>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;

            if(dashTime <= 0)
            {
                isDashing = false;
                GetComponent<SpriteRenderer>().color = normal;
                GetComponent<TrailRenderer>().enabled = true;
                GetComponent<PolygonCollider2D>().enabled = true;
                dashParticles.SetActive(false);
                //timeSinceDash = 0;
            }
        }
    }


}
