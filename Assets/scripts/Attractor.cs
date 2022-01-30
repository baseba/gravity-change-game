using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attractor : MonoBehaviour
{
    public Rigidbody rb;
    public dropdownGravitiy selector;


    void FixedUpdate() {

        Attractor[] attractors = FindObjectsOfType<Attractor>();

        foreach(Attractor attractor in attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }
    }



    void Attract (Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;
        float forceMagnitude = 0;
        // Debug.Log(selector.myOption);
        if(selector.myOption == 0)
        {
            forceMagnitude = rb.mass * rbToAttract.mass / Mathf.Pow(distance, 2);
        }
        else if(selector.myOption == 1)
        {
            forceMagnitude = 50*Mathf.Cos(distance/2);
        }
        else if(selector.myOption == 2)
        {
            forceMagnitude = Mathf.Tan(distance/5);
        }
        else if(selector.myOption == 3)
        {
            forceMagnitude = 1/(Mathf.Sin(distance/6));
        }
        else if(selector.myOption == 4)
        {
            forceMagnitude = distance - 20;
        }
        else if(selector.myOption == 5)
        {
            forceMagnitude = Mathf.Pow((distance - 30), 3)/10;
        }
        else if(selector.myOption == 6)
        {
            forceMagnitude = -10 + (20/(1 + Mathf.Exp(-distance + 20)));
        }



        // float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        // float forceMagnitude = 1 / Mathf.Cos(distance);
        // float forceMagnitude = 1 / Mathf.Tan(distance);
        // float forceMagnitude = 1/(Mathf.Sin(distance));
        // float forceMagnitude = distance - 20;
        // float forceMagnitude = Mathf.Pow((distance - 30), 3);
        // float forceMagnitude = -10 + (20/(1 + Mathf.Exp(-distance + 20)));
        // float forceMagnitude = AttractFunc(distance, opt_grav);

        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
