using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_dealership
{
    class CarBuy
    {
        private string name;
        private string address;
        private string model;
        private List<int> upgrade = new List<int>(){};
        private int paints;

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Model { get => model; set => model = value; }
        public List<int> Upgrade { get => upgrade; set => upgrade = value; }
        public int Paints { get => paints; set => paints = value; }

        public int TotalPrice()
        {
            int tempupg = 0, tempm=0;
            foreach(int upg in Upgrade)
            {
                tempupg += upg;
            }
                
            
            switch (model)
            {
                case "Aston Martin": tempm = (int) models.Aston;
                    break;
                case "Bugatti": tempm = (int)models.Bugati;
                    break;
                case "Ferrari": tempm = (int)models.Ferrari;
                    break;
                case "Pagani": tempm = (int)models.Pagani;
                    break;
            }

            return tempm + tempupg + paints;

        }

        
    }
}
