namespace Hubs.Framework
{
    using System.Collections.Generic;

    public class Workspace
    {
        public Workspace()
        {
            this.Hubs = new List<Hub>();
        }

        public List<Hub> Hubs { get; set; }

        public static Workspace Create()
        {
            return new Workspace();
        }

        public void CreateHub(string name)
        {
            this.Hubs.Add(new Hub(name));
        }

        public void RemoveHub(int index)
        {
            this.Hubs.RemoveAt(index);
        }
    }
}
