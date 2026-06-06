using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    public GameObject successText;
    public GameObject failureText;
    public GameObject instructionsPanel;
    public GameObject startButton;
    public GameObject restartButton;

    [Header("Text")]
    public TMP_Text attemptsText;
    public TMP_Text timerText;

    [Header("Audio")]
    public AudioClip successSound;
    public AudioClip failureSound;

    private AudioSource audioSource;

    private int attempts = 0;
    private float timer = 0f;
    private bool timerRunning = false;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (successText != null)
            successText.SetActive(false);

        if (failureText != null)
            failureText.SetActive(false);

        if (restartButton != null)
            restartButton.SetActive(false);

        if (attemptsText != null)
            attemptsText.text = "Attempts: 0";

        if (timerText != null)
            timerText.text = "Time: 0.0s";
    }

    private void Update()
    {
        if (timerRunning)
        {
            timer += Time.deltaTime;

            if (timerText != null)
            {
                timerText.text = "Time: " + timer.ToString("F1") + "s";
            }
        }
    }

    public void StartGame()
    {
        if (instructionsPanel != null)
            instructionsPanel.SetActive(false);

        if (startButton != null)
            startButton.SetActive(false);

        if (successText != null)
            successText.SetActive(false);

        if (failureText != null)
            failureText.SetActive(false);

        timer = 0f;
        timerRunning = true;

        Debug.Log("Game Started");
    }

    public void ShowSuccess(GameObject cube)
    {
        timerRunning = false;

        if (failureText != null)
            failureText.SetActive(false);

        if (successText != null)
            successText.SetActive(true);

        if (restartButton != null)
            restartButton.SetActive(true);

        if (audioSource != null && successSound != null)
            audioSource.PlayOneShot(successSound);

        StartCoroutine(GrowCube(cube));
    }

    IEnumerator GrowCube(GameObject cube)
    {
        Vector3 startScale = cube.transform.localScale;
        Vector3 targetScale = startScale * 2f;

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 2f;

            cube.transform.localScale =
                Vector3.Lerp(startScale, targetScale, t);

            yield return null;
        }

        Renderer renderer = cube.GetComponent<Renderer>();

        if (renderer != null)
            renderer.material.color = Color.green;
    }

    public void ShowFailure(GameObject cube)
    {
        if (successText != null)
            successText.SetActive(false);

        if (failureText != null)
            failureText.SetActive(true);

        attempts++;

        if (attemptsText != null)
            attemptsText.text = "Attempts: " + attempts;

        if (audioSource != null && failureSound != null)
            audioSource.PlayOneShot(failureSound);

        StartCoroutine(ShakeCube(cube));
    }

    IEnumerator ShakeCube(GameObject cube)
    {
        Vector3 originalPos = cube.transform.position;

        for (int i = 0; i < 20; i++)
        {
            cube.transform.position =
                originalPos +
                Random.insideUnitSphere * 0.1f;

            yield return null;
        }

        cube.transform.position = originalPos;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}