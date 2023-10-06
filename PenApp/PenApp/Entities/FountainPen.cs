namespace PenApp.Entities
{
    public class FountainPen : Pen
    {
        public new int Id { get; set; }
        public override string ToString() => base.ToString() + " Wieczne pióro";
    }
}
