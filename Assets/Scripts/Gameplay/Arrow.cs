using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float arrowSpeed = 5.0f;
    [SerializeField] private float arrowDuration = 5.5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector3 playerScale = transform.root.localScale;

        Vector2 initialVelocity = playerScale.x > 0 ? transform.right : -transform.right;

        rb.velocity = initialVelocity * arrowSpeed;

        StartCoroutine(DestroyArrowAfterSomeTimePass());
    }

    private IEnumerator DestroyArrowAfterSomeTimePass()
    {
        yield return new WaitForSeconds(arrowDuration);
        Destroy(gameObject);
    }
}