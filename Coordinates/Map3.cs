using System.Collections;

public class Map3<T> : IEnumerable {
    T[,,] map;

    public T this[int x, int y, int z]
    {
        get
        {
            return map[x, y, z];
        }
        set
        {
            map[x, y, z] = value;
        }
    }

    public T this[IntVector3 coord]
    {
        get
        {
            return map[coord.x, coord.y, coord.z];
        }
    }

    public int size_x
    {
        get
        {
            return map.GetLength(0);
        }
    }

    public int size_y
    {
        get
        {
            return map.GetLength(1);
        }
    }

    public int size_z
    {
        get
        {
            return map.GetLength(2);
        }
    }

    public Map3(int size)
    {
        map = new T[size, size, size];
    }

    public Map3(int size_x, int size_y, int size_z)
    {
        map = new T[size_x, size_y, size_z];
    }

    //Enumerator
    public class Map3Enumerator:IEnumerator
    {
        Map3<T> map;
        public int x;
        public int y;
        public int z;



        public object Current
        {
            get
            {
                return map[x, y, z];
            }
        }

        public bool MoveNext()
        {
            x++;
            if(x >= map.size_x)
            {
                x = 0;
                y++;
                if(y >= map.size_y)
                {
                    y = 0;
                    z++;
                    if(z >= map.size_z)
                    {
                        return false;
                    }
                }
            }

            return true;
        }


        public void Reset()
        {
            x = 0;
            y = 0;
            z = 0;
        }


        public Map3Enumerator(Map3<T> map)
        {
            this.map = map;
        }
    }

    public IEnumerator GetEnumerator()
    {
        return new Map3Enumerator(this);
    }
	
}

public class IntVector3
{
    public int x;
    public int y;
    public int z;

    public IntVector3 inversed
    {
        get
        {
            return new IntVector3(-this.x, -this.y, -this.z);
        }
    }

    //Commen use
    public IntVector3(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public IntVector3()
    {
        this.x = 0;
        this.y = 0;
        this.z = 0;
    }

    public static IntVector3 operator +(IntVector3 left, IntVector3 right)
    {
        return new IntVector3(left.x + right.x, left.y + right.y, left.z + right.z);
    }

    public static IntVector3 operator -(IntVector3 left, IntVector3 right)
    {
        return new IntVector3(left.x - right.x, left.y - right.y, left.z - right.z);
    }

    

    //Static Values
    public static IntVector3 up = new IntVector3(0, 1, 0);
    public static IntVector3 down = new IntVector3(0, -1, 0);
    public static IntVector3 left = new IntVector3(-1, 0, 0);
    public static IntVector3 right = new IntVector3(1, 0, 0);
    public static IntVector3 forward = new IntVector3(0, 0, 1);
    public static IntVector3 back = new IntVector3(0, 0, -1);

    public static IntVector3[] directions_straight = { up, down, left, right, forward, back };
    public static IntVector3[] directions_all =
    {
        up, down, left, right, forward, back,
        up + left,
        up + left + forward,
        up + left + back,
        up + right,
        up + right + forward,
        up + right + back,
        up + forward,
        up + back,

        left + forward,
        left + back,
        right + forward,
        right + back,

        down + left,
        down + left + forward,
        down + left + back,
        down + right,
        down + right + forward,
        down + right + back,
        down + forward,
        down + back
    };

    
}
