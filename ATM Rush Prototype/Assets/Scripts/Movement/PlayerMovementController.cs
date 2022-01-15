using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATMRush.PlayerControls
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private PlayerMovementSettings _playerMovementSettings;
        [SerializeField] private Camera _camera;

        private void Update()
        {
            transform.position += Vector3.forward * _playerMovementSettings.MoveSpeed * Time.deltaTime;
            if (Input.GetButton("Fire1"))
            {
                Move();
            }
        }

        private void Move()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = _camera.transform.localPosition.z;

            Ray ray = _camera.ScreenPointToRay(mousePos);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject firstCube = ATMRushManager.Instance.Cubes[0];
                Vector3 hitVec = hit.point;
                hitVec.y = firstCube.transform.localPosition.y;
                hitVec.z = firstCube.transform.localPosition.z;

                firstCube.transform.localPosition = Vector3.MoveTowards
                    (firstCube.transform.localPosition, hitVec, Time.deltaTime * _playerMovementSettings.SwipeSpeed);
            }
        }
    }    
}
