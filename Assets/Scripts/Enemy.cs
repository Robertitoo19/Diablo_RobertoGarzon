using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, Idamagable
{
    [SerializeField] private float initialLifes;

    [SerializeField] private GameObject canvas;

    [SerializeField] private Image healthBar;

    [SerializeField] private Collider coll;

    [SerializeField] private EnemyAnims enemyVisual;

    [SerializeField] private Texture2D defaultIcon;
    [SerializeField] private Texture2D interactIcon;

    private PatrolSystem patroll;
    private CombatSystem combat;
    private Transform target;

    private float actualLifes;
    private bool isDeath;
    public PatrolSystem Patroll { get => patroll; set => patroll = value; }
    public CombatSystem Combat { get => combat; set => combat = value; }
    public Transform Target { get => target; set => target = value; }

    private void Awake()
    {
        actualLifes = initialLifes;
    }
    void Start()
    {
        patroll.enabled = true;
    }
    void Update()
    {
        
    }
    public void ActiveCombat(Transform target) 
    {
        //Definir el target
        this.target = target;

        combat.enabled = true;
    }
    public void ActivePatroll()
    {
        combat.enabled = false;
        patroll.enabled = true;
    }

    public void ReceiveDamage(float enemyDamage)
    {
        if (isDeath)
        {
            return;
        }

        actualLifes -= enemyDamage;
        healthBar.fillAmount = actualLifes / initialLifes;
        if (actualLifes <= 0)
        {
            isDeath = true;
            Death();
        }
    }
    private void Death()
    {
        Destroy(canvas);
        Destroy(coll);
        Destroy(combat);
        Destroy(patroll.gameObject);
        Destroy(gameObject,3);
        enemyVisual.DeathAnim();
    }
    private void OnMouseEnter()
    {
        Cursor.SetCursor(interactIcon, Vector2.zero, CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(defaultIcon, Vector2.zero, CursorMode.Auto);
    }
}
