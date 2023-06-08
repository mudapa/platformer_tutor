using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public GameObject[] healthUI;

    void TakeDamage()
    {
        health--;
        if(health <= 0)
        {
            health = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        healthUI[health].SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage();
        }
        else if (collision.CompareTag("Spikes"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
