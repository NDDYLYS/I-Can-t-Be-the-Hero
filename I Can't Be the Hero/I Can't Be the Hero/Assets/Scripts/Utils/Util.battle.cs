using System.Collections.Generic;
using System.Diagnostics;

public static partial class Util
{
    //public static void CreateMessageBox(string _codename)
    //{
    //    var prefab = UIPrefabManager.Instance.MessageBoxProperty.OnClickOpenPageButton(_codename);
    //}

    public static int BattleElementDamage(ElementEnum _defender, ElementEnum _attacker) 
    {
        var damage = 0;
        var defender = _defender;
        var defEl = TableDataManager.Instance.GetTableData<Table_Element>(_defender.ToString());
        var attacker = _attacker;
        damage = defEl.ElementDamage[(int)attacker];

        LogManager.Instance.DebugLogCategory(LogCategoryEnum.Battle, $"{defender}/{attacker}>>>{damage}");

        return damage;
    }
}
