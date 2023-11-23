using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const int shp = 3;
    int hp;
    public int currentLevel;
    public List<string> levels;

    bool hasWon;

    float targetTranstionScale;
    public Transform transition;

    public GameObject piece;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        hp = shp;
    }

    private void Update()
    {
        transition.localScale = Vector3.MoveTowards(transition.localScale, Vector3.one * targetTranstionScale, 60 * Time.deltaTime);
    }

    public void Win()
    {
        if (hasWon) return;

        hasWon = true;
        currentLevel++;
        targetTranstionScale = 41;
        Invoke("LoadNextScene", 1.5f);

    }

    public void Lose()
    {
        hp -= 1;

        if (hp <= 0)
        {
            currentLevel = 0;
            SceneManager.LoadScene(currentLevel);
            hp += shp;
        }
        else if (hp > 0)
        {
            SceneManager.LoadScene(currentLevel);
        }
    }
    public void LoadNextScene()
    {
        hasWon = false;
        var levelName = levels[currentLevel];
        targetTranstionScale = 0;
        SceneManager.LoadScene(levelName);
    }
}
