using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    private int cameraSideNum, cameraWidth, cameraHeight;

    private void Start()
    {
        InvokeRepeating("StartSpawning", 0.1f, 1f);
    }

    void StartSpawning()
    {
        ChooseCameraSideToSpawn();
        var astroid = Spawn();
        SetPosition(astroid);
        SetRotation(astroid);
    }

    void ChooseCameraSideToSpawn()
    {
        cameraWidth = Camera.main.scaledPixelWidth;
        cameraHeight = Camera.main.scaledPixelHeight;
        cameraSideNum = Random.Range(1, 5); //choose on of the 4 sides of screen camera randomly
    }

    GameObject Spawn()
    {
        int randomIndex = Random.Range(1, 5);
        var astroidTag = ObjectPooler.instance.pools[randomIndex].tag;
        return ObjectPooler.instance.SpawnFromPool(astroidTag, transform);
    }

    void SetPosition(GameObject _instance)
    {
        var instancePos = GetPosition();
        instancePos.z = 0;
        _instance.transform.position = instancePos;
    }

    void SetRotation(GameObject _instance)
    {
        var instanceRot = GetRotation();
        instanceRot.x = 0;
        instanceRot.y = 0;
        _instance.transform.rotation = Quaternion.Euler(instanceRot);
    }

    Vector3 GetPosition()
    {
        switch (cameraSideNum)
        {
            case 1:
                var randomX1 = Random.Range(0, cameraWidth);
                return Camera.main.ScreenToWorldPoint(new Vector3(randomX1, 0, 0));
            case 2:
                var randomX2 = Random.Range(0, cameraWidth);
                return Camera.main.ScreenToWorldPoint(new Vector3(randomX2, cameraHeight, 0));
            case 3:
                var randomY1 = Random.Range(0, cameraHeight);
                return Camera.main.ScreenToWorldPoint(new Vector3(0, randomY1, 0));
            case 4:
                var randomY2 = Random.Range(0, cameraHeight);
                return Camera.main.ScreenToWorldPoint(new Vector3(cameraWidth, randomY2, 0));
        }
        return Vector3.zero;
    }

    Vector3 GetRotation()
    {
        switch (cameraSideNum)
        {
            case 1:
                var randomAngle1 = Random.Range(-60, 60);
                return new Vector3(0, 0, randomAngle1);
            case 2:
                var randomAngle2 = Random.Range(120, 240);
                return new Vector3(0, 0, randomAngle2);
            case 3:
                var randomAngle3 = Random.Range(-150, -30);
                return new Vector3(0, 0, randomAngle3);
            case 4:
                var randomAngle4 = Random.Range(30, 150);
                return new Vector3(0, 0, randomAngle4);
        }
        return Vector3.zero;
    }
}
