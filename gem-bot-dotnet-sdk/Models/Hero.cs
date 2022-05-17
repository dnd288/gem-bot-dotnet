using gem_bot_dotnet_sdk.Utils;
using GemBotSdk.Enum;
using Sfs2X.Entities.Data;

namespace GemBotSdk.Models;

public class Hero
{
    private int PlayerId { get; }
    public HeroId Id { get; }
    public string Name { get; set; }
    public List<GemType> GemTypes { get; } = new();
    public int MaxHp { get; set; }
    public int MaxMana { get; set; } // Mp
    public int Attack { get; set; }
    public int Hp { get; set; }
    public int Mana { get; set; }

    public bool IsAlive => Hp > 0;
    public bool IsFullMana => Mana >= MaxMana;

    public bool IsHeroSelfSkill => HeroId.SEA_SPIRIT == Id;

    public Hero(ISFSObject objHero) {
        PlayerId = objHero.GetInt("playerId");
        Id = EnumUtils.ParseEnum<HeroId>(objHero.GetUtfString("id"));
        Name = Id.ToString();
        Attack = objHero.GetInt("attack");
        MaxHp = objHero.GetInt("maxHp");
        Hp = objHero.GetInt("hp");
        Mana = objHero.GetInt("mana");
        MaxMana = objHero.GetInt("maxMana");

        var arrGemTypes = objHero.GetSFSArray("gemTypes");
        for (var i = 0; i < arrGemTypes.Count; i++) {
            GemTypes.Add(EnumUtils.ParseEnum<GemType>(arrGemTypes.GetUtfString(i)));
        }
    }

    public void UpdateHero(ISFSObject objHero) {
        Attack = objHero.GetInt("attack");
        Hp = objHero.GetInt("hp");
        Mana = objHero.GetInt("mana");
        MaxMana = objHero.GetInt("maxMana");
    }

    public string PrintGemType()
    {
        return GemTypes.Aggregate(string.Empty, (current, gemType) => current + gemType);
    }
}