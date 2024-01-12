using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCode : MonoBehaviour
{
    [Space][SerializeField]
    private int roomIndx;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            collision.gameObject.GetComponent<NpsController>().npsIndex = roomIndx;
        }

        if (collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<ObjectsController>().objectIndex = roomIndx;
        }
    }
}
