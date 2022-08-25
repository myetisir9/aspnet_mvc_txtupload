namespace aspnet_mvc.Models
{
    public class Class1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Class1(int i, string n, int q)
        {
            this.Id = i;
            this.Name = n;
            this.Quantity = q;
        }

        public static Class1 GetProduct()
        {
            Class1 product = new Class1(0, "newProduct1", 100);
            return product;
        }

        public static List<Class1> GetAll()
        {
            List<Class1> class1s = new List<Class1>();

            for (int i = 0; i < 100; i++)
            {
                class1s.Add(new Class1(i, "product" + i, i * 35));
            };

            return class1s;
        }
    }

    //public class ClassList
    //{
    //    public List<Class1>? class1s { get; set; }
    //    public int index = 0;

    //    public void AddItem(Class1 newclass1)
    //    {
    //        class1s.Append(newclass1);
    //        index++;
    //    }
    //    public void RemoveItem(Class1 class1toremove)
    //    {
    //        class1s.Remove(class1toremove);
    //        index--;
    //    }
    //    public Class1 GetClass1byIndex(int i)
    //    {
    //        return class1s[i];
    //    }
    //    public List<Class1> GetAll()
    //    {
    //        return class1s;
    //    }
    //}
}
