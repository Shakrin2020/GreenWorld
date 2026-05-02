using UnityEngine;

public class AxeHit : MonoBehaviour
{
    public AudioSource hitAudio;

    private void OnTriggerEnter(Collider other)
    {
        Rabbit rabbit = other.GetComponentInParent<Rabbit>();

        if (rabbit != null)
        {
            Debug.Log("Hit rabbit: " + rabbit.name);

            // Play sound
            if (hitAudio != null)
            {
                hitAudio.PlayOneShot(hitAudio.clip);
            }

            rabbit.Die();
        }
    }
}