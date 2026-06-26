using UnityEngine;

// Ver se o ataque ta com hitbox pros dois lado
// transformar esses valores avulsos em constante
// incrementar a macaninca pra qnd o inimigo estiver com vida em 1, pausa e fazer UI
public class PlayerController : MonoBehaviour
{

    // Variáveis privadas para armazenar referências aos componentes do jogador
    private Rigidbody2D corpo;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private float vel = 3.0f;

    //Variaveis para controlar o ataque do jogador
    [SerializeField] private Transform attackArea;
    private float alcanceAtque= 0.5f;
    private int danoAtaque = 1;
    [SerializeField] private LayerMask camadaInimigo;

    void Start()
    {
        // Initialize player settings here
        corpo = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
      
    //--------------------MOVIMENTO DO JOGADOR--------------------
        //pega tanto as setinhas quanro a e d
        MovimentoPlayer();

    //--------------------ATAQUE DO JOGADOR--------------------
        AtaquePlayer();

    }

    //função para controlar o ataque do jogador
    void AtaquePlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Attack");
            //Physics2D.OverlapCircleAll faz com que a unity desenhe um circulo na tela e detecte todos os inimigos dentro desse circulo, nesse caso o circulo é desenhado na posição do objeto attackArea, com o raio de alcanceAtque e apenas na camada camadaInimigo
            Collider2D[] inimigos = Physics2D.OverlapCircleAll(attackArea.position, alcanceAtque, camadaInimigo);
            foreach (Collider2D inimigo in inimigos)
            {
                var inimigoScript = inimigo.GetComponent<MushController>();
                if (inimigoScript != null)
                {
                    inimigoScript.LevarDano(danoAtaque);
                }
            }
        }
   
    }

    //função para controlar o movimento do jogador
    void MovimentoPlayer()
    {
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
