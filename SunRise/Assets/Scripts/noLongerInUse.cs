using UnityEngine;

public class noLongerInUse : MonoBehaviour {

    public Transform player;

    // Update is called once per frame
    // as the name suggests, this is no longer in use
    void Update () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}