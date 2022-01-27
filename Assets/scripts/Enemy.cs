using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Vector3 dir;

    public GameObject gunShoot;
    public Transform tip;

    public float shootTime;
    private float shootTimer = 0;
    private bool canShoot;

    public LayerMask playerLayer;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = transform.right;
    }

    private void Update()
    {
        
        transform.position = transform.position + speed * dir * Time.deltaTime;
        Shooting();
    }

    private void Shooting()
    {
        ShootTime();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 10f, playerLayer);

        if (hit.collider != null && canShoot)
        {
            GameObject bullet = Instantiate(gunShoot, tip);
            bullet.transform.parent = null;
            canShoot = false;
        }

        Debug.DrawRay(transform.position, Vector2.down * 10f, Color.red);

    }

    private void ShootTime()
    {
        if(shootTimer < shootTime)
            shootTimer += Time.deltaTime;
        else
        {
            shootTimer = 0;
            canShoot = true;
        }
    }

    public void ChangeDir()
    {
        dir *= -1; 
    }




}
