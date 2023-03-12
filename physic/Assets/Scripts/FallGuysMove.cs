using UnityEngine;

public class FallGuysMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    private Vector3 startPosition;
    Animator anim; 
    Rigidbody rb;
    Vector3 direction;
    bool isGrounded;
    bool slide;

    void Start()
    {
        GetComponent<AudioSource>().Play();
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); 
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = transform.TransformDirection(x, 0, z);

        if (transform.position.y < -10)
        {
            transform.position = startPosition;
        }
        
        if (direction.magnitude > 0)
        {
            anim.SetBool("Run", true);
        }
        else anim.SetBool("Run", false);
        
        if(isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {                
                rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            }
        }      

        if(slide)
        {
            rb.AddForce(direction * 0.03f, ForceMode.VelocityChange);
        }

    }
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other != null)
        {
            isGrounded = true;
        }
        else slide = false;
    }
    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
        if (other.gameObject.CompareTag("slide"))
        {
            slide = true;
        }
else slide = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Plate"))
        {
            Destroy(other.gameObject);
        }
          if (other.CompareTag("Checkpoint"))
        {
            startPosition = transform.position;
        }
    }
}