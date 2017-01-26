using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    public float m_StartingHealth = 100f;          
    public Slider m_Slider;                        
    public Image m_FillImage;                      
    public Color m_FullHealthColor = Color.green;  
    public Color m_ZeroHealthColor = Color.red;    

    public float m_CurrentHealth;
    public bool m_Dead;
    float immunityTimeLeft;

    public float immunityTime = 2f;




    private void OnEnable()
    {
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;

        SetHealthUI();
    }
    

    public float TakeDamage(float amount)
    {
        if (immunityTimeLeft <= 0)
        {
            // Adjust the current health, update the UI based on the new health and check whether or not the tank is dead.
            m_CurrentHealth -= amount;
            SetHealthUI();
            if (m_CurrentHealth <= 0f && !m_Dead)
            {
                OnDeath();
            }
            else
            {
                immunityTimeLeft = immunityTime;
               
            }
        }
        return m_CurrentHealth;
    }


    private void SetHealthUI()
    {
        // Adjust the value and colour of the slider.
        m_Slider.value = m_CurrentHealth;
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
    }


    private void OnDeath()
    {
        // Play the effects for the death of the it and deactivate it.
        m_Dead = true;
    }

    void Update()
    {
        if (immunityTimeLeft > 0)
        {
            immunityTimeLeft -= Time.deltaTime;

        }
    }
}