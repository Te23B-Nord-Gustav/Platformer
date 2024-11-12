using Unity.VisualScripting;
using UnityEngine;

public class playercontroller : MonoBehaviour
{   
    // GUBBENS RÖRLIGHET ELLLLER FYSIK JAG VENNE
    [SerializeField]
    float jumpforce = 10;

    bool mayJump = true;

    [SerializeField]
    Transform groundChecker;

    [SerializeField]
    Transform groundChecker1;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    float moveSpeed;

    // SNÖBOL SKUTARE TYPE SHIT
    [SerializeField]
    float timeBetweenShots = 0.5f;
    float timeSinceLastShot = 0;
    // KNSK INTE FUNKAR NU
    [SerializeField]
    GameObject skottbild;

    [SerializeField]
    Transform gunposition;

    void Update()
    {
        
        float xMove = Input.GetAxisRaw("Horizontal");

        //transform.Translate(Vector3.right * xMove * Time.deltaTime); // Annan lösning till rörelse höger och vänster


        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        
        rb.velocity = new Vector2(
            xMove * moveSpeed,
            rb.velocity.y
        );



        if (Input.GetAxisRaw("Jump") > 0 && mayJump == true && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpforce);
            mayJump = false;

        }

        if (Input.GetAxisRaw("Jump") == 0)
        {
            mayJump = true;
        }
        if (rb.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (rb.velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        // skottgrejer

        timeSinceLastShot += Time.deltaTime;

        if (Input.GetAxisRaw("Fire1") > 0 && timeSinceLastShot > timeBetweenShots)    
        {    
        timeSinceLastShot = 0;
        Instantiate(skottbild, gunposition.position, Quaternion.identity);
        }


    }

    private bool IsGrounded()
    {   
        if (Physics2D.OverlapCircle(groundChecker.position, .2f,groundLayer) || Physics2D.OverlapCircle(groundChecker1.position, .2f,groundLayer))
        {
            return true;
        }



        else
        {
            return false;
        }
    }

}