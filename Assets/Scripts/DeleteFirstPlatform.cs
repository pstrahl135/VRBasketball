using UnityEngine;

public class DeleteFirstPlatform : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Platform"))
            Destroy(transform.parent.gameObject);

    }
}
