using PlaneTransport.Enums;

namespace PlaneTransport.DataTransfer
{
    public class PlaneTransfer
    {
        public string Name { get; set; }

        public int Capacity { get; set; }

        public PlaneType PlaneType { get; set; }
    }
}
