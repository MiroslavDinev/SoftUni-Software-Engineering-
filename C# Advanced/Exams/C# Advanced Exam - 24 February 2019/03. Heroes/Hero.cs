namespace Heroes
{
    using System.Text;
    public class Hero
    {
        public string Name { get; set; }

        public int Level { get; set; }

        public Item Item { get; set; }

        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Hero: {this.Name} - {this.Level}lvl");
            result.AppendLine(this.Item.ToString());

            return result.ToString().TrimEnd();
        }
    }
}
