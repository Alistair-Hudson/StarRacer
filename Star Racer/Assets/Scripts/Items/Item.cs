using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarRacer.Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
    public class Item : ScriptableObject
    {
        public GameObject model;
        public float MovementSpeed;

        public void CreateItem()
        {

        }
    }
}