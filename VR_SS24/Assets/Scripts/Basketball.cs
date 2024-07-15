using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Basketball : MonoBehaviour
{
    XRBaseInteractable interactable;
    UIManager uIManager;
    TextManager textManager;
    LevelManager levelManager;
    Rigidbody rb;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;

    // dribbling variables
    bool isFailingOnce = false;
    bool isBallDropped;
    int currentScore = 0;
    int maxScore = 3;

    // lower basket variables
    Transform basket;
    float lowerAmount = 0.25f;
    float minHeight = -2f;
    bool hasLowered = false;

    void Awake()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        textManager = GameObject.Find("TextManager").GetComponent<TextManager>();
        basket = GameObject.Find("Basket").GetComponent<Transform>();
        source = GetComponent<AudioSource>();

        // logic for the basketball to keep bouncing near the ground and stopping after certain threshold depending on planet
        rb = GetComponent<Rigidbody>();
        switch (levelManager.BuildIndex)
        {
            case 1:
                {
                    rb.sleepThreshold = Physics.bounceThreshold = 1.25f;
                    break;
                }
            case 2:
                {
                    rb.sleepThreshold = Physics.bounceThreshold = 0.001f;
                    break;
                }
            case 3:
                {
                    rb.sleepThreshold = Physics.bounceThreshold = 0.05f;
                    break;
                }
        }

        interactable = GetComponent<XRBaseInteractable>();
        interactable.selectEntered.AddListener(OnSelectEnteredHandler);
    }

    void OnDestroy()
    {
        // Unsubscribe from the selectExited event to avoid memory leaks
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnSelectEnteredHandler);
        }
    }

    private void OnSelectEnteredHandler(SelectEnterEventArgs args)
    {
        // Reset the drop flag when the ball is regrabbed
        isBallDropped = false;
        isFailingOnce = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        source.PlayOneShot(clip);

        if (collision.gameObject.CompareTag("Ground"))
        {
            // dribbling score logic
            if (GameManager.instance.state == GameState.TaskOne)
            {
                if (!isBallDropped)
                {
                    // Prevents incrementing the count again for the same drop
                    isBallDropped = true;
                    currentScore++;
                    AudioManager.instance.PlayUI(AudioManager.instance.done01);
                }
                else
                {
                    // if ball hits ground twice without regrab, reset score to zero
                    currentScore = 0;
                    if (!isFailingOnce)
                    {
                        // play fail sound for dribbling only once
                        AudioManager.instance.PlayUI(AudioManager.instance.fail);
                        isFailingOnce = true;
                    }
                }

                // Refresh score in UI
                textManager.TaskOneScore(currentScore, maxScore);

                // show button for next task if reached maxScore
                if (!GameManager.instance.IsTaskOneDone && currentScore == maxScore)
                {
                    AudioManager.instance.PlayUI(AudioManager.instance.done02);
                    uIManager.TaskTwoButton.gameObject.SetActive(true);
                    switch (levelManager.BuildIndex)
                    {
                        case 1:
                            GameManager.instance.IsMoonVisitable = true;
                            break;
                        case 2:
                            GameManager.instance.IsEarthVisitable = true;
                            break;
                        case 3:
                            GameManager.instance.IsGameDone = true;
                            break;
                    }
                    GameManager.instance.IsTaskOneDone = true;
                }
            }

            // basket logic
            if (GameManager.instance.state == GameState.TaskTwo && !hasLowered && basket.position.y > minHeight)
            {
                // lower basket if player fails to throw basketball into basket
                basket.position -= new Vector3(0, lowerAmount, 0);
                hasLowered = true;
                AudioManager.instance.PlayUI(AudioManager.instance.fail);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // show return to ship panel if succeeding to throw basketball into basket
        if (other.gameObject.CompareTag("Basket") && GameManager.instance.state == GameState.TaskTwo)
        {
            if (!GameManager.instance.IsTaskTwoDone)
            {
                AudioManager.instance.PlayVoice();
                GameManager.instance.IsTaskTwoDone = true;
                AudioManager.instance.PlayUI(AudioManager.instance.done02);
            }
            else
            {
                AudioManager.instance.PlayUI(AudioManager.instance.done01);
            }
            uIManager.ShowReturnPanel();
        }
    }
}
