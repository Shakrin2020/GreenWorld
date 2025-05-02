using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR; // Optional but good to include

public class WalkingSoundController : MonoBehaviour
{
    public AudioSource walkingAudio;
    public InputActionProperty moveInput; // Binding this to XRI LeftHand/Move

    void Update()
    {
        Vector2 move = moveInput.action.ReadValue<Vector2>();

        if (move.magnitude > 0.1f)
        {
            if (!walkingAudio.isPlaying)
                walkingAudio.Play();
        }
        else
        {
            if (walkingAudio.isPlaying)
                walkingAudio.Stop();
        }
    }
}