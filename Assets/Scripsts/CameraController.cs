using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("�����, �� ������� ������� ������:")]
    [SerializeField]
    private GameObject player;

    private void Update()
    {
        transform.position = transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
