using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDLWRP.TOWER
{
    public class RadiusVisualizer : MonoBehaviour
    {
        public void Show()
        {
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        public void SetVisualizer(GameObject tower)
        {
            SphereCollider gunCollider = tower.GetComponentInChildren<SphereCollider>();
            this.gameObject.transform.localScale = Vector3.one * gunCollider.radius * 3.5f;
            this.gameObject.transform.position = tower.transform.position;
        }
    }
}
