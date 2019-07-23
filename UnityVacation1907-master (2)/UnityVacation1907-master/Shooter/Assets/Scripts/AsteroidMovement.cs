using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{

    private Rigidbody rb;

    public float Speed = 5;

    private EffectPool effect;

    private GameController gameController;
    private SoundController soundController;

    //should use awake because onenable works before start therefore it should be before
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * Speed;
        GameObject effectObj = GameObject.FindGameObjectWithTag("EffectPool");
        effect = effectObj.GetComponent<EffectPool>();

        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        gameController = controller.GetComponent<GameController>();

        soundController = gameController.GetSoundController();
    }

    //this works like a switch that it works when the objact is appeared
    void OnEnable()
    {
        rb.angularVelocity = Random.onUnitSphere * 3;//new Vector3(10, 20, 30);
    }

    // Start is called before the first frame update
    void Start()
    {

        
    }

    public void EnterBomb(float damage) {
        Hit();
    }

    private void Hit() {
        gameController.AddScore(1);
        Timer newEffect = effect.GetFromPool((int)eEffectType.AsteroidExp);
        newEffect.transform.position = transform.position;
        soundController.PlayEffectSound((int)eEffectSoundType.ExpAst);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt") || 
            other.gameObject.CompareTag("Player")) {

            //effect
            //Timer newEffect = effect.GetFromPool((int)eEffectType.AsteroidExp);
            //newEffect.transform.position = transform.position;

            //Sound
            //soundController.PlayEffectSound((int)eEffectSoundType.ExpAst);

            //score
            //gameController.AddScore(1);

            Hit();

            other.gameObject.SetActive(false);
            //gameObject.SetActive(false);
        }
    }

}
