using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Vector3 dir;

    public GameObject gunShoot;
    public Transform tip;
    public float speedMultiplyer = 1;

    public float shootTime;
    private float shootTimer = 0;
    private bool canShoot;
    public LineRenderer line;

    public LayerMask playerLayer;

    private void Start()
    {
        dir = transform.right;
    }

    private void Update()
    {   
        transform.position = transform.position + speed * speedMultiplyer * dir * Time.deltaTime;
        Shooting();
    }

    private void Shooting()
    {
        ShootTime();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 10f, playerLayer);

        if (hit.collider != null )
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Destroy(hit.collider.gameObject);
            }

            line.SetPosition(0,transform.position  );
            line.SetPosition(1, hit.point  );

            //GameObject bullet = Instantiate(gunShoot, tip);
            //bullet.transform.parent = null;
            //canShoot = false;
        }

        //Debug.DrawRay(transform.position, Vector2.down * 10f, Color.red);
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
