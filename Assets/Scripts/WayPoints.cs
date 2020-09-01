using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    private bool _moveWay;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Enemy")) return;

        _moveWay = other.gameObject.GetComponent<Enemy>().toLeft;

        other.gameObject.GetComponent<Enemy>().toLeft = !_moveWay;
    }
}