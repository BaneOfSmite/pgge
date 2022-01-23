using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {
    AudioSource audioSource;
    public AudioClip[] dirt, concrete, metal, sand, wood; //Array for all the footstep sounds
    private void Start() {
        audioSource = GetComponent<AudioSource>(); //Get reference to the attached audiosource
    }
    public void walkingStep() {
        AudioClip toPlay = checkMaterial(); //Set the audioClip to play based on the material the player walked onto
        audioSource.volume = Random.Range(0.3f, 0.5f); //Randomize the volume
        audioSource.PlayOneShot(toPlay); //Play the audio
    }
    public void RunningStep() {
        AudioClip toPlay = checkMaterial(); //Set the audioClip to play based on the material the player walked onto
        audioSource.volume = Random.Range(0.6f, 0.9f); //Randomize the volume
        audioSource.PlayOneShot(toPlay); //Play the audio
    }

    private AudioClip checkMaterial() {
        audioSource.pitch = Random.Range(0.3f, 0.7f); //Randomize the pitch of the sound
        AudioClip toPlay = concrete[Random.Range(0, dirt.Length)]; //Set the audioclip to a randomize clip of concrete walking sound
        RaycastHit hit;
        //Check for the name of the object the player is walking on by using raycast
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), new Vector3(transform.position.x, transform.position.y - 1, transform.position.z) - new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), out hit)) {
            switch (hit.transform.name) {
                case "Dirt":
                    toPlay = dirt[Random.Range(0, dirt.Length)]; //Set the audioclip to a randomize clip of dirt walking sound
                    break;
                case "Metal":
                    toPlay = metal[Random.Range(0, dirt.Length)]; //Set the audioclip to a randomize clip of metal walking sound
                    break;
                case "Sand":
                    toPlay = sand[Random.Range(0, dirt.Length)]; //Set the audioclip to a randomize clip of sand walking sound
                    break;
                case "Wood":
                    toPlay = wood[Random.Range(0, dirt.Length)]; //Set the audioclip to a randomize clip of wood walking sound
                    break;
            }
        }
        return toPlay; //Return the audioClip
    }
}
