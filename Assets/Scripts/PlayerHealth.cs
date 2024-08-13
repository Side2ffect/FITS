using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private Canvas healthCanvas;
    [SerializeField] private int maxHealth;
    private int currentHealth;
    private bool immuneDamage = false;
    private float immuneTime = 3.0f;
    private Stack<RectTransform> emptyHearts = new Stack<RectTransform>();
    private Stack<RectTransform> fullHearts = new Stack<RectTransform>();

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        RectTransform tempHeart = null;
        for (int i = 0; i < maxHealth; i++)
        {
            tempHeart = Instantiate(heartPrefab, healthCanvas.transform).GetComponent<RectTransform>();
            tempHeart.anchoredPosition = new Vector2(10 + (85 * i), -10);
            fullHearts.Push(tempHeart.GetChild(0).GetComponent<RectTransform>());
        }
    }

    private void Update()
    {
        if (immuneDamage)
        {
            ResetImmuneTime();
        }
        if (!immuneDamage && Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Heal(1);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Death();
        }
    }

    private void TakeDamage()
    {
        currentHealth--;
        RectTransform tempHeart = fullHearts.Pop();
        tempHeart.gameObject.SetActive(false);
        emptyHearts.Push(tempHeart);
        immuneDamage = true;

        if(currentHealth == 0)
        {
            Death();
        }
    }

    private void Heal(int healthRestored)
    {
        RectTransform tempHeart = null;
        for (int i = 0; i < healthRestored; i++)
        {
            if(emptyHearts.Count == 0)
            {
                break;
            }
            else
            {
                tempHeart = emptyHearts.Pop();
                tempHeart.gameObject.SetActive(true);
                fullHearts.Push(tempHeart);
            }
        }
    }

    private void Death()
    {
        FindObjectOfType<GameManager>().EndGame();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spike"))
        {
            TakeDamage();
        }

        if(other.CompareTag("HealthRestore"))
        {
            Destroy(other.gameObject);
            Heal(1);
        }

        if (other.CompareTag("DeadZone"))
        {
            Debug.Log("Dead");
            Death();
        }
    }

    private void ResetImmuneTime()
    {
        immuneTime -= Time.deltaTime;
        if(immuneTime <= 0.0f)
        {
            immuneDamage = false;
            immuneTime = 3.0f;
        }
    }
}
