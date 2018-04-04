using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Lake : IEnumerable<int>
{
    private List<int> stones;

    public Lake(params int[] stones)
    {
        this.stones = new List<int>(stones);
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 1; i <= this.stones.Count; i++)
        {
            if (i%2!=0)
            {
                yield return this.stones[i - 1];
            }
        }
        for (int i = this.stones.Count; i >= 1; i--)
        {
            if (i%2==0)
            {
                yield return this.stones[i - 1];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
