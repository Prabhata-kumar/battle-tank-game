using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.MVC;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    private void Start()
    {
        player = FindObjectOfType<TankView>().transform;
    }
    void Update()
    {
        CheckPlayer();
        transform.position = player.transform.position + offset;
    }

    private void CheckPlayer()
    {
        if (player == null)
        {
            player = transform;
            return;
        }
    }
    private void LateUpdate()
    {
        offset = transform.position - player.transform.position;
    }
}
