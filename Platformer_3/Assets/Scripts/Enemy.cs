﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eEnemyState
{
    Idle,
    Move,
    Chase,
    Attack,
    Dead
}

public class Enemy : MonoBehaviour
{
    private Rigidbody2D mRB2D;
    private Animator mAnim;

    public float MoveSpeed;

    public eEnemyState mState;

    private Transform mTarget;
    private bool mAttackFlag;

    private Coroutine mStateShiftRoutine;

    public int MaxHP;
    public int mCurrentHP;

    // Start is called before the first frame update
    void Start()
    {
        mCurrentHP = MaxHP;

        mRB2D = GetComponent<Rigidbody2D>();
        mAnim = GetComponent<Animator>();

        mState = eEnemyState.Idle;
        StartCoroutine(AI());
    }

    public void Hit(int damage) {
        mCurrentHP = mCurrentHP - damage;
        if (mCurrentHP <= 0) {
            mState = eEnemyState.Dead;
        }
    }

    public void EnterAttackArea(bool isEnter) {
        mAttackFlag = isEnter;
        if (mAttackFlag) {
            mState = eEnemyState.Attack;
        }
    }

    public void FinishAttack()
    {
        mAnim.SetBool(AnimHash.Melee, false);

        if (mAttackFlag && mTarget != null) {
            mTarget.gameObject.SendMessage("Hit", 1, SendMessageOptions.DontRequireReceiver);
        }

        Debug.Log("Attack Finish");
    }

    public void SetTarget(Transform target)
    {
        mTarget = target;
        mState = eEnemyState.Chase;
    }

    public void RemoveTarget()
    {
        mTarget = null;
        mState = eEnemyState.Idle;
        // shift to Move
    }

    private IEnumerator ShiftState(float waitTime, eEnemyState state) {
        yield return new WaitForSeconds(waitTime);
        mState = state;
        mStateShiftRoutine = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision" + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Wall")) {
            mState = eEnemyState.Idle;
            //mAnim.SetBool(AnimHash.Walk, false);
            if (mStateShiftRoutine != null) {
                StopCoroutine(mStateShiftRoutine);
                mStateShiftRoutine = null;
                //should reset as null becuase the corouitne overlaps and does not function effectively
            }
        }
    }

    private IEnumerator AI()
    {
        while (true)
        {
            switch (mState)
            {
                case eEnemyState.Idle:
                    //Debug.Log("Rotation" + transform.rotation);
                    mAnim.SetBool(AnimHash.Walk, false);
                    mRB2D.velocity = Vector2.zero;
                    if (mStateShiftRoutine == null) {
                        if (transform.rotation.y < 0)   //(transform.rotation.y > 90) we cannot use degree because the script is reading the value as radiance
                        {
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                        }
                        else
                        {
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                        }
                        mStateShiftRoutine = StartCoroutine(ShiftState(2, eEnemyState.Move));
                    }
                    break;
                case eEnemyState.Move:
                    mAnim.SetBool(AnimHash.Walk, true);
                    mRB2D.velocity = transform.right * MoveSpeed;
                    break;
                case eEnemyState.Chase:
                    Vector2 direction = mTarget.position - transform.position;
                    if (direction.x < 0)
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);                        
                    }
                    mAnim.SetBool(AnimHash.Walk, true);
                    mRB2D.velocity = transform.right * MoveSpeed;
                    break;
                case eEnemyState.Attack:
                    mAnim.SetBool(AnimHash.Melee, true);
                    break;
                case eEnemyState.Dead:
                    mAnim.SetBool(AnimHash.Dead, true);
                    mRB2D.velocity = Vector2.zero;
                    //gaining point
                    break;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}