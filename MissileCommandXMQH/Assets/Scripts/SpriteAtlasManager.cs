using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
public class SpriteAtlasManager : MonoBehaviour
{
    public static readonly int BATTERY_ATLAS = 0;
    public static readonly int HUD_ATLAS = 1;

    [SerializeField]
    private SpriteAtlas _batteryAtlas = null;

    [SerializeField]
    private SpriteAtlas _hudAtlas = null;

    private List<SpriteAtlas> _atlasses = null;

    private static SpriteAtlasManager _instance;

    public static SpriteAtlasManager Instance
    {
        get
        {
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        else if(Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        _atlasses = new List<SpriteAtlas>()
        {
            _batteryAtlas, _hudAtlas
        };
    }

    public int NumberOfSprites(string name)
    {
        int numSpritesFound = 0;
        bool spriteWasFound = true;
        Sprite spriteFromAtlas = null;
        
        while(spriteWasFound)
        {
            spriteFromAtlas = _batteryAtlas.GetSprite(name + "_" + (numSpritesFound + 1));

            if(spriteFromAtlas == null)
            {
                spriteWasFound = false;
            }
        }
        return (numSpritesFound);
    }

    public Sprite GetSprite(int atlasId, int imageId)
    {
        string imagePrefix = "";
        switch(atlasId)
        {
            case 0:
                imagePrefix = "battery_";
                break;
        }
        Sprite spriteFromAtlas = _atlasses[atlasId].GetSprite(imagePrefix + imageId);

        return (spriteFromAtlas);
    }

    public Sprite GetSpriteByName(int atlasId, string imageName)
    {
        Sprite spriteFromAtlas = _atlasses[atlasId].GetSprite(imageName);

        return (spriteFromAtlas);
    }
}
