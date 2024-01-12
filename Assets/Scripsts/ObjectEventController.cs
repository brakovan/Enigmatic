using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEventController : MonoBehaviour
{
    [Header("NPC:")]
    [SerializeField]
    private GameObject[] npsGM;
    [Space][SerializeField]
    private LayerMask objectLayer;

    private Animator anim;

    private string tagNameObject;
    private int objectLayerName;



    private void Update()
    {
        RaycastHit2D objectHit = Physics2D.Raycast(GameObject.Find("Player").GetComponent<PlayerController>().mouseClickPosition, Vector2.zero, 1, objectLayer);

        if (Input.GetMouseButtonDown(0))
        {
            if (objectHit.collider == null)
            {
                return;
            }
            else
            {
                tagNameObject = objectHit.collider.gameObject.tag;
                anim = objectHit.collider.GetComponent<Animator>();
                objectLayerName = objectHit.collider.gameObject.layer;

                switch (tagNameObject)
                {
                    case "Chaire 1":

                        anim.SetTrigger("doActionOneAnim");

                        break;

                    case "Televisor":

                        anim.SetTrigger("doActionOneAnim");

                        break;

                    default:
                        break;


                }
                for (int i = 0; i < npsGM.Length; i++)
                {
                    if (Vector3.Distance(objectHit.collider.gameObject.transform.position, npsGM[i].gameObject.transform.position) < 10)
                    {
                        StartCoroutine(NpcReaction(i));

                    }
                }

            }
        }
    }

    IEnumerator NpcReaction(int localIndxNpc)
    {
        if (objectLayerName == 6)
        {
            if (tagNameObject == "Chaire 1")
            {
                yield return new WaitForSeconds(2);
                npsGM[localIndxNpc].GetComponent<NpsController>().currentState = npsGM[localIndxNpc].GetComponent<NpsController>().goToChaire1Event;
            }

            if (tagNameObject == "Televisor")
            {
                yield return new WaitForSeconds(2);
                npsGM[localIndxNpc].GetComponent<NpsController>().currentState = npsGM[localIndxNpc].GetComponent<NpsController>().goToTelevisorEvent;
            }
        }
    }
}
