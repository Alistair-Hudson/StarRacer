using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarRacer.Items
{
    public class ItemActionController : MonoBehaviour
    {


        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Item Obtained!!");
        }

        public void UseItem()
        {

        }
    }
}
