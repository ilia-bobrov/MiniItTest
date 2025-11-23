namespace Game.Utils
{
public static class ArrayUtils
{
    /// <param name="number">Must counts from 0</param>
    public static Index2 NumberToIndex2DArray(int number, int sizeX)
    {
        return new Index2(number % sizeX, number / sizeX);
    }
    
    /// <returns>Counts from 0</returns>
    public static int IndexToNumber2DArray(int indexX, int indexY, int sizeX)
    {
        return indexY * sizeX + indexX;
    }
    
    /// <returns>Counts from 0</returns>
    public static int IndexToNumber2DArray((int x, int y) index, int sizeX)
    {
        return index.y * sizeX + index.x;
    }
    
    /// <returns>Counts from 0</returns>
    public static int IndexToNumber2DArray(Index2 index, int sizeX)
    {
        return index.y * sizeX + index.x;
    }
}
}