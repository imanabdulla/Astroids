using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public int points;
    public int health;

    [SerializeField] private GameObject spaceshipPrefab;
    [SerializeField] private GameObject startEndMenu;
    [SerializeField] private Text pointsTxt;
    [SerializeField] private Text healthTxt;

    private GameObject spaceshipInstance;

    private void Awake()
    {
        base.RegisterSingleton();
    }

    public void StartGame()
    {
        SpawnSpaceship();

        points = 0;
        health = 3;
        pointsTxt.text = points.ToString();
        healthTxt.text = health.ToString();

        startEndMenu.SetActive(false);
    }

    public void EndGame()
    {
        health = 0;
        healthTxt.text = health.ToString();

        startEndMenu.SetActive(true);
    }

    public void IncreasePoints()
    {
        points += 10;
        pointsTxt.text = points.ToString();
    }

    public void ReduceHealth()
    {
        health -= 1;
        healthTxt.text = health.ToString();

        if (health > 0) SpawnSpaceship();
        else EndGame();
    }

    public void SpawnSpaceship()
    {
        spaceshipInstance = Instantiate(spaceshipPrefab);
    }

    public void DestroySpaceship()
    {
        Destroy(spaceshipInstance);
    }
}
