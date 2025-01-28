using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistem : MonoBehaviour

{
    public static Sistem instance;
    public int ID;
    public GameObject TempatSpawn;
    public GameObject Gui_Utama;
    public GameObject[] KoleksiBuah;
    public AudioClip[] SuaraBuah;
    AudioSource Suara;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ID = 0;
        //SpawnObject();
        Gui_Utama.SetActive(false);
        Suara = gameObject.AddComponent<AudioSource>();
    }

    public void SpawnObject()
    {
       GameObject BendaSebelumnya = GameObject.FindGameObjectWithTag("Buah");
        if (BendaSebelumnya != null) Destroy(BendaSebelumnya);

       GameObject Benda = Instantiate(KoleksiBuah[ID]);
       Benda.transform.SetParent(TempatSpawn.transform, false);
        Benda.transform.localScale = new Vector3(2, 2, 2);
        TempatSpawn.GetComponent<Animation>().Play("PopUp");
       KumpulanSuara.instance.Panggil_Suara(1);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GantiBuah(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GantiBuah(false);
        }
    }

    public void GantiBuah(bool Kanan)
    {
        if (Kanan)
        {
            if(ID >= KoleksiBuah.Length - 1)
            {
                ID = 0;
            }
            else
            {
                ID++;
            }
        }
        else
        {
            if (ID <= 0)
            {
                ID = KoleksiBuah.Length - 1;
            }
            else
            {
                ID-- ;
            }
        }

        SpawnObject();
        PanggilSuaraBuah();
    }

    public void PanggilSuaraBuah()
    {
        Suara.clip = SuaraBuah[ID];
        Suara.Play();
    }
}
