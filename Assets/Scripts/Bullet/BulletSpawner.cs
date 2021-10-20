using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Spawn();
    }

    void Spawn() => ObjectPooler.instance.SpawnFromPool("Bullet", transform);
}
