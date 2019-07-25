using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject Effect;
    public float speed;

    private SoundController mSoundController;
    private GameController gameController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //mSoundController = gameController.GetSoundController();
        mSoundController = GameObject.FindGameObjectWithTag("GameController").    //with nametag
                           GetComponent<GameController>().                        //get component
                           GetSoundController();                                  //
    }

    private void OnEnable()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnDisable()
    {
        //set the placement first and then 
        Effect.transform.position = transform.position;
        Effect.SetActive(true);

        mSoundController.PlayEffectSound((int)eEffectSoundType.ExpPlayer);
    }

}
