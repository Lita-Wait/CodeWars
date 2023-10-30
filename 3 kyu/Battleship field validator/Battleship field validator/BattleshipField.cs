namespace Battleship_field_validator
{
    public class BattleshipField
    {
        private static int[,] field = new int[10, 10];
        public static bool ValidateBattlefield(int[,] _field)
        {
            field = _field;
            var listSize = new List<int>();
            for (int x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    if (field[x, y] == 1)
                    {
                        var size = 0;
                        var i = x;
                        var j = y;
                        if (i == field.GetLength(0) - 1 && j == field.GetLength(1) - 1)
                        {
                            size++;
                            field[i, j] = 0;
                        }
                        else if (j != field.GetLength(1) - 1 && field[i, j + 1] == 1)
                        {
                            while (field[i, j] == 1)
                            {
                                bool cheaking = false;
                                if (j == 0)
                                    cheaking = CheackCur(i, j, 0) && CheackNext(i, j, 0);
                                else if (j == 9)
                                    cheaking = CheackLast(i, j, 0) && CheackCur(i, j, 0);
                                else
                                    cheaking = CheackLast(i, j, 0) && CheackCur(i, j, 0) && CheackNext(i, j, 0);

                                if (cheaking)
                                {
                                    size++;
                                    field[i, j] = 0;
                                    j++;
                                }
                                else
                                    break;

                            }
                        }
                        else if (i != field.GetLength(0) - 1 && field[i + 1, j] == 1)
                        {
                            while (field[i, j] == 1)
                            {
                                bool cheaking = false;
                                if (i == 0)
                                    cheaking = CheackCur(i, j, 1) && CheackNext(i, j, 1);
                                else if (i == 9)
                                    cheaking = CheackLast(i, j, 1) && CheackCur(i, j, 1);
                                else
                                    cheaking = CheackLast(i, j, 1) && CheackCur(i, j, 1) && CheackNext(i, j, 1);
                                if (cheaking)
                                {
                                    size++;
                                    field[i, j] = 0;
                                    i++;
                                }
                                else
                                    break;
                            }
                        }
                        else
                        {
                            bool cheaking = false;
                            if (j == 0)
                                cheaking = CheackCur(i, j, 0) && CheackNext(i, j, 0);
                            else if (j == 9)
                                cheaking = CheackLast(i, j, 0) && CheackCur(i, j, 0);
                            else
                                cheaking = CheackLast(i, j, 0) && CheackCur(i, j, 0) && CheackNext(i, j, 0);

                            if (i == 0)
                                cheaking = CheackCur(i, j, 1) && CheackNext(i, j, 1);
                            else if (i == 9)
                                cheaking = CheackLast(i, j, 1) && CheackCur(i, j, 1);
                            else
                                cheaking = CheackLast(i, j, 1) && CheackCur(i, j, 1) && CheackNext(i, j, 1);

                            if (cheaking)
                            {
                                size++;
                                field[i, j] = 0;

                            }
                            else
                                break;

                        }

                        listSize.Add(size);

                    }
                }
            }
            var listSizeForEq = new List<int> { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

            return listSize.OrderByDescending(x => x).SequenceEqual(listSizeForEq);
        }
        public static bool CheackLast(int x, int y, int dim)
        {
            bool res = false;
            if (dim == 0)
                res = field[x + 1, y - 1] == 0;
            else
                res = field[x - 1, y + 1] == 0;
            return res;
        }
        public static bool CheackCur(int x, int y, int dim)
        {
            bool res = false;
            if (dim == 0)
                res = field[x + 1, y] == 0;
            else
                res = field[x, y + 1] == 0;
            return res;
        }
        public static bool CheackNext(int x, int y, int dim)
        {
            bool res = false;
            if (dim == 0)
                res = field[x + 1, y + 1] == 0;
            else
                res = field[x + 1, y + 1] == 0;
            return res;
        }
    }
}