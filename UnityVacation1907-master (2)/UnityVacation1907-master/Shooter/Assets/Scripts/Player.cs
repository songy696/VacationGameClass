using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody mRB;

    public Transform BoltPos;
    public BoltPool boltPool;
    public GameController gameController;

    public BombScript bomb;

    public float Speed;
    public float Tilt;

    public float MinX;
    public float MaxX;
    public float MinZ;
    public float MaxZ;

    public float FireRate;
    private float currentFireTimer;

    public GameObject ChargingObj;
    public float ChargeMaxValue;
    private float currentChargeValue;

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

        currentChargeValue = 0;
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

        currentChargeValue = 0;

        if (Input.GetButton("Fire3"))
        {
            ChargingObj.SetActive(true);
            currentChargeValue += Time.deltaTime;
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            if (currentChargeValue >= ChargeMaxValue) {
                //shoot 20
                //Debug.Log("Fire!!!!!!!!!!!!!!");
                ChargingObj.transform.position = BoltPos.position;
                ChargingObj.gameObject.SetActive(true);

            }
            currentChargeValue = 0;
            ChargingObj.SetActive(false);
        }
        else if (Input.GetButton("Fire1") && currentFireTimer <= 0)
        {
            Bolt newBolt = boltPool.GetFromPool();
            newBolt.transform.position = BoltPos.position;
            currentFireTimer = FireRate;
            //Sound
            soundController.PlayEffectSound((int)eEffectSoundType.FirePlayer);
        }

        if (Input.GetButton("Fire2") && !bomb.gameObject.activeInHierarchy)
        {
            bomb.transform.position = BoltPos.position;
            bomb.gameObject.SetActive(true);
        }
    }

    private IEnumerator ChargingFire(int boltCount) {
        int count = boltCount;
        while (count > 0) {
            Bolt newBolt = boltPool.GetFromPool();
            newBolt.transform.position = BoltPos.position;
            soundController.PlayEffectSound((int)eEffectSoundType.FirePlayer);
            count--;
            yield return new WaitForSeconds(1);
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
