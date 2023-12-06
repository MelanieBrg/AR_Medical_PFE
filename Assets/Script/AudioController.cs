using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;
    private bool hasSceneChanged = false;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Subscribe to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        // Check if the scene has changed and the audio clip hasn't started playing yet
        if (hasSceneChanged && !audioSource.isPlaying)
        {
            // Wait for 2 seconds before playing the audio clip
            StartCoroutine(PlayAudioAfterDelay(2f));
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Set the flag indicating that the scene has changed
        hasSceneChanged = true;
    }

    IEnumerator PlayAudioAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Play the audio clip
        audioSource.Play();
    }
}
