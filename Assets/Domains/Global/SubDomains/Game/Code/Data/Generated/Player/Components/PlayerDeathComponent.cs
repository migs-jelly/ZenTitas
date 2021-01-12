//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class PlayerEntity {

    public Domains.Global.SubDomains.Game.Code.Data.Player.Death death { get { return (Domains.Global.SubDomains.Game.Code.Data.Player.Death)GetComponent(PlayerComponentsLookup.Death); } }
    public bool hasDeath { get { return HasComponent(PlayerComponentsLookup.Death); } }

    public void AddDeath(bool newIsDead) {
        var index = PlayerComponentsLookup.Death;
        var component = (Domains.Global.SubDomains.Game.Code.Data.Player.Death)CreateComponent(index, typeof(Domains.Global.SubDomains.Game.Code.Data.Player.Death));
        component.IsDead = newIsDead;
        AddComponent(index, component);
    }

    public void ReplaceDeath(bool newIsDead) {
        var index = PlayerComponentsLookup.Death;
        var component = (Domains.Global.SubDomains.Game.Code.Data.Player.Death)CreateComponent(index, typeof(Domains.Global.SubDomains.Game.Code.Data.Player.Death));
        component.IsDead = newIsDead;
        ReplaceComponent(index, component);
    }

    public void RemoveDeath() {
        RemoveComponent(PlayerComponentsLookup.Death);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class PlayerMatcher {

    static Entitas.IMatcher<PlayerEntity> _matcherDeath;

    public static Entitas.IMatcher<PlayerEntity> Death {
        get {
            if (_matcherDeath == null) {
                var matcher = (Entitas.Matcher<PlayerEntity>)Entitas.Matcher<PlayerEntity>.AllOf(PlayerComponentsLookup.Death);
                matcher.componentNames = PlayerComponentsLookup.componentNames;
                _matcherDeath = matcher;
            }

            return _matcherDeath;
        }
    }
}
