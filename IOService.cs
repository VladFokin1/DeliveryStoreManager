using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery
{
    public class IOService
    {
        private readonly string _path;


        public IOService(string path)
        {
            _path = path;
        }

        public FoodStore LoadData()
        {
            bool fileExist = File.Exists(_path);
            if (!fileExist)
            {
                File.CreateText(_path).Dispose();
                return new FoodStore();
            }
            using (StreamReader reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                Savings save = JsonConvert.DeserializeObject<Savings> (fileText);
                FoodStore foodStore = new FoodStore();
                foodStore.Couriers = save.Couriers;
                foodStore.Money = save.Money;
                return foodStore;
            }
        }
        public void SaveData(ObservableCollection<Courier> cours, int money)
        {
            Savings save = new Savings(money, cours);
            using (StreamWriter writer = File.CreateText(_path))
            {
                string output = JsonConvert.SerializeObject(save);
                writer.Write(output);
            }
        }
    }
}
