
[System.Serializable]
public class Table_Element
{
	public int Index ;
	public string CodeName ;
	public int[] ElementDamage ;


	public static void AutoLoadTable()
	{
		string[,] data = TableDataManager.Instance.PublicExcelReader("Table_Element", true);
		LoadTable(data);
	}


	public static void LoadTable(string[,] _data)
	{
		for (int i = 4; i < _data.GetLength(0); i++)
		{
			int columnCount = 0;
			Table_Element newData = new Table_Element();
			newData.Index = int.Parse(_data[i, columnCount++]);
			newData.CodeName = _data[i, columnCount++];
			newData.ElementDamage = new int[11];
			newData.ElementDamage[0] = int.Parse(_data[i, columnCount++]);
			newData.ElementDamage[1] = int.Parse(_data[i, columnCount++]);
			newData.ElementDamage[2] = int.Parse(_data[i, columnCount++]);
			newData.ElementDamage[3] = int.Parse(_data[i, columnCount++]);
			newData.ElementDamage[4] = int.Parse(_data[i, columnCount++]);
			newData.ElementDamage[5] = int.Parse(_data[i, columnCount++]);
			newData.ElementDamage[6] = int.Parse(_data[i, columnCount++]);
			newData.ElementDamage[7] = int.Parse(_data[i, columnCount++]);
			newData.ElementDamage[8] = int.Parse(_data[i, columnCount++]);
			newData.ElementDamage[9] = int.Parse(_data[i, columnCount++]);
			newData.ElementDamage[10] = int.Parse(_data[i, columnCount++]);
			TableDataManager.Instance.SetDictinary<Table_Element>(newData.Index, newData.CodeName, newData);
		}
	}


}