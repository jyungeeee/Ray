using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    enum State
    {
        Idle,
        Hit
    }
    State currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Idle;
        NextState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextState()
    {
        switch (currentState)
        {
            case State.Idle:
                StartCoroutine(IdleState());
                break;
            case State.Hit:
                StartCoroutine(HitState());
                break;

        }
    }

    IEnumerator IdleState()
    {
        this.gameObject.transform.rotation = Quaternion.identity;
        while(currentState ==State.Idle)
        {
            yield return null;
        }
        NextState();
    }

    public void Hit()
    {
        currentState = State.Hit;
    }

    IEnumerator HitState()
    {
        float angle = Random.Range(270, 360);
        float hitTime = 0.5f;

        while(currentState == State.Hit)
        {
            yield return null;

            this.gameObject.transform.Rotate(Time.deltaTime * angle * Vector3.one);

            if(hitTime<=0)
            {
                this.currentState = State.Idle;
            } hitTime -= Time.deltaTime;
        }
        NextState();
    }

}
