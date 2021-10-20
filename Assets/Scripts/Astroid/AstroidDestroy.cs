using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidDestroy : MonoBehaviour
{
    [SerializeField] private string astroidTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DestroyAstroid();
            GameManager.instance.IncreasePoints();
            if (astroidTag != "AstroidFragment")
                SeparateAstroid();
        }
    }

    void OnBecameInvisible() => ObjectPooler.instance.ReturnToPool(gameObject, astroidTag);

    void DestroyAstroid()
    {
        ObjectPooler.instance.ReturnToPool(gameObject, astroidTag);
    }

    void SeparateAstroid()
    {
        for (int i = 0; i < 3; i++)//spawn 3 fragments
        {
            var fragment = ObjectPooler.instance.SpawnFromPool("AstroidFragment", null);
            fragment.transform.position = transform.position;
            var angleZ = Random.Range(0, 360);
            fragment.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleZ));
        }
    }
}
