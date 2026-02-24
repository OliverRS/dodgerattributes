using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    [SerializeField] inputsystem inputsystem;
    
    public DodgerAttributes dodgerAttributes;
    [SerializeField] private int startMaxhealth = 5;
    [SerializeField] private int startscore = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        dodgerAttributes = new DodgerAttributes(
            startMaxhealth,
            startMaxhealth,
            startscore
        );
    }

    void Update()
    {
        int moveDir = 0;

        Vector2 screenPos;

        if (inputsystem.IsPressing(out screenPos))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 0f));

            if(touchPos.x < 0)
            {
                moveDir =-1;
            }
            
            else
            {
                moveDir =1;
            }

        }
            Vector3 viewportPos = Camera.main.WorldToViewportPoint(rb.position);

            if ((viewportPos.x <= 0f && moveDir < 0f) || (viewportPos.x>=1f && moveDir >0f))
            {
                moveDir =0;
            }
            
            rb.linearVelocityX = moveDir * moveSpeed;

        }


            private void OnCollisionEnter2D(Collision2D collision)
            {
                if (collision.gameObject.CompareTag("Enemy"))
                {
                    SceneManager.LoadScene(0);
                }
        
            }   

 }
    


