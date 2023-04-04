using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed;

    Rigidbody2D rb;
    float scaleX;
    Vector2 movement;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        scaleX = GetComponent<Transform>().transform.localScale.x;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //Permet de se déplacer vers la gauche avec la même animation que le déplacement vers la droite
        if(movement.x < 0)
        {
            GetComponent<Transform>().transform.localScale = new Vector2(-scaleX, GetComponent<Transform>().transform.localScale.y);
        }
        else
        {
            GetComponent<Transform>().transform.localScale = new Vector2(scaleX, GetComponent<Transform>().transform.localScale.y);
        }
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * movement);
    }

}
