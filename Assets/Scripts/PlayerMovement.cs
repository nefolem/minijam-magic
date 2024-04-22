using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _horizontalMove;
    private float _verticalMove;
    private bool _facingRight = true;
    private Animator _anim;


    [SerializeField] private float _moveSpeed;
    [SerializeField] private GameObject _frontSprite;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal");
        _verticalMove = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (!HealthController.Instance._isDead && !HealthController.Instance._isWon)
        {

            Vector3 moveDirection = new Vector3(_horizontalMove, _verticalMove, 0).normalized;
            _rb.velocity = moveDirection * _moveSpeed;
            if (_horizontalMove < 0 && _facingRight)
            {
                Flip();
                _anim.SetBool("IsWalking", true);
                _anim.Play("walk_Clip");
            }
            else if (_horizontalMove > 0 && !_facingRight)
            {
                Flip();
                _anim.SetBool("IsWalking", true);
                _anim.Play("walk_Clip");
            }
            else if (_horizontalMove == 0)
            {
                _anim.SetBool("IsWalking", false);

            }

            if (_verticalMove > 0)
            {
                _anim.SetBool("IsUp", true);
                _anim.Play("back_Clip");
            }
            else if (_verticalMove <= 0)
            {
                _anim.SetBool("IsUp", false);
                //_anim.Play("back_Clip");
            }
        }

        //if(HealthController.Instance._isDamaged)
        //{
        //    print("blink");
        //    _anim.SetBool("IsBlinking", true);
        //    _anim.Play("blinking");
        //}
        //else _anim.SetBool("IsBlinking", false);


    }

    private void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    

}
