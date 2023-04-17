using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEkz.Data
{
    public partial class DbEntities : DbContext
    {
        private static DbEntities context;

        public static DbEntities GetContext()
        {
            if (context == null)
            {
                context = new DbEntities();
            }
            return context;
        }
    }
    public partial class RealEstate
    {
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", this.Address_City, this.Address_Street, this.Address_House, this.Address_Number);
        }
    }
    public partial class Demand
    {
        public override string ToString()
        {
            return string.Format("{0} {1} {2} \nПокупатели - {3} \nРиелтор - {4} \nМин. площадь - {5} Макс. площадь - {6}", 
                Type.Title, 
                this.Address_City, 
                this.Address_Street, 
                this.Client.FirstName, 
                this.Agent.FirstName, 
                this.MinArea, 
                this.MaxArea);
        }
    }
    public partial class Supply
    {
        public override string ToString()
        {
            return string.Format("{0} {1} {2} \nПродавец - {3} \nРиелтор - {4} \nПлощадь - {5} \nЭтаж - {6} Комната - {7}",
               RealEstate.Type.Title,
               this.RealEstate.Address_City,
               this.RealEstate.Address_Street,
               this.Client.FirstName,
               this.Agent.FirstName,
               this.RealEstate.TotalArea,
               this.RealEstate.Floor,
                this.RealEstate.Rooms);
        }
    }
}
