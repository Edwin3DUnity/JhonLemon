#if UNITY_IOS || UNITY_ANDROID

#define  USING_MOBILE

#endif
    
    

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontal;
    private float vertical;

    private Vector3 movement;
    private bool isWalking;

    private Animator _animator;
    private Rigidbody _rigidbody;
    [SerializeField] private float turnSpeed;

    private Quaternion rotation = Quaternion.identity;


    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

#if  USING_MOBILE
    float horizontal = Input.GetAxis("Mouse X");
    float vertical =  Input.GetAxis("Mous Y");
        
    if (Input.touchCount > 0)
    {
        horiztonal = Input.touches[0].deltaPosition.x;
        vertical = Input.touches[0].deltaPosition.y;

    }
{  
  
}

#else 
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

#endif
        
        
        
        movement.Set(horizontal,0, vertical);
        movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0);

        isWalking = hasHorizontalInput || hasVerticalInput;
        
        _animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }    
        }
        else
        {
            _audioSource.Stop();
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.fixedDeltaTime, 0);
        
         rotation = Quaternion.LookRotation(desiredForward);

    }

    private void OnAnimatorMove()
    {
        
        //S(espacio) = S0(espacio inicial) + V(velocidad ) * T(tiempo
        //)
        // S = S0 + Delta S
        _rigidbody.MovePosition(_rigidbody.position + movement * _animator.deltaPosition.magnitude);
        _rigidbody.MoveRotation(rotation);
    }
}
