using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button startButton;
    public Button settingButton;
    public Button quitButton;
    public Button feedbackButton;
    public Button backButton;
    public GameObject settingsPanel;
    public Slider VolumeSlider;
    public Slider SpeedSlider;
    private float targetSpeed = 1.0f;

    private AudioSource audioSource;

    void Start()
    {
        // Pokus o získanie AudioSource z objektu BackgroundAudio
        GameObject backgroundAudio = GameObject.Find("BackgroundAudio");
        if (backgroundAudio != null)
        {
            audioSource = backgroundAudio.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogError("AudioSource objekt s názvom 'BackgroundAudio' nebol nájdený.");
        }

        startButton.onClick.AddListener(StartGame);
        settingButton.onClick.AddListener(OpenSettings);
        feedbackButton.onClick.AddListener(OpenFeedback);
        quitButton.onClick.AddListener(QuitGame);
        backButton.onClick.AddListener(BackToMenu);
        VolumeSlider.onValueChanged.AddListener(SetVolume);
        SpeedSlider.onValueChanged.AddListener(SetTargetSpeed);

        // Nastavenie hlasitosti na slider hodnotu
        if (audioSource != null)
        {
            audioSource.volume = VolumeSlider.value;
        }
    }

    void Update()
    {
        // Aktualizujeme hlasitosť len ak je audioSource platný
        if (audioSource != null)
        {
            audioSource.volume = VolumeSlider.value;
        }
    }

    // Metóda na spustenie hry
    void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Nahraď názov scény názvom svojej hlavnej hernej scény
    }

    // Metóda na otvorenie nastavení
    void OpenSettings()
    {
        settingsPanel.SetActive(true);
        startButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        feedbackButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    // Metóda na odoslanie spätnej väzby
    void OpenFeedback()
    {
        Debug.Log("Open Feedback clicked");
    }

    // Metóda na ukončenie hry
    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game clicked");
    }

    void BackToMenu()
    {
        settingsPanel.SetActive(false);
        startButton.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(true);
        feedbackButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    // Priamo nastavíme volume na audioSource pri zmene hodnoty
    public void SetVolume(float newVolume)
    {
        if (audioSource != null)
        {
            audioSource.volume = newVolume;
        }
        Debug.Log("Volume set to: " + newVolume);
    }

    void SetTargetSpeed(float newSpeed)
    {
        targetSpeed = newSpeed;
        Debug.Log("Target speed set to: " + targetSpeed);
    }
}
