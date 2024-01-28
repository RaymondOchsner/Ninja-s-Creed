using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startHealth;
    public float currentHealth { get; private set; }
    private Animator animator;
    private bool dead;
    private ManageUI uiManager;
    

    private void Awake()
    {
        currentHealth = startHealth;
        animator = GetComponent<Animator>();
        uiManager = FindObjectOfType<ManageUI>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth);

        if (currentHealth > 0)
        {
            animator.SetTrigger("damaged");
        }
        else
        {
            if (!dead)
            {
                animator.SetTrigger("dying");
                if(GetComponent<MovementPlayer>() != null)
                {
                    GetComponent<MovementPlayer>().enabled = false;
                    uiManager.GameOver();
                }
                
                if(GetComponent<Enemy>() != null)
                {
                    GetComponent<Enemy>().enabled = false;
                }
                dead = true;
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startHealth);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
