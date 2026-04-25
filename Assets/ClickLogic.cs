using UnityEngine;

public class ClickLogic : MonoBehaviour, MouseAct
{

    void MouseAct.OnClickAction()
    {
        Destroy(gameObject);
    }

}
