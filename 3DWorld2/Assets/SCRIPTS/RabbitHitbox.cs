using UnityEngine;

public class RabbitHitbox : MonoBehaviour
{
    public Rabbit rabbit;

    private void Awake()
    {
        if (rabbit == null)
            rabbit = GetComponentInParent<Rabbit>();
    }

    public void Hit()
    {
        if (rabbit != null)
            rabbit.Die();
    }
}