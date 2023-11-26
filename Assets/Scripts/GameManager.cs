using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int hp;
    public int currentLevel;
    bool hasWon;
    public List<string> levels;

    float targetTransitionScale;
    public Transform transition;

    AudioSource musicSource;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip gameOverSound;

    void Start()
    {
        Application.targetFrameRate = 60;

        musicSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);

        // destroys the game manager if there is another one
        if (FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        var targetV3 = Vector3.one * targetTransitionScale;
        transition.localScale = Vector3.MoveTowards(transition.localScale, targetV3, 60 * Time.deltaTime);
    }

    public void Win()
    {
        if (hasWon) return;

        musicSource.PlayOneShot(winSound);
        hasWon = true;
        currentLevel++;
        targetTransitionScale = 41;
        Invoke("LoadNextScene", 1.5f);

    }

    void LoadNextScene()
    {
        var levelName = levels[currentLevel];
        SceneManager.LoadScene(levelName);
        hasWon = false;
        targetTransitionScale = 0;
    }


    public void Lose()
    {
        hp--;
        if (hp > 0)
        {
            targetTransitionScale = 41;
            musicSource.PlayOneShot(loseSound);
            Invoke("LoadNextScene", 1.5f);
        }
        else
        {
            targetTransitionScale = 41;
            musicSource.PlayOneShot(gameOverSound);
            currentLevel = 0;
            hp = 3;
            Invoke("LoadNextScene", 1.5f);
        }
    }
}
