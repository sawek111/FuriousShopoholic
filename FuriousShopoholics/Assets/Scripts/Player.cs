using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private const int MAX_STAMINA = 150;

    [SerializeField] private Transform _transform = null;
    [SerializeField] private AudioSource _source = null;

    [SerializeField] private AudioClip _clipToPlay = null;

    private bool _isAttacking = false;
    private bool _wantAttack = false;

    private float _stamina = MAX_STAMINA;

    private int health = 100;

    public int Health
    {
        get { return health; }
    }

    void Update()
    {
        UpdateWantAttack();
        return;
    }

    void FixedUpdate()
    {
        HandleAttack();
        return;
    }

    public Transform GetMovingTransform()
    {
        return transform;
    }

    public void RemoveHealth(int value)
    {
        health -= value;
        if(health <= 0)
        {
            //TODO fix it....
            SceneManager.LoadScene("Menu");
        }

        return;
    }

    public bool IsAttacking()
    {
        return _isAttacking;
    }

    private void UpdateWantAttack()
    {
        if (Input.GetMouseButton(0))
        {
            _wantAttack = true;
            return;
        }
        _wantAttack = false;

        return;
    }

    private void HandleAttack()
    {
        if (_wantAttack)
        {
            if (HasStamina())
            {
                if(!_source.isPlaying)
                {
                    _source.PlayOneShot(_clipToPlay);
                }
                _isAttacking = true;
                _stamina-= 0.5f;
                 return;
            }
        }
        if (!_wantAttack)
        {
            RegenrateStamina();
        }
        
        _isAttacking = false;
        _source.Stop();

        return;
    }

    private bool HasStamina()
    {
        if(_isAttacking && _stamina > 0)
        {
            return true;
        }
        else if(!_isAttacking && _stamina > MAX_STAMINA/5)
        {
            return true;
        }

        return false;
    }

    private void RegenrateStamina()
    {
        if (_stamina < MAX_STAMINA)
        {
            _stamina += 0.5f;
        }

        return; ;
    }
}
