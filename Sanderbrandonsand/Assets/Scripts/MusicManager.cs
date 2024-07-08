using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip song0;
    public AudioClip song1;
    public AudioClip song2;
    public AudioClip song3;
    public AudioClip song4;
    public AudioClip song5;
    public AudioClip song6;
    public AudioClip song7;
    public AudioClip song8;
    public AudioClip song9;
    public AudioClip song10;
    public AudioClip song11;
    public AudioClip song12;
    public AudioClip song13;
    public AudioClip song14;
    public AudioClip song15;
    public AudioClip song16;
    public AudioClip song17;
    public AudioClip song18;
    public AudioClip song19;
    public AudioClip song20;
    

    private playlist = new AudioClip[21];
        

    // Start is called before the first frame update
    void Start()
    {
        playlist[0] = song0;
        playlist[1] = song1;
        playlist[2] = song2;
        playlist[3] = song3;
        playlist[4] = song4;
        playlist[5] = song5;
        playlist[6] = song6;
        playlist[7] = song7;
        playlist[8] = song8;
        playlist[9] = song9;
        playlist[10] = song10;
        playlist[11] = song11;
        playlist[12] = song12;
        playlist[13] = song13;
        playlist[14] = song14;
        playlist[15] = song15;
        playlist[16] = song16;
        playlist[17] = song17;
        playlist[18] = song18;
        playlist[19] = song19;
        playlist[20] = song20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
