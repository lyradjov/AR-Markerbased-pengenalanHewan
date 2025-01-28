 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungsiSentuhBuah : MonoBehaviour
{
    // Start is called before the first frame update
   
    
        private void OnMouseDown()
        {
            GetComponent<Animation>().Play("button");
            Sistem.instance.PanggilSuaraBuah();
        }
    

  
}
