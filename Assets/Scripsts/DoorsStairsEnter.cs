using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsStairsEnter : MonoBehaviour
{
    private SpriteRenderer srNpc;

    [Header("ÀÂÒÚÌËˆ‡:")]
    public GameObject stair_1;
    public GameObject stair_2;

    [Header("ƒ‚ÂË:")]
    public GameObject door_1;
    public GameObject door_2, door_3, door_4, door_5, door_6;

    [Space][SerializeField]
    private bool canEnterDoorStair = true;
    private float npcLookSide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("NPC"))
            {
                srNpc = collision.gameObject.GetComponent<SpriteRenderer>();

                if (srNpc.flipX)
                {
                    npcLookSide = -1;
                }
                else
                {
                    npcLookSide = 1;
                }


                if (!canEnterDoorStair)
                {
                    return;
                }

                if (gameObject == door_1)
                {
                    Debug.Log("¬€’Œƒ»“‹ Õ≈À‹«ﬂ!!");
                }

                if (gameObject == door_2)
                {
                    collision.gameObject.transform.position = door_3.transform.position + new Vector3(.5f * npcLookSide, 0, 0);
                }

                if (gameObject == door_3)
                {
                    collision.gameObject.transform.position = door_2.transform.position + new Vector3(.5f * npcLookSide, 0, 0);
                }                                            
                                                             
                if (gameObject == door_4)                    
                {                                            
                    collision.gameObject.transform.position = door_5.transform.position + new Vector3(.5f * npcLookSide, 0, 0);
                }                                            
                                                             
                if (gameObject == door_5)                    
                {                                            
                    collision.gameObject.transform.position = door_4.transform.position + new Vector3(.5f * npcLookSide, 0, 0);
                }                                            
                                                             
                if (gameObject == door_6)                    
                {                                            
                    Debug.Log(" ŒÕ≈÷");                      
                }                                            
                                                             
                                                             
                if (gameObject == stair_1)                   
                {                                            
                    collision.gameObject.transform.position = stair_2.transform.position + new Vector3(.5f, 0, 0);
                }                                            
                                                             
                if (gameObject == stair_2)                   
                {                                            
                    collision.gameObject.transform.position = stair_1.transform.position + new Vector3(.5f, 0, 0);
                }
            }


        }
    }

}
