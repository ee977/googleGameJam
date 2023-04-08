using UnityEngine;

namespace ClearSky
{
    public class KarakterKontrol : MonoBehaviour
    {
        [SerializeField]public float movePower = 10f;

        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;
        private bool alive = true;


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                Hurt();
                Die();
                Attack();
                Run();

            }
        }
        
        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            Vector3 moveVelo = Vector3.zero;
            anim.SetBool("isRun", false);

            if (Input.GetAxisRaw("Vertical") < 0)
            {
                moveVelo = Vector3.down;
                anim.SetBool("isRun", true);
            }
            
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                moveVelo = Vector3.up;
                anim.SetBool("isRun", true);
            }

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(direction, 1, 1);
                anim.SetBool("isRun", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1);
                anim.SetBool("isRun", true);

            }
           transform.position += (moveVelocity + moveVelo) * movePower * Time.deltaTime;
        }
     
        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                anim.SetTrigger("attack");
            }
        }
        void Hurt()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-0.4f, 0.1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(0.4f, 0.1f), ForceMode2D.Impulse);
            }
        }
        void Die()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                anim.SetTrigger("die");
                alive = false;
            }
        }
        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                anim.SetTrigger("idle");
                alive = true;
            }
        }
    }
}