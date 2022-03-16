using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int currentHealth;
    private int currentHealthBarIndex;



    private void Start()
    {
        currentHealth = UIManager.Instance.HealthBarsLength();
        currentHealthBarIndex = currentHealth - 1;
    }

    public void DecreaseHealth()
    {
        UIManager.Instance.HealthBars[currentHealthBarIndex].SetActive(false);

        currentHealthBarIndex--;
        currentHealth--;

        if (currentHealth <= 0)
        {
            ScoreCounter.Instance.CanCountScore = false;
            if (PlayerPrefs.GetInt(PlayerPrefsKey.BestScore.ToString(),0) < ScoreCounter.Instance.GetScore())
            {
                PlayerPrefs.SetInt(PlayerPrefsKey.BestScore.ToString(),ScoreCounter.Instance.GetScore());
            }

            UIManager.Instance.ShowGameOverScreen();
            GetComponentInChildren<PlayerAnimation>().PlayDead();


        }
    }

    public void IncreaseHealth()
    {
        if(currentHealth==UIManager.Instance.HealthBarsLength())    return;

        currentHealth++;
        currentHealthBarIndex=currentHealth-1;
        UIManager.Instance.HealthBars[currentHealthBarIndex].SetActive(true);


    }
}

public enum PlayerPrefsKey
{
    BestScore,
    None
}
