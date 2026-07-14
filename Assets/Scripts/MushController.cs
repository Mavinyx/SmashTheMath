using UnityEngine;

public class MushController : MonoBehaviour
{
    [SerializeField] private float vel;
    private Transform alvo;
    private Animator anim;
    public int vida = 1;

    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (alvo != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, alvo.position, vel * Time.deltaTime);
        }
    }

    public void LevarDano(int dano)
    {
        vida -= dano;
        if (vida <= 0)
        {
            anim.SetBool("isAlive", false);
            GetComponent<CapsuleCollider2D>().enabled = false;
            Destroy(gameObject, 1.5f);
            this.enabled = false;
        }
    }
}