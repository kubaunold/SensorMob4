using System.ComponentModel.DataAnnotations.Schema; //added here for Table()


namespace SensorMobCRUD.Models
{
    [Table("measurments")]
    public class Measurment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public bool Status { get; set; }
    }
}