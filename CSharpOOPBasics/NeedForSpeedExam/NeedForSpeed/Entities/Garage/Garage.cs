using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Garage
{
    private IDictionary<int, Car> parkedCars;
    public Garage()
    {
        this.ParkedCars = new Dictionary<int, Car>();
    }
    public IDictionary<int, Car> ParkedCars
    {
        get { return parkedCars; }
        protected set { parkedCars = value; }
    }

}
