using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float force = 1;
    Rigidbody2D body2D;

    void Start() => body2D = GetComponent<Rigidbody2D>();

    void FixedUpdate() => Shoot();

    void Shoot()
    {
        body2D.AddForce(transform.up * force, ForceMode2D.Force);
        transform.parent = null;
    }

    void OnBecameInvisible() => ObjectPooler.instance.ReturnToPool(gameObject, "Bullet");
}
