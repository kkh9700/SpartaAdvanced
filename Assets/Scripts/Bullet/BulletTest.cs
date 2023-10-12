using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour
{

    [field: Header("GameObject")]
    [field: SerializeField] private Transform AtkPos;

    void Start()
    {
        StartCoroutine(Attack());
    }

    void Update()
    {

    }

    IEnumerator Attack()
    {
        while (true)
        {
            Vector3 dir = transform.localRotation * Vector3.forward;
            dir = dir.normalized;

            Transform bullet = PoolManager.I.Get(0).transform;
            bullet.position = AtkPos.position;
            bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
            bullet.GetComponent<Bullet>().Init(1, .5f);

            yield return new WaitForSeconds(.5f);
        }
    }
}
