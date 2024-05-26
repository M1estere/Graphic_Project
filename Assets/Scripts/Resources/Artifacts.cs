using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "config/artifacts", fileName = "Artifacts")]
public class Artifacts : ScriptableObject
{
    [field: SerializeField] public List<Artifact> ArtifactList { get; private set; } = new ();
    
    public void Take() {  }
}

[System.Serializable]
public class Artifact
{
    [field: SerializeField] public Sprite Image { get; private set; }
    [field: Space(5)]
    
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField, TextArea] public string Description { get; private set; }
    [field: SerializeField] public bool Unlocked { get; private set; }
    
    public void Take() {  } // TODO: PlayerPrefs / Other System
}