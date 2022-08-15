namespace Visitor.Models
{
    public class Vinyl : Item, IVisitableElement
    {
        public Vinyl(int id, decimal price) : base(id, price) { }


        public void Accept(IVisitor visitor)
        {
            visitor.VisitVinyl(this);
        }
    }
}
