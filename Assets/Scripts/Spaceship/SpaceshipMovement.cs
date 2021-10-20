using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField] private float rotationOffset = 270;
    [SerializeField] private float speed = 2;

    void Update() => FollowMouse();

    void FollowMouse()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = 0;
        var spaceshipScreenPos = Camera.main.WorldToScreenPoint(transform.position);

        var tangentY = mouseScreenPos.y - spaceshipScreenPos.y;
        var tangentX = mouseScreenPos.x - spaceshipScreenPos.x;

        //rotate spaceship toward mouse
        var angleInDegree = Mathf.Atan2(tangentY, tangentX) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleInDegree + rotationOffset));

        //move spaceship toward mouse
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = 0;
        transform.position = Vector3.MoveTowards(transform.position, mouseWorldPos, Time.deltaTime * speed);
    }
}
