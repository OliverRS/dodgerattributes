using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] enemyPrefab;



    [SerializeField] float spawnRate;

    bool gamestarted = false;

    int score = 0;

    Vector2 screenPos;

    [SerializeField] TextMeshProUGUI scoreText;

    void spawnEnemy()
    {
        float randomX = Random.Range (0f, 1f);

        Vector2 viewPortPos = new Vector2(randomX, 1f);

        Vector2 worldPos = Camera.main.ViewportToWorldPoint(viewPortPos);

        int randEnemy = Random.Range(0,enemyPrefab.Length);

        Instantiate (enemyPrefab[randEnemy], worldPos, Quaternion.identity);

        score++;

        UpdateText(score);
    }
    
    void startspawning()
    {
        InvokeRepeating("spawnEnemy", 0.5f, spawnRate);
    }

    private void Update()
    {
        if (transform.GetComponent<inputsystem>().IsPressing(out screenPos) && !gamestarted)
        {
            startspawning();
            gamestarted = true;
        }

        Debug.Log("Current score:" + score);
    }

    void UpdateText(int score)
    {
        scoreText.text = score.ToString();
    }

}
