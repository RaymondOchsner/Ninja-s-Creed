using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    //[SerializeField] private AudioClip heartSound;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    void Remove()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(collision.GetComponent<Health>().currentHealth != 5)
            {
                collision.GetComponent<Health>().AddHealth(1);
            //SoundManager.instance.PlaySound(heartSound);
            Remove();
            }
        }
    }
}
