using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D corpo;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private float vel = 3.0f;

    void Start()
    {
        // Initialize player settings here
        corpo = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        // Handle player input and movement here

        //pega tanto as setinhas quanro a e d
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        corpo.linearVelocity = new Vector2(moveHorizontal * vel, moveVertical * vel);
        anim.SetFloat("speed", Mathf.Abs(moveHorizontal)); // Update animation speed based on horizontal movement
        Flip(moveHorizontal);

        // Pega as teclas pressionadas
        Vector2 movimento = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Envia os parâmetros para a Blend Tree escolher a animação correta (Costas, Frente ou Lado)
        anim.SetFloat("MoveX", movimento.x);
        anim.SetFloat("MoveY", movimento.y);
        anim.SetFloat("speed", movimento.sqrMagnitude);

    }

    //funçao para virar o personagem para a direita ou esquerda dependendo da tecla pressionada
    void Flip(float moveHorizontal)
    {
        

        if (moveHorizontal > 0)
        {
            sprite.flipX = false; // Facing right
        }
        else if (moveHorizontal < 0)
        {
            sprite.flipX = true; // Facing left
        }
    }
}
