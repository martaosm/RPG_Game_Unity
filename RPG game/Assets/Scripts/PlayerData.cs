using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public int questNumber;
    public float DialogueNumber;
    [Header("PlayerStats")] public float MaxHealth;
    public float curHealth;

    [Header("UIComponents")] public Slider HealthSlider;

    public void Start()
    {
        HealthSlider.maxValue = MaxHealth;
        curHealth = MaxHealth;
        HealthSlider.value = curHealth;
    }

    public void TakeDamage(float Damage)
    {
        curHealth -= Damage;
        if (curHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        HealthSlider.value = curHealth;
    }

    public void Heal(float Health)
    {
        curHealth += Health;
        if (curHealth > MaxHealth)
        {
            curHealth = MaxHealth;
        }
        HealthSlider.value = curHealth;
    }

}
