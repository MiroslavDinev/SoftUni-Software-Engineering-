namespace _01Logger.Layouts.Factories
{
    using Contracts;
    using System;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            string loweredLayoutType = layoutType.ToLower();

            switch (loweredLayoutType)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}
