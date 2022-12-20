using Data;
namespace Models
{
    public struct Unit
    {
        public UnitType Type;
        public UnitAbility Ability;
        public Abilities Abilities;
        public bool IsEnemy;
        public UnitStates State;
        
        public readonly UnitData UnitData;

        public Unit(UnitData unitData, bool isEnemy)
        {
            UnitData = unitData;
            Type = unitData.type;
            Ability = unitData.ability;
            Abilities = new Abilities();
            State = UnitStates.Inactive;
            IsEnemy = isEnemy;
        }

        public void TakeDamage(int damage)
        {
            UnitData.health -= damage;
            if (UnitData.health <= 0)
            {
                UnitData.health = 0;
                Die();
            }
        }

        public void Heal(int amount)
        {
            UnitData.health += amount;
            if (UnitData.health > UnitData.maxHealth)
            {
                UnitData.health = UnitData.maxHealth;
            }
        }

        public void Buff(int buff) => 
            UnitData.maxHealth += buff;
        
        public void Debuff(int debuff) => 
            UnitData.maxHealth -= debuff;
        
        public void UseAbility(Unit target)
        {
            if (Ability == UnitAbility.Heal)
                Abilities.Heal(1, target);
            else if (Ability == UnitAbility.DealDamage) 
                Abilities.DealDamage(1, target);
        }

        public void Die()
        {
            // Do something
        }
    }

}

