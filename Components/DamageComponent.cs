using Godot;

public partial class DamageComponent : Node
{
    [Export]
    public int Damage = 1;

    public void DealDamage(Node target)
    {
        if (target is HealthComponent healthComponent)
        {
            healthComponent.TakeDamage(Damage);
        }
    }
}
