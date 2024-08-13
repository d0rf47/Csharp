namespace mfalconi.Basics
{
    public struct MutablePoint
    {
        public int X {get;set;}
        public int Y {get;set;}

        public MutablePoint(int x,int y) => (X,Y) = (x,y);

        public override string ToString() => $"({X}, {Y})";
        
    }
}