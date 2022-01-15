using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace ATMRush
{
    public class ATMRushManager : MonoBehaviour
    {
        [SerializeField] private float _movementDelay;
        
        public static ATMRushManager Instance;
        
        public List<GameObject> Cubes = new List<GameObject>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Update()
        {
            if (Input.GetButton("Fire1"))
            {
                MoveListELements();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                MoveOrigin(); 
            }
        }

        public void StackCube(GameObject other, int index)
        {
            other.transform.parent = transform;
            Vector3 newPos = Cubes[index].transform.localPosition;
            newPos.z += 1;
            other.transform.localPosition = newPos;
            Cubes.Add(other);
            
            StartCoroutine(MakeObjectsBigger());
        }

        private IEnumerator MakeObjectsBigger()
        {
            for (int i = Cubes.Count-1; i > 0; i--)
            {
                int index = i;
                Vector3 scale = new Vector3(1, 1, 1);
                scale *= 1.5f;

                Cubes[index].transform.DOScale(scale, 0.1f).OnComplete(() =>
                 Cubes[index].transform.DOScale(new Vector3(1, 1, 1), 0.1f));
                yield return new WaitForSeconds(0.05f);
            }
        }

        private void MoveListELements()
        {
            for (int i = 1; i < Cubes.Count; i++)
            {
                Vector3 pos = Cubes[i].transform.localPosition;
                pos.x = Cubes[i - 1].transform.localPosition.x;
                Cubes[i].transform.DOLocalMove(pos, _movementDelay);
            }
        }

        private void MoveOrigin()
        {
            for (int i = 1; i < Cubes.Count; i++)
            {
                Vector3 pos = Cubes[i].transform.localPosition;
                pos.x = Cubes[0].transform.localPosition.x;
                Cubes[i].transform.DOLocalMove(pos, 0.7f);
            }
        }
    }
}
