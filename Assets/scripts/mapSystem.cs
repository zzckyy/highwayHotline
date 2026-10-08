using UnityEngine;

public class mapSystem : MonoBehaviour
{
    public SpriteRenderer road;
    public Sprite[] Maps;
    
    // Simpan index saat ini di sini agar tidak hilang
    private int currentIndex = 0; 

    // Panggil fungsi ini pada OnClick() di komponen Button kamu
    public void NextMap()
    {
        // 1. Tambah index + 1 setiap kali diklik
        currentIndex++;

        // 2. Jika index sudah melebihi jumlah maksimal Map, kembalikan ke awal (looping)
        // (Array dimulai dari 0, jadi batas maksimalnya adalah Length - 1)
        if (currentIndex >= Maps.Length)
        {
            currentIndex = 0; 
            
            // Catatan: Jika tidak ingin kembali ke awal dan mentok di map terakhir, 
            // ganti dengan: currentIndex = Maps.Length - 1;
        }

        // 3. Pasang sprite dari array ke SpriteRenderer
        if (Maps.Length > 0 && road != null)
        {
            road.sprite = Maps[currentIndex];
            Debug.Log("Menampilkan Map Index: " + currentIndex);
        }
    }
}