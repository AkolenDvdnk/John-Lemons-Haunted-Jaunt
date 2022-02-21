﻿using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestController.Count++;
            Destroy(gameObject);
        }
    }
}
