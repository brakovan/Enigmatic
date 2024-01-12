using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NpsController : MonoBehaviour
{
    [Space][SerializeField]
    private GameObject chaire1;
    public GameObject televisor;
    private SpriteRenderer sr;
    private GameObject stair_1;

    //[NonSerialized]
    public UnityEvent currentState;

    [Header("Действия NPC:")]
    public UnityEvent goToChaire1Event;
    public UnityEvent goToTelevisorEvent;

    [Space][SerializeField]
    private float moveSpeedNps = 1f;
    private float npcStair1Dist;
    private int npcLookSide;

    [Space]
    public int npsIndex;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = true;

        stair_1 = GameObject.Find("Door 1").GetComponent<DoorsStairsEnter>().stair_1;
    }

    private void Update()
    {
        npcStair1Dist = Vector3.Distance(gameObject.transform.position, stair_1.transform.position);

        currentState?.Invoke();

        if (sr.flipX == false)
        {
            npcLookSide = 1;
        }
        if (sr.flipX == true)
        {
            npcLookSide = -1;
        }
        
        if (npsIndex == 2 || npsIndex == 3 )
        {
            sr.flipX = false;
        }
    }

    public void GoToChaire1()
    {
        if (npcStair1Dist > 2 && npsIndex == 0 || npsIndex == 1)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, stair_1.transform.position, moveSpeedNps * Time.deltaTime);
        }
        else if (npsIndex == 2)
        {
            gameObject.transform.position += new Vector3(moveSpeedNps * npcLookSide * Time.deltaTime, 0, 0);
        }
        else if (npsIndex == 3)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, chaire1.transform.position, moveSpeedNps * Time.deltaTime);
        }

        if (gameObject.transform.position == chaire1.transform.position)
        {
            currentState = null;
        }
    }

    public void GoToTelevisor()
    {
        if (npcStair1Dist > 2 && npsIndex == 0 || npsIndex == 1)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, stair_1.transform.position, moveSpeedNps * Time.deltaTime);
        }
        else if (npsIndex == 3)
        {
            gameObject.transform.position += new Vector3(moveSpeedNps * -1 * Time.deltaTime, 0, 0);
        }
        else if (npsIndex == 2)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, televisor.transform.position, moveSpeedNps * Time.deltaTime);
        }

        if (gameObject.transform.position == televisor.transform.position)
        {
            currentState = null;
        }
    }
}
