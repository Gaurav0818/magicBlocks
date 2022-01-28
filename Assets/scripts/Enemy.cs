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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 10f, playerLayer);

        if (hit.collider != null )
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Destroy(hit.collider.gameObject);
                FindObjectOfType<GameFlowController>().EndGame();
            }

            line.SetPosition(0,transform.position  );
            line.SetPosition(1, hit.point  );

            //GameObject bullet = Instantiate(gunShoot, tip);
            //bullet.transform.parent = null;
            //canShoot = false;
        }
    }

    public void ChangeDir()
    {
        dir *= -1; 
    }
}
