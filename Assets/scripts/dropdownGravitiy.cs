using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropdownGravitiy : MonoBehaviour
{
    public int myOption;
    public TMPro.TMP_Dropdown myDrop;

    public void GravitySelector()
    {
        myOption = myDrop.value;
    }
}
