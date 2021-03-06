using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SoalManager : MonoBehaviour
{
    [System.Serializable]
    public class Soal
    {
        [TextArea]
        [Header("Soal")]
        public string soal;

        [Header("Pilihan jawaban")]
        public string pilA;
        public string pilB, pilC, pilD;

        [Header("Kunci jawaban")]
        public bool A;
        public bool B, C, D;

        
    }

    public GameObject selesai;
    public int skor;
    public float waktu;
    private int nilaiAcak;
    Text textSoal, textA, textB, textC, textD, textWaktu;


    public List<Soal> KumpulanSoal;

    // Start is called before the first frame update
    void Start()
    {
        textSoal = GameObject.Find("TextSoal").GetComponent<Text>();
        textA = GameObject.Find("A").GetComponent<Text>();
        textB = GameObject.Find("B").GetComponent<Text>();
        textC = GameObject.Find("C").GetComponent<Text>();
        textD = GameObject.Find("D").GetComponent<Text>();
        nilaiAcak = Random.RandomRange(0,KumpulanSoal.Count);
        textWaktu = GameObject.Find("TextWaktu").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textWaktu.text = "" + waktu.ToString("0");
        waktu -= Time.deltaTime;
        if (waktu<=0){
            KumpulanSoal.RemoveAt(nilaiAcak);
            waktu = 10;
            nilaiAcak = Random.RandomRange(0,KumpulanSoal.Count);
        }
        
        if (KumpulanSoal.Count>0) {
        textSoal.text = KumpulanSoal[nilaiAcak].soal;
        textA.text = KumpulanSoal[nilaiAcak].pilA;
        textB.text = KumpulanSoal[nilaiAcak].pilB;
        textC.text = KumpulanSoal[nilaiAcak].pilC;
        textD.text = KumpulanSoal[nilaiAcak].pilD;
        }
        else {
            selesai.SetActive(true);
            textSoal.text = "Skor :" + skor;
            GameObject.Find("TextWaktu").SetActive(false);
            GameObject.Find("PanelJawaban").SetActive(false);
        }
    }

    

    public void CekJawaban(string jawaban) {
        if (KumpulanSoal[nilaiAcak].A==true && jawaban=="a"){
            skor++;
        }

        if (KumpulanSoal[nilaiAcak].B==true && jawaban=="b"){
            skor++;
        }

        if (KumpulanSoal[nilaiAcak].C==true && jawaban=="c"){
            skor++;
        }

        if (KumpulanSoal[nilaiAcak].D==true && jawaban=="d"){
            skor++;
        }

        KumpulanSoal.RemoveAt(nilaiAcak);
        nilaiAcak = Random.RandomRange(0,KumpulanSoal.Count);
        waktu = 10;
    }

    public void ulang() {
        Application.LoadLevel(Application.loadedLevel);
    }
}
