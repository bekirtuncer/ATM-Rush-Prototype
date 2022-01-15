using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATMRush
{
    public class Collision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Cube")
            {
                if (!ATMRushManager.Instance.Cubes.Contains(other.gameObject))
                {
                    other.GetComponent<BoxCollider>().isTrigger = false;
                    other.gameObject.tag = "Untagged";
                    other.gameObject.AddComponent<Collision>();
                    other.gameObject.AddComponent<Rigidbody>();
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                    ATMRushManager.Instance.StackCube(other.gameObject, ATMRushManager.Instance.Cubes.Count - 1);
                }
            }
        }
    }    
}
