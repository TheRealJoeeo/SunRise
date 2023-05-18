using UnityEngine;

public class noLongerInUse : MonoBehaviour {

    public Transform player;

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}