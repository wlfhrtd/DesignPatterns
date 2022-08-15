namespace Visitor.Models
{
    public class Book : Item, IVisitableElement
    {
        public Book(int id, decimal price) : base(id, price) { }


        public void Accept(IVisitor visitor)
        {
            visitor.VisitBook(this);
        }
    }
}
