using UnityEngine;

public class PlayerFinish : MonoBehaviour
{
    //[SerializeField] private AudioClip goalSound;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    void Finish()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().Deactivate();
            //SoundManager.instance.PlaySound(goalSound);
        }
    }
}
