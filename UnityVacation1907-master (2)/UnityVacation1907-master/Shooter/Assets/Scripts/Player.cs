﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody mRB;

    public Transform BoltPos;
    public BoltPool boltPool;
    public GameController gameController;

    public float Speed;
    public float Tilt;

    public float MinX;
    public float MaxX;
    public float MinZ;
    public float MaxZ;

    public float FireRate;
    private float currentFireTimer;

    private EffectPool effect;

    private SoundController soundController;


    // Start is called before the first frame update
    void Start()
    {
        currentFireTimer = 0;
        mRB = GetComponent<Rigidbody>();
        GameObject effectObject = GameObject.FindGameObjectWithTag("EffectPool");
        effect = effectObject.GetComponent<EffectPool>();

        soundController = gameController.GetSoundController();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(horizontal * Speed, 0, vertical * Speed);
        mRB.velocity = velocity;

        transform.rotation = Quaternion.Euler(0, 0, horizontal * -Tilt);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX),
                                          0,
                                         Mathf.Clamp(transform.position.z, MinZ, MaxZ));

        currentFireTimer = currentFireTimer - Time.deltaTime;

        if (Input.GetButton("Fire1") && currentFireTimer <= 0)
        {
            Bolt newBolt = boltPool.GetFromPool();
            newBolt.transform.position = BoltPos.position;
            currentFireTimer = FireRate;
            //Sound
            soundController.PlayEffectSound((int)eEffectSoundType.FirePlayer);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //if you put in here it gives you a bug that effect does not work
            ////effect
            //Timer newEffect = effect.GetFromPool((int)eEffectType.PlayerExp);
            //newEffect.transform.position = transform.position;


            gameObject.SetActive(false);


        }
    }

    private void OnDisable()
    {
        //effect
        Timer newEffect = effect.GetFromPool((int)eEffectType.PlayerExp);
        newEffect.transform.position = transform.position;
        //sound
        soundController.PlayEffectSound((int)eEffectSoundType.ExpPlayer);
        gameController.GameOver();
    }
}
