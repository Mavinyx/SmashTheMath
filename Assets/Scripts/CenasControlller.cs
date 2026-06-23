using UnityEngine;
using UnityEngine.SceneManagement; 

public class CenasControlller : MonoBehaviour
{
    [SerializeField] private string nomeDaProximaCena; 
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se quem está em cima do portal é o Player
        if (collision.CompareTag("Player"))
        {
                SceneManager.LoadScene(nomeDaProximaCena);
            
        }
    }
}