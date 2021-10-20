using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    void Update() => Move();

    void Move() => transform.Translate(Vector3.up * Time.deltaTime * speed);
}
