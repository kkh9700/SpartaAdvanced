using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody Rigidbody;
    private float Damage { get; set; }
    private float Knockback { get; set; }
    private float time { get; set; } = 10f;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(3f * Vector3.up * Time.deltaTime);
    }

    public void Init(float damage, float knockback)
    {
        Damage = damage;
        Knockback = knockback;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out HP HP))
        {
            HP.TakeDamage(Damage);
        }

        if (other.TryGetComponent(out ForceReceiver forceReciver))
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;
            forceReciver.AddForce(direction * Knockback);
        }

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(Disable());
    }

    private void OnDisable()
    {
        StopCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(time);

        gameObject.SetActive(false);
    }
}
