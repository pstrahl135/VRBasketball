using UnityEngine;

public class PlayerLose : MonoBehaviour {

    public GameObject panelLose;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            Time.timeScale = 0;
            panelLose.SetActive(true);

        }
    }
}
