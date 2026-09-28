using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CupController : MonoBehaviour
{
    public int cupsRemaining = 2;
    //public GameObject cupDestroyedEffect; // Optional: Particle effect for cup destruction
    public Text cupCountText; // UI Text element
    public AudioSource soundEffectAudio;
    public GameObject GamePannel;
    public GameObject CheersPannel;
    

    void Awake()
    {
        cupCountText.text = "Cups Remaining: " + cupsRemaining;
    }
    
    public void OnPointerDown()
    {
        if (cupsRemaining > 0)
        {
            Debug.Log("Clicked on cup");
            Destroy(this.gameObject);
            cupsRemaining -= 1;

            /*if (cupDestroyedEffect != null)
            {
                Instantiate(cupDestroyedEffect, transform.position, Quaternion.identity);
            }*/

            // Update the UI Text
            cupCountText.text = "Cups Remaining: " + cupsRemaining;
        }

        if (soundEffectAudio != null)
        {
            soundEffectAudio.Play();
            StartCoroutine(Cheers());
            GamePannel.SetActive(false);
            CheersPannel.SetActive(true);
            
        }

        IEnumerator Cheers()
        {
            yield return new WaitForSeconds(0.1f);
            GamePannel.SetActive(false);
            CheersPannel.SetActive(true);
        }
    }

    void Update()
    {
        cupCountText.text = "Cups Remaining: " + cupsRemaining;
    }
}





