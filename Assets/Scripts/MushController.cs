using UnityEngine;

public class MushController : MonoBehaviour
{
    [SerializeField] private float vel;
    private Transform alvo;
    
    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        if (alvo != null)
        {
        
            transform.position = Vector2.MoveTowards(transform.position, alvo.position, vel * Time.deltaTime);
        }
    }
}