using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;

    public Transform BoltPos;
    private BoltPool mPool;

    private Transform mPlayerTransform;

    public float speed;

    private EffectPool effect;

    private GameController gameController;
    private SoundController soundController;

    //public float Delay = 0.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * speed;
        GameObject effectObject = GameObject.FindGameObjectWithTag("EffectPool");
        effect = effectObject.GetComponent<EffectPool>();

        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        gameController = controller.GetComponent<GameController>();

        soundController = gameController.GetSoundController();
    }

    private void OnEnable()
    {
        StartCoroutine(AutoFire());
        //like getcomponenet dotn use too much because it becomes extremely heavy
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        //this is not a recommended method to solve the problem of missing finding game objects but works //mPlayerTransform = null;
        //instead putting as null, put it as enemy's transform
        //other method is to create the dummy target = which could be enemy themselves = which means they will not move and stay the same
        if (player != null)
        {
            mPlayerTransform = player.transform;
        }
        else {
            mPlayerTransform = transform;
        }


        StartCoroutine(SideMovement());

       
    }

    private IEnumerator AutoFire() {
        while (true) {      //while function used because it wants to function the insided script to work infinitly //IEumerator functions only once
            yield return new WaitForSeconds(Random.Range(0.7f, 1.2f));
            Bolt bolt = mPool.GetFromPool();
            bolt.transform.position = BoltPos.position;
            soundController.PlayEffectSound((int)eEffectSoundType.FireEnemy);
        }
    }

    public void SetUp(BoltPool pool) {
        mPool = pool;
    }


    private IEnumerator SideMovement() {
        while (true) {


            //this is not a recommended method to solve the problem of missing finding game objects but works - this has to be checked inorder to function the finding player
            //if (mPlayerTransform !=null) {


                float playerX = mPlayerTransform.position.x;
                //Vector3 currentPos = transform.position; // you have to use vector3 inorder to function the transform.... if you dont not allowed to fuction it only reading the script
                Vector3 currentVel = rb.velocity;
                //currentPos.x = playerX;
                currentVel.x = playerX - currentVel.x;       // this is using velocity instead of transform
                                                             //transform.position = currentPos;
                rb.velocity = currentVel;


            //}
            yield return new WaitForFixedUpdate();  // this is similar to yield return null; this means wait till other object spawns
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt") ||
            other.gameObject.CompareTag("Player"))
        {
            //effect
            Timer newEffect = effect.GetFromPool((int)eEffectType.EnemyExp);
            newEffect.transform.position = transform.position;

            //sound
            soundController.PlayEffectSound((int)eEffectSoundType.ExpEnemy);

            gameController.AddScore(1);

            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

    }
}
