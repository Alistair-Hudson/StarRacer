using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarRacer.Items
{
    public class ItemPickUp : MonoBehaviour
    {
        [SerializeField]
        private GameObject model;
        [SerializeField]
        private float spawnDelay = 5f;

        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _collider.enabled = false;
            model.SetActive(false);
            StartCoroutine(SpawnTimer());
        }

        private IEnumerator SpawnTimer()
        {
            yield return new WaitForSeconds(spawnDelay);
            model.SetActive(true);
            _collider.enabled = true;
        }
    }
}