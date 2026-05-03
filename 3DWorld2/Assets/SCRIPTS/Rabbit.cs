using UnityEngine;
using System.Collections;

public class Rabbit : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;
    public GameObject bloodEffectPrefab;

    private bool isDead = false;

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;

        Debug.Log("Rabbit killed: " + gameObject.name);

        if (bloodEffectPrefab != null)
        {
            GameObject bloodInstance = Instantiate(
                bloodEffectPrefab,
                transform.position + Vector3.up * 0.5f,
                Quaternion.identity
            );

            Destroy(bloodInstance, 2f);
        }

        AI_Movement movement = GetComponent<AI_Movement>();
        if (movement != null)
        {
            movement.isDead = true;
            movement.isWalking = false;
            movement.enabled = false;
        }

        if (animator != null)
        {
            animator.SetBool("isRunning", false);
            animator.SetTrigger("Die");
        }

        // Spawn blood at hit position
        if (bloodEffectPrefab != null)
        {
            Instantiate(bloodEffectPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true; // stops dead body moving
        }
    }

    private IEnumerator FreezeDeadBody()
    {
        yield return new WaitForSeconds(1.5f);

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }
    }
}