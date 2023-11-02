



Console.WriteLine(Smaller(21));
Console.WriteLine(Smaller(531));
Console.WriteLine(Smaller(2071));
Console.WriteLine(Smaller(1027));
Console.WriteLine(Smaller(111));
Console.WriteLine(Smaller(9));
Console.WriteLine(Smaller(0));
Console.WriteLine(Smaller(907));
Console.WriteLine(Smaller(29009));
Console.WriteLine(Smaller(59884848483559L));


static long Smaller(long n)
{
    var ListNumber = new List<int>(n.ToString().Select(x => int.Parse(x.ToString())));
    for(int i = 0; i < ListNumber.Count; i++)
    {
        for(int j = i; j < ListNumber.Count; j++)
        {
            if (ListNumber[i] > ListNumber[j])
            {
                if (ListNumber[j] == 0 && i == 0)
                    continue;
                var temp = ListNumber[i];
                ListNumber[i] = ListNumber[j]; 
                ListNumber[j] = temp;
            }
        }
    }
    var listNumberStr = "";
    for (int i = 0; i < ListNumber.Count; i++)
    {
        listNumberStr += ListNumber[i].ToString();
    }
    var resTry = long.TryParse(listNumberStr, out var result);
    if(resTry && n != result)
    {
        return result;
    }
    else
    {
        return -1;
    }
}