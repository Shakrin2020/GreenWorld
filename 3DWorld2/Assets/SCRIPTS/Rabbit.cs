using UnityEngine;
using System.Collections;

public class Rabbit : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;

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