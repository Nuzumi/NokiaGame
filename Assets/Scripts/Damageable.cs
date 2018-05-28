using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damageable : MonoBehaviour {

    public int startingHealthPoint;

    [SerializeField]
    private NativeEvent PlayerHitEvent;

    [SerializeField]
    private Image healthBar;

    public int ActualHealthPoint { get; set; }
    private int actualPercentOfHealth;

    private void Start()
    {
        ActualHealthPoint = startingHealthPoint;
        actualPercentOfHealth = 100;
    }
    
    public void GetDamage(int damage)
    {
        if (PlayerHitEvent != null)
            PlayerHitEvent.Invoke();

        if(damage >= ActualHealthPoint)
        {
            ActualHealthPoint = 0;
            actualPercentOfHealth = 0;
            gameObject.SendMessage("Die");
        }
        else
        {
            ActualHealthPoint -= damage;
            actualPercentOfHealth = (int)ActualHealthPoint * 100 / startingHealthPoint; 
        }

        healthBar.fillAmount = actualPercentOfHealth / 100f;
    }
}
